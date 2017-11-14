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

namespace Gravitation
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public struct S_Planeten
    {
        public Vector2 position;
        public float masse;
        public Vector2 geschwindikeit;
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D planetenTexture;
        Texture2D backgroundTexture;

        int screenWidth;
        int screenHeight;

        public List<S_Planeten> planeten = new List<S_Planeten>();
        float gravitationskonstante=6.674f;
        float geschwindikeitsverlustimraum = 1.001f;
        float maxgeschwindikeit = 20;
        int farbewechsel = 0;
        bool hochrunter = false;
        int r=255;
        int g=255;
        int b=255;

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
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Window.Title = "Gravitation";
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
            planetenTexture = Content.Load<Texture2D>("Plasma Weiss");
            backgroundTexture = Content.Load<Texture2D>("Plasma Hintergrund");

            setplanet();
        }
        private void setplanet()
        {
            S_Planeten planet= new S_Planeten();

            planet.masse = 1f;
            planet.position = new Vector2(screenWidth / 2, screenHeight / 2);
            planet.geschwindikeit = new Vector2(0, 0);
            planeten.Add(planet);

            for (int i = 15; i > 1; i--)
            {
                planet.masse = 1f;
                planet.position = new Vector2(screenWidth / i, screenHeight / 2);
                planet.geschwindikeit = new Vector2(0, 0);
                planeten.Add(planet);
            }
            for (int i = 50; i > 1; i--)
            {
                planet.masse = 0.5f;
                planet.position = new Vector2(screenWidth / 2, screenHeight / i);
                planet.geschwindikeit = new Vector2(0, 2);
                planeten.Add(planet);
            }
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
            Updateplaneten();
            ChangeColor();
            base.Update(gameTime);
        }
        private void ChangeColor()
        {
            farbewechsel++;
            if (farbewechsel > 2)
            {
                farbewechsel = 0;
                if (hochrunter == false)
                {
                    if (r < 255) r++;
                    if (r > 254 && g < 255) g++;
                    if (g > 254 && b < 255) b++;
                    if (g > 254 && r > 254 && b > 254)
                    {
                        hochrunter = true;
                    }
                }
                else
                {
                    if (r > 10) r--;
                    if (r < 11 && g > 10) g--;
                    if (g < 11 && b > 10) b--;
                    if (g < 11 && r < 11 && b < 11)
                    {
                        hochrunter = false;
                    }
                }
            }
        }
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            if (keybState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
        }
        private void Updateplaneten()
        {
            float winkelzwischenobjekten;
            Vector2 gravitation;
            S_Planeten planet;
            for (int i = planeten.IndexOf(planeten.Last<S_Planeten>()); i > 0; i--)
            {
                planet = planeten[i];
                foreach (S_Planeten p_other in planeten)
                {
                    if (planet.position != p_other.position)
                    {
                        winkelzwischenobjekten = (float)Math.Atan2(planet.position.X - p_other.position.X, -planet.position.Y + p_other.position.Y);
                        gravitation = new Vector2(0, (float)(gravitationskonstante * p_other.masse / Vector2.Distance(planet.position, p_other.position)));
                        Matrix rotMatrix = Matrix.CreateRotationZ(winkelzwischenobjekten);
                        gravitation = Vector2.Transform(gravitation, rotMatrix);
                        planet.geschwindikeit += gravitation;
                    }
                }
                planet.geschwindikeit = Vector2.Divide(planet.geschwindikeit, geschwindikeitsverlustimraum);
                if (planet.geschwindikeit.Length() > maxgeschwindikeit) planet.geschwindikeit = planet.geschwindikeit / planet.geschwindikeit.Length() * maxgeschwindikeit;
                planet.position += planet.geschwindikeit;
                if (planet.position.Y > screenHeight) planet.geschwindikeit.Y = -planet.geschwindikeit.Y;
                if (planet.position.Y < 0) planet.geschwindikeit.Y = -planet.geschwindikeit.Y;
                if (planet.position.X > screenWidth) planet.geschwindikeit.X = -planet.geschwindikeit.X;
                if (planet.position.X < 0) planet.geschwindikeit.X = -planet.geschwindikeit.X;
                planeten[i] = planet;
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
            DrawBackground();
            
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            DrawPlaneten();
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void DrawBackground()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
        }

        private void DrawPlaneten()
        {
            for (int i = planeten.IndexOf(planeten.Last<S_Planeten>()); i > 0; i--)
            {
                spriteBatch.Draw(planetenTexture, planeten[i].position, null, new Color(r,g,b), 0, new Vector2(planetenTexture.Width / 2, planetenTexture.Height / 2), planeten[i].masse, SpriteEffects.None, 1);
            }
        }

    }
}
