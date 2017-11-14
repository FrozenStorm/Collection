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

namespace Maze_Generator
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D Maptexture;
        Rectangle screenRectangle;

        int screenWidth;
        int screenHeight;
        int mapWidth;
        int mapHeight;
        /*
        int wand = 50;
        int weg = 10;
        int wegbesucht = 0;
        int Spieler = 40;
        int spielerBesucht = 30;
         * 
        0=Wand
        1=keine Wand
        2=Weg
        3=Weg besucht
        4=Spieler
        5=Spieler besucht richtiger Weg
        6=Spieler besucht falscher Weg
        */
        bool finish;
        bool ki;
        bool ki_state;
        int[,] Map;
        Color[] Mapprint;
        Vector2 vorheriger;
        List<Vector2> way = new List<Vector2>();
        List<Vector2> nachbaren = new List<Vector2>();
        Random myrandom = new Random();

        Vector2 Player;

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
            Window.Title = "Maze Generator";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth  = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            mapWidth = 100;
            mapHeight = 100;
            Maptexture = new Texture2D(device, mapWidth, mapHeight, false, SurfaceFormat.Color);
            Map = new int[mapWidth, mapHeight];
            Mapprint = new Color[mapWidth * mapHeight];
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            LoadMap();
        }

        private void LoadMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    Map[x, y] = 0;
                }
            }
            for (int x = 2; x < mapWidth-2; x+=2)
            {
                for (int y = 2; y < mapHeight-2; y+=2)
                {
                    Map[x, y] = 2;
                }
            }

            way.Clear();
            
            //Easy
            /*
            Map[2, 2] = 3;
            way.Add(new Vector2(2, 2)); 
            Map[mapWidth - 2, mapHeight - 4] = 3;
            Map[mapWidth - 3, mapHeight - 4] = 3;
            */ 
            //Hard
            Map[mapWidth - 4, mapHeight - 4] = 3;
            way.Add(new Vector2(mapWidth - 4, mapHeight - 4));
            Map[mapWidth - 2, mapHeight - 4] = 3;
            Map[mapWidth - 3, mapHeight - 4] = 3;

            finish = false;
            ki = false;
            MaptoTexture();
        }

        private void MaptoTexture()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (Map[x, y] == 0) Mapprint[x + y * mapWidth] = Color.White;
                    else Mapprint[x + y * mapWidth] = Color.Red;
                    if (Map[x, y] == 4) Mapprint[x + y * mapWidth] = Color.Green;
                    if (Map[x, y] == 5) Mapprint[x + y * mapWidth] = Color.Orange;
                    if (Map[x, y] == 6) Mapprint[x + y * mapWidth] = Color.Gray;
                }
            }
            GraphicsDevice.Textures[0] = null;
            Maptexture.SetData(Mapprint);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if(finish==false)Generator();
            else ProcessKeyboard();
            base.Update(gameTime);
        }

        private void Generator()
        {
            nachbaren.Clear();
            if (Map[(int)way.Last<Vector2>().X + 2, (int)way.Last<Vector2>().Y] == 2) nachbaren.Add(new Vector2(way.Last<Vector2>().X + 2, way.Last<Vector2>().Y));
            if (Map[(int)way.Last<Vector2>().X - 2, (int)way.Last<Vector2>().Y] == 2) nachbaren.Add(new Vector2(way.Last<Vector2>().X - 2, way.Last<Vector2>().Y));
            if (Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 2] == 2) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y + 2));
            if (Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 2] == 2) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y - 2));

            if ((int)nachbaren.LongCount<Vector2>() == 0)
            {
                way.Remove(way.Last<Vector2>());
                if ((int)way.LongCount<Vector2>() == 0)
                {
                    way.Clear();
                    Map[1, 2] = 4;
                    way.Add(new Vector2(1, 2));
                    finish = true;
                }
                else Generator();
            }
            else
            {
                vorheriger = way.Last<Vector2>();
                way.Add(nachbaren[myrandom.Next((int)nachbaren.LongCount<Vector2>())]);
                Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 3;
                Map[(int)(((way.Last<Vector2>().X - vorheriger.X) / 2) + vorheriger.X), (int)(((way.Last<Vector2>().Y - vorheriger.Y) / 2) + vorheriger.Y)] = 3;
            }
            MaptoTexture();
        }

        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (ki == false)
            {
                if (keybState.IsKeyDown(Keys.Right))
                {
                    if (Map[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y] > 0)
                    {
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 5;
                        way.Add(new Vector2((int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y));
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 4;
                    }
                }
                if (keybState.IsKeyDown(Keys.Left))
                {
                    if(Map[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y]>0)
                    {
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 5;
                        way.Add(new Vector2((int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y));
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 4;
                    }
                }
                if (keybState.IsKeyDown(Keys.Up))
                {
                    if (Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] > 0)
                    {
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 5;
                        way.Add(new Vector2((int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1));
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 4;
                    }
                }
                if (keybState.IsKeyDown(Keys.Down))
                {
                    if (Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1]>0)
                    {
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 5;
                        way.Add(new Vector2((int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1));
                        Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 4;
                    }
                }
            }
            else
            {
                nachbaren.Clear();
                if (Map[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y] > 0 && Map[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y]<5) nachbaren.Add(new Vector2(way.Last<Vector2>().X + 1, way.Last<Vector2>().Y));
                if (Map[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y] > 0 && Map[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y]<5) nachbaren.Add(new Vector2(way.Last<Vector2>().X - 1, way.Last<Vector2>().Y));
                if (Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1] > 0 && Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1]<5) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y + 1));
                if (Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] > 0 && Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] <5) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y - 1));

                if ((int)nachbaren.LongCount<Vector2>() == 0)
                {
                    Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 6;
                    way.Remove(way.Last<Vector2>());
                    if ((int)way.LongCount<Vector2>() == 0)
                    {
                        LoadMap();
                    }
                    Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 4;
                }
                else
                {
                    Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 5;
                    way.Add(nachbaren[myrandom.Next((int)nachbaren.LongCount<Vector2>())]);
                    Map[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = 4;
                }
                if (way.Last<Vector2>() == new Vector2(mapWidth - 3, mapHeight - 4)) ki=false;
                MaptoTexture();
            }
            if (keybState.IsKeyDown(Keys.Space)) ki_state = true;
            if (keybState.IsKeyUp(Keys.Space) && ki_state == true)
            {
                ki_state = false;
                ki = !ki;
            }
            if (keybState.IsKeyDown(Keys.Enter)) LoadMap();
            if (way.Last<Vector2>() == new Vector2(mapWidth - 2, mapHeight - 4)) LoadMap();
            MaptoTexture();
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            DrawMap();
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawMap()
        {
            spriteBatch.Draw(Maptexture, screenRectangle, Color.White);
        }
    }
}
