using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tron
{
    /// <summary>
    /// Tron Spiel mit 2 Spielern und mehreren Farben. Spieler wechselt Farbe wenn er durch ein Tor fährt
    /// Spieler verliert wenn er über eine Linie fährt mit der selben Farbe wie er.
    /// Beschleundigen in gewissem Grad möglich
    /// </summary>
    public struct Spieler
    {
        public bool amleben;
        public Color farbe;
        public Vector2 position;
        public Vector2 richtung;
    }
    public struct Linie
    {
        public Color farbe;
        public Vector2 position;
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D spielerTexture;
        Texture2D linieTexture;
        Texture2D levelTexture;
        Texture2D hintergrundTexture;
        SpriteFont font;

        int screenWidth;
        int screenHeight;
        float minimalegeschwindigkeit;
        float maximalegeschwindigkeit;
        float beschleunigung;
        float wendewinkel;
        int längelinie;
        int level;

        Spieler spieler1 = new Spieler();
        Spieler spieler2 = new Spieler();
        int spieler1punkte;
        int spieler2punkte;
        List<Linie> spieler1linie;
        List<Linie> spieler2linie;
        Color[,] levelcolorarray;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Tron";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            font = Content.Load<SpriteFont>("myFont");

            level = 0;
            spieler1punkte = 0;
            spieler2punkte = 0;
            InitGame();
        }
        private Color[,] TextureTo2DArray(Texture2D texture)
        {
            Color[] colors1D = new Color[texture.Width * texture.Height];
            texture.GetData(colors1D);

            Color[,] colors2D = new Color[texture.Width, texture.Height];
            for (int x = 0; x < texture.Width; x++)
                for (int y = 0; y < texture.Height; y++)
                    colors2D[x, y] = colors1D[x + y * texture.Width];

            return colors2D;
        }
        private void InitGame()
        {
            try
            {
                level++;
                levelTexture = Content.Load<Texture2D>("Level_" + level.ToString());
                levelcolorarray = TextureTo2DArray(levelTexture);
            }
            catch
            {
                try
                {
                    level = 1;
                    levelTexture = Content.Load<Texture2D>("Level_" + level.ToString());
                    levelcolorarray = TextureTo2DArray(levelTexture);
                }
                catch
                {
                    levelTexture = Content.Load<Texture2D>("Level_Default");
                    levelcolorarray = TextureTo2DArray(levelTexture);
                }
            }
            try
            {
                spielerTexture = Content.Load<Texture2D>("Bike_" + level.ToString());
            }
            catch
            {
                spielerTexture = Content.Load<Texture2D>("Bike_Default");
            }
            try
            {
                linieTexture = Content.Load<Texture2D>("Linie_" + level.ToString());
            }
            catch
            {
                linieTexture = Content.Load<Texture2D>("Linie_Default");
            }
            try
            {
                hintergrundTexture = Content.Load<Texture2D>("Hintergrund_" + level.ToString());
            }
            catch
            {
                hintergrundTexture = Content.Load<Texture2D>("Hintergrund_Default");
            }
            minimalegeschwindigkeit = 1f;
            maximalegeschwindigkeit = 3f;
            beschleunigung = 0.1f;
            wendewinkel = 0.1f;
            längelinie = 400;
            spieler1linie = new List<Linie>();
            spieler1linie.Add(new Linie());
            spieler2linie = new List<Linie>();
            spieler2linie.Add(new Linie());
            LoadSpieler();
        }
        private void LoadSpieler()
        {
            spieler1.position = new Vector2(100, 100);
            spieler1.richtung = new Vector2(minimalegeschwindigkeit, 0.1f);
            spieler1.farbe = new Color(200, 50, 50);
            spieler1.amleben = true;

            spieler2.position = new Vector2(700, 100);
            spieler2.richtung = new Vector2(-minimalegeschwindigkeit, 0.1f);
            spieler2.farbe = new Color(200, 50, 50);
            spieler2.amleben = true;
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ProcessKeyboard();
            UpdateSpieler();
            base.Update(gameTime);
        }
        private void UpdateSpieler()
        {
            float anzahlschritte;
            Linie neueLinie = new Linie();
            Vector2 schritt;
            {///////////Spieler1//////////
                anzahlschritte = spieler1.richtung.Length();
                schritt = Vector2.Normalize(spieler1.richtung)*2;
                while (anzahlschritte > 0)
                {

                    spieler1.position += schritt;
                    neueLinie.farbe = spieler1.farbe;
                    neueLinie.position = spieler1.position;
                    spieler1linie.Add(neueLinie);

                    if (levelcolorarray[(int)spieler1.position.X, (int)spieler1.position.Y] == new Color(255, 0, 0))
                        spieler1.farbe = new Color(200, 50, 50);
                    if (levelcolorarray[(int)spieler1.position.X, (int)spieler1.position.Y] == new Color(0, 0, 255))
                        spieler1.farbe = new Color(120, 20, 255);
                    if (levelcolorarray[(int)spieler1.position.X, (int)spieler1.position.Y] == new Color(255, 255, 0))
                        spieler1.farbe = new Color(255, 200, 100);
                    if (levelcolorarray[(int)spieler1.position.X, (int)spieler1.position.Y] == Color.White)
                        spieler1.amleben = false;
                    int anzahllinien = spieler1linie.LastIndexOf(spieler1linie.Last<Linie>()) - 10;
                    for (int i = 0; i < anzahllinien; i++)
                    {
                        if (Vector2.Distance(spieler1linie[i].position, spieler1.position) < linieTexture.Width / 5)
                        {
                            if (spieler1linie[i].farbe == spieler1.farbe)
                                spieler1.amleben = false;
                        }
                    }
                    anzahllinien = spieler2linie.LastIndexOf(spieler2linie.Last<Linie>()) - 10;
                    for (int i = 0; i < anzahllinien; i++)
                    {
                        if (Vector2.Distance(spieler2linie[i].position, spieler1.position) < linieTexture.Width / 5)
                        {
                            if (spieler2linie[i].farbe == spieler1.farbe)
                                spieler1.amleben = false;
                        }
                    }
                    anzahllinien = spieler1linie.LastIndexOf(spieler1linie.Last<Linie>()) - längelinie;
                    for (int i = 0; i < anzahllinien; i++)
                    {
                        spieler1linie.RemoveAt(i);
                    }
                    anzahlschritte--;
                }
            }////////////////////////////

            {///////////Spieler2//////////
                anzahlschritte = spieler2.richtung.Length();
                schritt = Vector2.Normalize(spieler2.richtung)*2;
                while (anzahlschritte > 0)
                {
                    spieler2.position += schritt;
                    neueLinie.farbe = spieler2.farbe;
                    neueLinie.position = spieler2.position;
                    spieler2linie.Add(neueLinie);

                    if (levelcolorarray[(int)spieler2.position.X, (int)spieler2.position.Y] == new Color(255, 0, 0))
                        spieler2.farbe = new Color(200, 50, 50);
                    if (levelcolorarray[(int)spieler2.position.X, (int)spieler2.position.Y] == new Color(0, 0, 255))
                        spieler2.farbe = new Color(120, 20, 255);
                    if (levelcolorarray[(int)spieler2.position.X, (int)spieler2.position.Y] == new Color(255, 255, 0))
                        spieler2.farbe = new Color(255, 200, 100);
                    if (levelcolorarray[(int)spieler2.position.X, (int)spieler2.position.Y] == Color.White)
                        spieler2.amleben = false;
                    int anzahllinien = spieler2linie.LastIndexOf(spieler2linie.Last<Linie>()) - 10;
                    for (int i = 0; i < anzahllinien; i++)
                    {
                        if (Vector2.Distance(spieler2linie[i].position, spieler2.position) < linieTexture.Width / 5)
                        {
                            if (spieler2linie[i].farbe == spieler2.farbe)
                                spieler2.amleben = false;
                        }
                    }
                    anzahllinien = spieler1linie.LastIndexOf(spieler1linie.Last<Linie>()) - 10;
                    for (int i = 0; i < anzahllinien; i++)
                    {
                        if (Vector2.Distance(spieler1linie[i].position, spieler2.position) < linieTexture.Width / 5)
                        {
                            if (spieler1linie[i].farbe == spieler2.farbe)
                                spieler2.amleben = false;
                        }
                    }
                    anzahllinien = spieler2linie.LastIndexOf(spieler2linie.Last<Linie>()) - längelinie;
                    for (int i = 0; i < anzahllinien; i++)
                    {
                        spieler2linie.RemoveAt(i);
                    }
                    anzahlschritte--;
                }////////////////////////////
            }
            if (spieler1.amleben == false || spieler2.amleben == false)
            {
                if (spieler1.amleben == false)
                {
                    spieler1.farbe = Color.Black;
                    spieler2punkte++;
                }
                if (spieler2.amleben == false)
                {
                    spieler2.farbe = Color.Black;
                    spieler1punkte++;
                }
                InitGame();
            }
        }
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            if (keybState.IsKeyDown(Keys.Up) && spieler1.richtung.Length() < maximalegeschwindigkeit)
                spieler1.richtung += Vector2.Normalize(spieler1.richtung) * beschleunigung;
            if (keybState.IsKeyDown(Keys.Down) && spieler1.richtung.Length() > minimalegeschwindigkeit)
                spieler1.richtung -= Vector2.Normalize(spieler1.richtung) * beschleunigung;
            if (keybState.IsKeyDown(Keys.Right))
                spieler1.richtung = Vector2.Transform(spieler1.richtung, Matrix.CreateRotationZ(wendewinkel));
            if (keybState.IsKeyDown(Keys.Left))
                spieler1.richtung = Vector2.Transform(spieler1.richtung, Matrix.CreateRotationZ(-wendewinkel));

            if (keybState.IsKeyDown(Keys.W) && spieler2.richtung.Length() < maximalegeschwindigkeit)
                spieler2.richtung += Vector2.Normalize(spieler2.richtung) * beschleunigung;
            if (keybState.IsKeyDown(Keys.S) && spieler2.richtung.Length() > minimalegeschwindigkeit)
                spieler2.richtung -= Vector2.Normalize(spieler2.richtung) * beschleunigung;
            if (keybState.IsKeyDown(Keys.D))
                spieler2.richtung = Vector2.Transform(spieler2.richtung, Matrix.CreateRotationZ(wendewinkel));
            if (keybState.IsKeyDown(Keys.A))
                spieler2.richtung = Vector2.Transform(spieler2.richtung, Matrix.CreateRotationZ(-wendewinkel));

            if (keybState.IsKeyDown(Keys.Escape))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin();
            DrawHintergrund();
            DrawLinie();
            DrawSpieler();
            DrawLevel();
            DrawText();
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void DrawText()
        {
            spriteBatch.DrawString(font, "Spieler1: " + spieler1punkte.ToString(), new Vector2(80, 10), spieler1.farbe);
            spriteBatch.DrawString(font, "Spieler2: " + spieler2punkte.ToString(), new Vector2(620, 10), spieler2.farbe);
        }
        private void DrawLinie()
        {
            foreach (Linie l in spieler1linie)
            {
                spriteBatch.Draw(linieTexture, l.position, null, l.farbe, 0, new Vector2(spielerTexture.Width / 2, spielerTexture.Height / 2), 0.2f, SpriteEffects.None, 1);
            }
            foreach (Linie l in spieler2linie)
            {
                spriteBatch.Draw(linieTexture, l.position, null, l.farbe, 0, new Vector2(spielerTexture.Width / 2, spielerTexture.Height / 2), 0.2f, SpriteEffects.None, 1);
            }
        }
        private void DrawHintergrund()
        {
            spriteBatch.Draw(hintergrundTexture, new Vector2(0,0), null, Color.White,0, new Vector2(0,0), 1f, SpriteEffects.None, 1);
        }
        private void DrawLevel()
        {
            spriteBatch.Draw(levelTexture, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
        }
        private void DrawSpieler()
        {
            spriteBatch.Draw(spielerTexture, spieler1.position, null, spieler1.farbe, (float)(Math.Atan2(spieler1.richtung.Y, spieler1.richtung.X) + Math.PI / 2), new Vector2(spielerTexture.Width / 2, spielerTexture.Height / 2), 1f, SpriteEffects.None, 1);
            spriteBatch.Draw(spielerTexture, spieler2.position, null, spieler2.farbe, (float)(Math.Atan2(spieler2.richtung.Y, spieler2.richtung.X) + Math.PI / 2), new Vector2(spielerTexture.Width / 2, spielerTexture.Height / 2), 1f, SpriteEffects.None, 1);
        }

    }
}
