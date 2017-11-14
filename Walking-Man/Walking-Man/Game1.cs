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

namespace Walking_Man
{
    public struct WalkingMan
    {
        public Vector2 position;
        public int geschwindikeit;
        public int richtung;
        public int texturschritt;
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Rectangle screenRectangle;
        Texture2D Walkingmantexture;
        Texture2D Firetexture;

        int screenWidth;
        int screenHeight;
        int WalkingmantextureWidth;
        int WalkingmantextureHeight;

        WalkingMan Player_1 = new WalkingMan();
        int z = 0;
        float abweichung = 15f;
        bool walk = false;

        int fire_x;
        int fire_y;
        int fire_z;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Walkin-Man";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            Walkingmantexture = Content.Load<Texture2D>("Spires_America_Hero_Stephen_Colbert");
            WalkingmantextureWidth = Walkingmantexture.Width / 8;
            WalkingmantextureHeight = Walkingmantexture.Height / 8;

            Firetexture = Content.Load<Texture2D>("fireloopsheetmarked");
            fire_x = 0;
            fire_y = 0;
            fire_z = 0;

            LoadPlayer();
        }

        private void LoadPlayer()
        {
            Player_1.geschwindikeit = 1;
            Player_1.position = new Vector2(0, 0);
            Player_1.richtung = 4;
            Player_1.texturschritt = 0;
        }

        protected override void UnloadContent()
        {
        }

        private Texture2D Color2Dtotexture(Color[,] color2D)
        {
            int width = color2D.GetLength(0);
            int height = color2D.GetLength(1);
            Color[] color1D = new Color[width * height];
            Texture2D neutexture = new Texture2D(device, width, height, false, SurfaceFormat.Color);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    color1D[x + y * width] = color2D[x, y];
                }
            }
            neutexture.SetData(color1D);
            return neutexture;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ProcessKeyboard();
            UpdatePlayer();
            base.Update(gameTime);
        }
        //Mehr überleben
        private void UpdatePlayer()
        {
            if (walk)
            {
                Player_1.position += Player_1.geschwindikeit * Vector2.Transform((new Vector2(0, -1)), Matrix.CreateRotationZ(MathHelper.ToRadians((float)((360 / 8) * Player_1.richtung))));
            }
        }
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            walk = false;
            if(keybState.IsKeyDown(Keys.Up)||keybState.IsKeyDown(Keys.Right)||keybState.IsKeyDown(Keys.Down)||keybState.IsKeyDown(Keys.Left))walk=true;
            if (keybState.IsKeyDown(Keys.Up)) Player_1.richtung = 0;
            if (keybState.IsKeyDown(Keys.Right)) Player_1.richtung = 2;
            if (keybState.IsKeyDown(Keys.Down)) Player_1.richtung = 4;
            if (keybState.IsKeyDown(Keys.Left)) Player_1.richtung = 6;
            if (keybState.IsKeyDown(Keys.Up) && keybState.IsKeyDown(Keys.Right)) Player_1.richtung = 1;
            if (keybState.IsKeyDown(Keys.Right) && keybState.IsKeyDown(Keys.Down)) Player_1.richtung = 3;
            if (keybState.IsKeyDown(Keys.Down) && keybState.IsKeyDown(Keys.Left)) Player_1.richtung = 5;
            if (keybState.IsKeyDown(Keys.Left) && keybState.IsKeyDown(Keys.Up)) Player_1.richtung = 7;
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            DrawFire();
            DrawMan();
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void DrawFire()
        {
            spriteBatch.Draw(Firetexture, new Vector2(0, 0), new Rectangle(fire_x * 75, fire_y * 75, 75, 75), Color.White);
            fire_z++;
            if (fire_z % 5 == 0)
            {
                if (fire_x == 3)
                {
                    fire_x = 0;
                    if (fire_y == 3)
                    {
                        fire_y = 0;
                    }
                    else
                    {
                        fire_y++;
                    }
                }
                else
                {
                    fire_x++;
                }
            }
        }
        private void DrawMan()
        {
            if (walk)
            {
                z++;
                if (z % (abweichung / Player_1.geschwindikeit) == 0)
                {
                    Player_1.texturschritt++;
                    if (Player_1.texturschritt == 8)
                    {
                        Player_1.texturschritt = 0;
                    }
                    spriteBatch.Draw(Walkingmantexture, Player_1.position, new Rectangle(Player_1.texturschritt * WalkingmantextureWidth, Player_1.richtung * WalkingmantextureHeight, WalkingmantextureWidth, WalkingmantextureHeight), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Walkingmantexture, Player_1.position, new Rectangle(Player_1.texturschritt * WalkingmantextureWidth, Player_1.richtung * WalkingmantextureHeight, WalkingmantextureWidth, WalkingmantextureHeight), Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(Walkingmantexture, Player_1.position, new Rectangle(Player_1.texturschritt * WalkingmantextureWidth, Player_1.richtung * WalkingmantextureHeight, WalkingmantextureWidth, WalkingmantextureHeight), Color.White);
            }
        }
    }
}
