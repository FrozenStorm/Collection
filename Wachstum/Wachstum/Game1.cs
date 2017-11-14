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

namespace Wachstum
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
        int MapWidth;
        int MapHeight;

        Color[,] Map;
        Color[,] Mapnew;
        Random myrandom = new Random();
        int bla = 0;
        int geschwindikeit = 20;
        int mode = 0;

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
            Window.Title = "Wachstum";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            MapHeight = 200;
            MapWidth = 200;

            Maptexture = new Texture2D(device, MapWidth, MapHeight, false, SurfaceFormat.Color);
            Map = new Color[MapWidth, MapHeight];
            Mapnew = new Color[MapWidth, MapHeight];
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            LoadMap();
        }

        private void LoadMap()
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    Map[x, y] = Color.Black;
                    Mapnew[x, y] = Color.Black;
                }
            }
            Maptexture = Color2Dtotexture(Map);
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
            
            bla++;
            if (bla % geschwindikeit == 0)
            {
                switch (mode)
                {
                    case 0:
                        ProcessKeyboard1();
                        UpdateWachstumMode1();
                        break;
                    case 1:
                        ProcessKeyboard2();
                        UpdateWachstumMode2();
                        break;
                    case 2:
                        ProcessKeyboard2();
                        UpdateWachstumMode3();
                        break;
                }
            }
            base.Update(gameTime);
        }
//Mehr überleben
        private void UpdateWachstumMode1()
        {
            Color[] angrenzendefelder = new Color[8];
            Color[] myColors = new Color[9];
            int random8;
            int countnotblack;
            int countred;
            int countblue;
            int countgreen;
            int countyellow;
            for (int x = 1; x + 1 < MapWidth; x++)
            {
                for (int y = 1; y + 1 < MapHeight; y++)
                {//10 und kein +1 für voll und 8 und +1 für klein
                    countnotblack = 0;
                    countred = 0;
                    countblue = 0;
                    countgreen = 0;
                    countyellow = 0;
                    myColors[0] = Map[x, y];
                    myColors[1] = Map[x + 1, y];
                    myColors[2] = Map[x + 1, y + 1];
                    myColors[3] = Map[x, y + 1];
                    myColors[4] = Map[x - 1, y + 1];
                    myColors[5] = Map[x - 1, y];
                    myColors[6] = Map[x - 1, y - 1];
                    myColors[7] = Map[x, y - 1];
                    myColors[8] = Map[x + 1, y - 1];
                    for (int z = 0; z < 9; z++)
                    {
                        if (myColors[z] != Color.Black) countnotblack++;
                        if (myColors[z] == Color.Red) countred++;
                        if (myColors[z] == Color.Blue) countblue++;
                        if (myColors[z] == Color.Green) countgreen++;
                        if (myColors[z] == Color.Yellow) countyellow++;
                    }
                    if (Map[x, y] == Color.Black)
                    {//countnotblack 0-8
                        random8 = myrandom.Next(8);
                        if (countnotblack >= random8 + 1)
                        {
                            if (countred > countyellow && countred > countblue && countred > countgreen)
                            {
                                Mapnew[x, y] = Color.Red;
                            }
                            if (countyellow > countred && countyellow > countblue && countyellow > countgreen)
                            {
                                Mapnew[x, y] = Color.Yellow;
                            }
                            if (countblue > countyellow && countblue > countred && countblue > countgreen)
                            {
                                Mapnew[x, y] = Color.Blue;
                            }
                            if (countgreen > countyellow && countgreen > countblue && countgreen > countred)
                            {
                                Mapnew[x, y] = Color.Green;
                            }
                        }
                        else
                        {
                            Mapnew[x, y] = Color.Black;
                        }
                    }
                    else
                    {//Countnotblack 0-8
                        countnotblack--;
                        
                        random8 = myrandom.Next(10);
                        if (countnotblack >= random8)
                        {
                            if (countred > countyellow && countred > countblue && countred > countgreen)
                            {
                                Mapnew[x, y] = Color.Red;
                            }
                            if (countyellow > countred && countyellow > countblue && countyellow > countgreen)
                            {
                                Mapnew[x, y] = Color.Yellow;
                            }
                            if (countblue > countyellow && countblue > countred && countblue > countgreen)
                            {
                                Mapnew[x, y] = Color.Blue;
                            }
                            if (countgreen > countyellow && countgreen > countblue && countgreen > countred)
                            {
                                Mapnew[x, y] = Color.Green;
                            }
                        }
                        else
                        {
                            Mapnew[x, y] = Color.Black;
                        }
                    }

                }
            }
            Array.Copy(Mapnew, Map, Mapnew.Length);
            Maptexture = Color2Dtotexture(Map);
        }
//Eher sterben
        private void UpdateWachstumMode2()
        {
            Color[] angrenzendefelder=new Color[8];
            int random8;
            int count;
            for (int x = 1; x + 1 < MapWidth; x++)
            {
                for (int y = 1; y + 1 < MapHeight; y++)
                {//10 und kein +1 für voll und 8 und +1 für klein
                    random8 = myrandom.Next(8);
                    count = 0;
                    if (Map[x + 1, y] == Color.White) count++;
                    if (Map[x + 1, y + 1] == Color.White) count++;
                    if (Map[x, y + 1] == Color.White) count++;
                    if (Map[x - 1, y + 1] == Color.White) count++;
                    if (Map[x - 1, y] == Color.White) count++;
                    if (Map[x - 1, y - 1] == Color.White) count++;
                    if (Map[x, y - 1] == Color.White) count++;
                    if (Map[x + 1, y - 1] == Color.White) count++;

                    if (count < random8 + 1) //wenn alle acht weiis wieder schwarz wäre auch noch möglich
                    {
                        Mapnew[x, y] = Color.Black;
                    }
                    else
                    {
                        Mapnew[x, y] = Color.White;
                    }
                }

            }
            Array.Copy(Mapnew, Map, Mapnew.Length);
            Maptexture = Color2Dtotexture(Map);
        }
//Ausdehnung
        private void UpdateWachstumMode3()
        {
            Color[] angrenzendefelder = new Color[8];
            int random8;
            int count;
            for (int x = 1; x + 1 < MapWidth; x++)
            {
                for (int y = 1; y + 1 < MapHeight; y++)
                {//10 und kein +1 für voll und 8 und +1 für klein
                    random8 = myrandom.Next(8);
                    count = 0;
                    if (Map[x + 1, y] == Color.White) count++;
                    if (Map[x + 1, y + 1] == Color.White) count++;
                    if (Map[x, y + 1] == Color.White) count++;
                    if (Map[x - 1, y + 1] == Color.White) count++;
                    if (Map[x - 1, y] == Color.White) count++;
                    if (Map[x - 1, y - 1] == Color.White) count++;
                    if (Map[x, y - 1] == Color.White) count++;
                    if (Map[x + 1, y - 1] == Color.White) count++;

                    if (Map[x, y] == Color.White)
                    {

                    }
                    else
                    {
                        if (count >= random8 + 1) //wenn alle acht weiis wieder schwarz wäre auch noch möglich
                        {
                            Mapnew[x, y] = Color.White;
                        }
                    }
                }

            }
            Array.Copy(Mapnew, Map, Mapnew.Length);
            Maptexture = Color2Dtotexture(Map);
        }

        private void ProcessKeyboard1()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (keybState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int newpositionX = myrandom.Next(5, MapWidth - 5);
                int newpositionY = myrandom.Next(5, MapHeight - 5);
                Map[newpositionX, newpositionY] = Color.Red;
                newpositionX = myrandom.Next(5, MapWidth - 5);
                newpositionY = myrandom.Next(5, MapHeight - 5);
                Map[newpositionX, newpositionY] = Color.Blue;
                newpositionX = myrandom.Next(5, MapWidth - 5);
                newpositionY = myrandom.Next(5, MapHeight - 5);
                Map[newpositionX, newpositionY] = Color.Yellow;
                newpositionX = myrandom.Next(5, MapWidth - 5);
                newpositionY = myrandom.Next(5, MapHeight - 5);
                Map[newpositionX, newpositionY] = Color.Green;
                Array.Copy(Map, Mapnew, Mapnew.Length);
            }
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                LoadMap();
            }
            if (keybState.IsKeyDown(Keys.D1)) geschwindikeit = 5;
            if (keybState.IsKeyDown(Keys.D2)) geschwindikeit = 10;
            if (keybState.IsKeyDown(Keys.D3)) geschwindikeit = 20;
            if (keybState.IsKeyDown(Keys.D4)) geschwindikeit = 40;
            if (keybState.IsKeyDown(Keys.D5)) geschwindikeit = 100;
            if (keybState.IsKeyDown(Keys.D5)) geschwindikeit = 100;
            if (keybState.IsKeyDown(Keys.Q)) mode = 0;
            if (keybState.IsKeyDown(Keys.W)) mode = 1;
            if (keybState.IsKeyDown(Keys.E)) mode = 2;
        }

        private void ProcessKeyboard2()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (keybState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int newpositionX = myrandom.Next(5, MapWidth - 5);
                int newpositionY = myrandom.Next(5, MapHeight - 5);
                Map[newpositionX, newpositionY] = Color.White;
            }
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                LoadMap();
            }
            if (keybState.IsKeyDown(Keys.D1)) geschwindikeit = 5;
            if (keybState.IsKeyDown(Keys.D2)) geschwindikeit = 10;
            if (keybState.IsKeyDown(Keys.D3)) geschwindikeit = 20;
            if (keybState.IsKeyDown(Keys.D4)) geschwindikeit = 40;
            if (keybState.IsKeyDown(Keys.D5)) geschwindikeit = 100;
            if (keybState.IsKeyDown(Keys.Q)) mode = 0;
            if (keybState.IsKeyDown(Keys.W)) mode = 1;
            if (keybState.IsKeyDown(Keys.E)) mode = 2;
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
