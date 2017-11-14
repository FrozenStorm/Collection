using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tileset
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
        int tileHeight = 12;
        int tileWidth = 12;
        int tilekorrektur = 3;
        List<Rectangle> tileRectangles;
        int tile=0;
        int[,] map = 
        {
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,34,34,34,34,34,34,},
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,53,54,42,42,42,53,},
        {22,22,22,22,18,18,18,18,18,18,22,22,22,22,65,66,42,42,42,65,},
        {22,22,22,22,17,17,17,17,17,17,22,22,22,22,47,47,47,47,47,47,},
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,51,51,51,51,51,51,},
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,101,101,101,101,101,101,},
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,77,77,77,77,77,78,},
        {22,22,22,22,22,22,22,22,0,18,2,22,22,22,118,140,140,140,119,90,},
        {22,22,22,22,22,22,22,22,12,30,14,22,22,22,129,120,118,119,127,90,},
        {22,22,22,22,22,22,22,22,24,25,26,22,22,22,118,119,130,131,127,90,},
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,130,125,119,116,131,90,},
        {22,22,22,22,22,22,22,22,22,22,22,22,22,22,28,130,131,28,28,90,},
        {108,108,108,108,108,108,108,108,108,108,108,108,108,108,28,28,28,28,28,90,},
        {101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,102,},
        {10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,},
        {34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,},
        {63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,},
        {113,113,113,113,113,113,113,113,113,113,113,113,113,113,113,113,113,113,113,113,},
        }; 


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            this.IsMouseVisible = true;
            Window.Title = "Tileset";
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            tilesetTexture = Content.Load<Texture2D>("tileset map");
            tileRectangles = new List<Rectangle>();
            tileHeightInImage = tilesetTexture.Height / tileHeight;
            tileWidthInImage = tilesetTexture.Width / tileWidth;
            LoadTiles();
        }
        private void LoadTiles()
        {
            Rectangle newRectangle = new Rectangle(0, 0, tileWidthInImage - tilekorrektur, tileHeightInImage - tilekorrektur);

            for (int y = 0; y < tileHeight; y++)
            {
                for (int x = 0; x < tileWidth; x++)
                {
                    newRectangle.X = x * tileWidthInImage + tilekorrektur;
                    newRectangle.Y = y * tileHeightInImage + tilekorrektur;
                    tileRectangles.Add(newRectangle);
                }
            }
        }
        private void SaveArrayToFile(int[,] myarray)
        {
            FileStream fi;
            fi = new FileStream("C:/Documents and Settings/nzwygd/My Documents/My Dropbox/Work/Programmieren/Collection/Tileset/TilesetContent/map.txt", FileMode.Create);
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
            base.Update(gameTime);
        }

        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mousState = Mouse.GetState();
            if (keybState.IsKeyDown(Keys.LeftControl) && keybState.IsKeyDown(Keys.S)) SaveArrayToFile(map);
            if (mousState.Y > 0 && mousState.Y < tilesetTexture.Height / 2 && mousState.X > (map.GetLength(1) * (tileWidthInImage - 2 * tilekorrektur) + 10) && mousState.X < (map.GetLength(1) * (tileWidthInImage - 2 * tilekorrektur) + 10 + tilesetTexture.Width / 2) && mousState.LeftButton == ButtonState.Pressed)
            {
                tile = (mousState.X - (map.GetLength(1) * (tileWidthInImage - 2 * tilekorrektur) + 10)) / (tileWidthInImage / 2);
                tile += mousState.Y / (tileHeightInImage / 2) * 12;
                if (tile > tileRectangles.LastIndexOf(tileRectangles.Last<Rectangle>())) tile=0;
            }

            if (mousState.Y > 0 && mousState.Y < (map.GetLength(0) * (tileHeightInImage - 2 * tilekorrektur)) && mousState.X > 0 && mousState.X < (map.GetLength(1) * (tileWidthInImage - 2 * tilekorrektur)) && mousState.LeftButton==ButtonState.Pressed)
            {
                map[mousState.Y / (tileHeightInImage - 2 * tilekorrektur), mousState.X / (tileWidthInImage - 2 * tilekorrektur)] = tile;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            DrawMap();
            DrawTileset();
            DrawTile();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void DrawTileset()
        {
            spriteBatch.Draw(tilesetTexture, new Vector2((map.GetLength(1) * (tileWidthInImage - 2 * tilekorrektur))+10, 0), new Rectangle(0, 0, tilesetTexture.Width, tilesetTexture.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }
        private void DrawTile()
        {
            spriteBatch.Draw(tilesetTexture, new Vector2((map.GetLength(1) * (tileWidthInImage - 2 * tilekorrektur))+35, tilesetTexture.Height/2 + 25), tileRectangles[tile], Color.White);
        }
        private void DrawMap()
        {
            Vector2 position = new Vector2(0, 0);
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    position.X = x * (tileWidthInImage - 2 * tilekorrektur);
                    position.Y = y * (tileHeightInImage - 2 * tilekorrektur);
                    spriteBatch.Draw(tilesetTexture, position, tileRectangles[map[y, x]], Color.White);
                }
            }
        }
    }
}
