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

namespace Stämme
{
    public struct Creature
    {
        public Color type;
        public int age;
        public bool walked;
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D Maptexture;
        Texture2D nexttexture;
        Rectangle screenRectangle;

        int screenWidth;
        int screenHeight;
        int screenWidth_1;
        int screenHeight_1;

        Creature[] Map;
        Color[] Mapprint;

        Random myrandom = new Random();
        int schritte;
        Creature nocreature = new Creature();
        int generationtime = 500;
        int largeofzone = 20;
        int ageofkill = -1;
        bool walker = false;

        int jüngster;
        int ältester;
        int anzahl;

        int gewinner;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Stämme";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = 200;
            screenHeight = 200;
            screenWidth_1 = screenWidth - 1;
            screenHeight_1 = screenHeight - 1;

            Maptexture = new Texture2D(device, screenWidth, screenHeight, false, SurfaceFormat.Color);
            nexttexture = new Texture2D(device, screenWidth, screenHeight, false, SurfaceFormat.Color);
            Map = new Creature[screenWidth * screenHeight];
            Mapprint = new Color[screenWidth * screenHeight];
            screenRectangle = new Rectangle(0, 0, device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight);

            this.IsFixedTimeStep = false;

            LoadMap();
        }

        private void LoadMap()
        {
            nocreature.age = -1;
            nocreature.type = Color.Black;
            nocreature.walked = false;
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    Map[x + y * screenWidth] = nocreature;
                }
            }
            NächsteGeneration(0);
            NächsteGeneration(1);
            NächsteGeneration(2);
            NächsteGeneration(3);
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    Mapprint[x + y * screenWidth] = Map[x + y * screenWidth].type;
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
            schritte++;
            if (schritte % generationtime == 0)
            {
                gewinner=myrandom.Next(4);
            }
            largeofzone = 2;
            NächsteGeneration(gewinner);
            Window.Title = "Schritte: " + schritte.ToString() + "      J:" + jüngster.ToString() + "         Ä:" + ältester.ToString() + "       A:" + anzahl.ToString();
            ProcessKeyboard();
            NächsterZyklus();
            base.Update(gameTime);
        }

        private void NächsteGeneration(int type)
        {
            switch (type)
            {
                case 0:
                    for (int x = screenWidth / 3; x < (screenWidth / 3) + largeofzone; x++)
                    {
                        for (int y = screenWidth / 3; y < (screenWidth / 3) + largeofzone; y++)
                        {
                            if (Map[x + y * screenWidth].type == Color.Black)
                            {
                                Map[x + y * screenWidth] = nocreature;
                                Map[x + y * screenWidth].type = Color.Red;
                                Map[x + y * screenWidth].age = 0;
                            }
                        }
                    }
                    break;
                case 1:
                    for (int x = screenWidth / 3 * 2; x < (screenWidth / 3 * 2) + largeofzone; x++)
                    {
                        for (int y = screenWidth / 3; y < (screenWidth / 3) + largeofzone; y++)
                        {
                            if (Map[x + y * screenWidth].type == Color.Black)
                            {
                                Map[x + y * screenWidth] = nocreature;
                                Map[x + y * screenWidth].type = Color.Blue;
                                Map[x + y * screenWidth].age = 0;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int x = screenWidth / 3 * 2; x < (screenWidth / 3 * 2) + largeofzone; x++)
                    {
                        for (int y = screenWidth / 3 * 2; y < (screenWidth / 3 * 2) + largeofzone; y++)
                        {
                            if (Map[x + y * screenWidth].type == Color.Black)
                            {
                                Map[x + y * screenWidth] = nocreature;
                                Map[x + y * screenWidth].type = Color.Green;
                                Map[x + y * screenWidth].age = 0;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int x = screenWidth / 3; x < (screenWidth / 3) + largeofzone; x++)
                    {
                        for (int y = screenWidth / 3 * 2; y < (screenWidth / 3 * 2) + largeofzone; y++)
                        {
                            if (Map[x + y * screenWidth].type == Color.Black)
                            {
                                Map[x + y * screenWidth] = nocreature;
                                Map[x + y * screenWidth].type = Color.Yellow;
                                Map[x + y * screenWidth].age = 0;
                            }
                        }
                    }
                    break;
            }
            
        }



        private void NächsterZyklus()
        {
            jüngster = 100000;
            ältester = 0;
            anzahl = 0;
            walker = !walker;
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    if (Map[x + y * screenWidth].type != Color.Black && Map[x + y * screenWidth].walked!=walker)
                    {
                        if (Map[x + y * screenWidth].age < jüngster) jüngster = Map[x + y * screenWidth].age;
                        if (Map[x + y * screenWidth].age > ältester) ältester = Map[x + y * screenWidth].age;
                        anzahl++;
                        switch (myrandom.Next(4))
                        {
                            case 0:
                                Walk(x + y * screenWidth, x_test(x + 1) + y_test(y) * screenWidth);
                                break;
                            case 1:
                                Walk(x + y * screenWidth, x_test(x - 1) + y_test(y) * screenWidth);
                                break;
                            case 2:
                                Walk(x + y * screenWidth, x_test(x) + y_test(y + 1) * screenWidth);
                                break;
                            case 3:
                                Walk(x + y * screenWidth, x_test(x) + y_test(y - 1) * screenWidth);
                                break;
                        }
                    }

                }
            }
        }

        private void Walk(int source, int destination)
        {
            Map[source].walked = !Map[source].walked;
            Map[source].age++;
            if (Map[destination].type != Map[source].type)
            {
                if (Map[destination].type == Color.Black)
                {
                    Map[destination] = Map[source];
                    Map[source] = nocreature;
                }
                else
                {
                    if (Map[destination].age > Map[source].age)
                    {
                        Map[source].age += Map[destination].age - Map[source].age;
                        Map[destination] = Map[source];
                        Map[source] = nocreature;
                    }
                }
            }
        }

        private int x_test(int x)
        {
            if (x > screenWidth_1) return x - screenWidth;
            if (x < 0) return screenWidth + x;
            return x;
        }
        private int y_test(int y)
        {
            if (y > screenHeight_1) return y - screenHeight;
            if (y < 0) return screenHeight + y;
            return y;
        }

        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (keybState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (keybState.IsKeyDown(Keys.Space))
            {
                LoadMap();
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {

            }
            if (mouseState.RightButton == ButtonState.Pressed)
            {
        
            }
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
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    Mapprint[x + y * screenWidth] = Map[x + y * screenWidth].type;
                }
            }
            graphics.GraphicsDevice.Textures[0] = null;
            Maptexture.SetData(Mapprint);
            spriteBatch.Draw(Maptexture, screenRectangle, Color.White);
        }
    }
}
