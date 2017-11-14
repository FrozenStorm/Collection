using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2D_Game
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Rectangle screenRectangle;
        int screenWidth;
        int screenHeight;

        Texture2D tilesetTexture;
        int tileHeightInImage;
        int tileWidthInImage;
        int tileHeight = 1;
        int tileWidth = 5;
        List<Rectangle> tileRectangles;

        int[,] map = new int[200, 200];
        float scale = 1f;

        List<Vector2> Spielerlist = new List<Vector2>();

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
            this.IsMouseVisible = true;
            Window.Title = "2D-Game";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            tilesetTexture = Content.Load<Texture2D>("Sprites");
            tileRectangles = new List<Rectangle>();
            tileHeightInImage = tilesetTexture.Height / tileHeight;
            tileWidthInImage = tilesetTexture.Width / tileWidth;
            
            LoadTiles();
            LoadMap();
            LoadSpieler();

            scale = (float)screenHeight / (tileHeightInImage * map.GetLength(1));
        }
        private void LoadSpieler()
        {
            for (int x = 1; x < 5; x++)
            {
                Spielerlist.Add(new Vector2(map.GetLength(1) / x, 0));
            }
        }
        private void LoadTiles()
        {
            Rectangle newRectangle = new Rectangle(0, 0, tileWidthInImage, tileHeightInImage);

            for (int y = 0; y < tileHeight; y++)
            {
                for (int x = 0; x < tileWidth; x++)
                {
                    newRectangle.X = x * tileWidthInImage;
                    newRectangle.Y = y * tileHeightInImage;
                    tileRectangles.Add(newRectangle);
                }
            }
        }
        private void LoadMap()
        {
            Random myrand = new Random();
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    //map[y, x] = myrand.Next(tileHeight * tileWidth);
                    map[y, x] = 0;
                }
            }
        }
        private void SaveArrayToFile(int[,] myarray)
        {
            FileStream fi;
            fi = new FileStream("C:/Documents and Settings/nzwygd/My Documents/My Dropbox/Work/Programmieren/Collection/2D-Game/2D-GameContent/map.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fi);
            sw.WriteLine(myarray.GetLength(1));
            sw.WriteLine(myarray.GetLength(0));
            for (int y = 0; y < myarray.GetLength(0); y++)
            {
                sw.Write("{");
                for (int x = 0; x < myarray.GetLength(1); x++)
                {
                    sw.Write(myarray[y, x]);
                    sw.Write(",");
                }
                sw.WriteLine("},");
            }
            sw.Close();
            fi.Close();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ProcessKeyboard();
            foreach (Vector2 s in Spielerlist)
            {
                Weg(s, 5 % (Spielerlist.IndexOf(s) + 1) +1);
            }
            base.Update(gameTime);
        }
        private Vector2 Weg(Vector2 Spieler, int Spielerfarbe)
        {
            Random myrand = new Random();
            bool done = false;
            if (Spieler != new Vector2(map.GetLength(0) - 1, map.GetLength(1) - 1))
            {
                switch (myrand.Next(4))
                {
                    case 0:
                        if (Spieler.X + 1 < map.GetLength(1) && map[(int)Spieler.Y, (int)Spieler.X + 1] == 0)
                        {
                            Spieler.X += 1;
                            map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            done = true;
                        }
                        break;
                    case 1:
                        if (Spieler.X - 1 > -1 && map[(int)Spieler.Y, (int)Spieler.X - 1] == 0)
                        {
                            Spieler.X -= 1;
                            map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            done = true;
                        }
                        break;
                    case 2:
                        if (Spieler.Y + 1 < map.GetLength(0) && map[(int)Spieler.Y + 1, (int)Spieler.X] == 0)
                        {
                            Spieler.Y += 1;
                            map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            done = true;
                        }
                        break;
                    case 3:
                        if (Spieler.Y - 1 > -1 && map[(int)Spieler.Y - 1, (int)Spieler.X] == 0)
                        {
                            Spieler.Y -= 1;
                            map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            done = true;
                        }
                        break;
                }
            }
            else
            {
                map[(int)Spieler.Y, (int)Spieler.X] = 3;
            }
            while (done == false)
            {
                switch (myrand.Next(4))
                {
                    case 0:
                        if (Spieler.X + 1 < map.GetLength(1))
                        {
                            Spieler.X += 1;
                            if (map[(int)Spieler.Y, (int)Spieler.X] == 0)
                            {
                                done = true;
                                map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            }
                        }
                        break;
                    case 1:
                        if (Spieler.X - 1 > -1)
                        {
                            Spieler.X -= 1;
                            if (map[(int)Spieler.Y, (int)Spieler.X] == 0)
                            {
                                done = true;
                                map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            }
                        }
                        break;
                    case 2:
                        if (Spieler.Y + 1 < map.GetLength(0))
                        {
                            Spieler.Y += 1;
                            if (map[(int)Spieler.Y, (int)Spieler.X] == 0)
                            {
                                done = true;
                                map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            }
                        }
                        break;
                    case 3:
                        if (Spieler.Y - 1 > -1)
                        {
                            Spieler.Y -= 1;
                            if (map[(int)Spieler.Y, (int)Spieler.X] == 0)
                            {
                                done = true;
                                map[(int)Spieler.Y, (int)Spieler.X] = Spielerfarbe;
                            }
                        }
                        break;
                }
            }
            return Spieler;
        }
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mousState = Mouse.GetState();
            if (keybState.IsKeyDown(Keys.LeftControl) && keybState.IsKeyDown(Keys.S)) SaveArrayToFile(map);
        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            DrawMap();
            DrawSpieler();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void DrawSpieler()
        {
            foreach (Vector2 s in Spielerlist)
            {
                spriteBatch.Draw(tilesetTexture, new Vector2(s.X * tileWidthInImage * scale, s.Y * tileHeightInImage * scale), tileRectangles[5 % (Spielerlist.IndexOf(s) + 1) + 1], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
            }
        }
        private void DrawMap()
        {
            Vector2 position = new Vector2(0, 0);
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    position.X = x * tileWidthInImage * scale;
                    position.Y = y * tileHeightInImage * scale;
                    spriteBatch.Draw(tilesetTexture, position, tileRectangles[map[y, x]], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
                }
            }
        }
    }
}
