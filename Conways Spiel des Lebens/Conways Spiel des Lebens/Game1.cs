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

namespace Conways_Spiel_des_Lebens
{
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

        Int16[] Map;
        Int16[] Mapnext;
        Color[] Mapprint;

        int fps;
        int schritte;
        int totaltime;
        int anzahlnachbaren;
        Int16[] anzahlnachbaren_alle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Conways Spiel des Lebens";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            screenWidth_1 = screenWidth - 1;
            screenHeight_1 = screenHeight - 1;

            Maptexture = new Texture2D(device, screenWidth, screenHeight, false, SurfaceFormat.Color);
            nexttexture = new Texture2D(device, screenWidth, screenHeight, false, SurfaceFormat.Color);
            Map = new Int16[screenWidth * screenHeight];
            Mapnext = new Int16[screenWidth * screenHeight];
            Mapprint = new Color[screenWidth * screenHeight];
            anzahlnachbaren_alle = new Int16[screenWidth * screenHeight];
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            this.IsFixedTimeStep = false;

            LoadMap();
        }

        private void LoadMap()
        {
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    Mapnext[x + y * screenWidth] = 0;
                    anzahlnachbaren_alle[x + y * screenWidth] = 0;
                }
            }

            Mapnext[(screenWidth / 2) + ((screenHeight / 2) + 1) * screenWidth] = 1;
            Mapnext[(screenWidth / 2) + ((screenHeight / 2) - 1) * screenWidth] = 1;
            Mapnext[((screenWidth / 2) - 1) + (screenHeight / 2) * screenWidth] = 1;
            Mapnext[((screenWidth / 2) + 1) + ((screenHeight / 2) - 1) * screenWidth] = 1;
            Mapnext[(screenWidth / 2) + (screenHeight / 2) * screenWidth] = 1;
            /*            
            
                       Mapnext[(screenWidth / 2) + (screenHeight / 2) * screenWidth] = 1;
                       Mapnext[((screenWidth / 2) + 1) + ((screenHeight / 2)) * screenWidth] = 1;
                       Mapnext[((screenWidth / 2) - 1) + ((screenHeight / 2)) * screenWidth] = 1;
                       Mapnext[((screenWidth / 2) + 1) + ((screenHeight / 2) - 1) * screenWidth] = 1;
                       Mapnext[((screenWidth / 2)) + ((screenHeight / 2) - 2) * screenWidth] = 1;
           */
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    if (Mapnext[x + y * screenWidth] == 0) Mapprint[x + y * screenWidth] = Color.Black;
                    else Mapprint[x + y * screenWidth] = Color.White;
                }
            }
            Mapnext.CopyTo(Map, 0);
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
            fps++;
            schritte++;
            totaltime += gameTime.ElapsedGameTime.Milliseconds;
            if (totaltime >= 1000)
            {
                Window.Title = "FPS: " + fps.ToString() + "     Schritte: " + schritte.ToString();
                fps = 0;
                totaltime = 0;
            }
            ProcessKeyboard();
            NächsterZyklus();
            base.Update(gameTime);
        }
        /*
        private void NächsterZyklus()
        {
            
            for (int x = 1; x < screenWidth_1; x++)
            {
                Map[x + (screenHeight_1) * screenWidth] = Map[x + 1 * screenWidth];
                Map[x + 0 * screenWidth] = Map[x + (screenHeight - 2) * screenWidth];
            }
            for (int y = 1; y < screenHeight - 1; y++)
            {
                Map[(screenWidth_1) + y * screenWidth] = Map[1 + y * screenWidth];
                Map[0 + y * screenWidth] = Map[(screenWidth - 2) + y * screenWidth];
            }
            for (int x = 1; x < screenWidth_1; x++)
            {
                for (int y = 1; y < screenHeight_1; y++)
                {
                    anzahlnachbaren = 0;
                    x += 2;
                    y += 2;
                    for (int k = x - 3; k < x; k++)
                    {
                        for (int n = y - 3; n < y; n++)
                        {
                            if (Map[k + n * screenWidth] == 1) anzahlnachbaren++;
                        }
                    }
                    x -= 2;
                    y -= 2;

                    if (Map[x + y * screenWidth] == 1)
                    {
                        anzahlnachbaren--;
                        if (anzahlnachbaren < 2)
                        {
                            Mapnext[x + y * screenWidth] = 0;
                            Mapprint[x + y * screenWidth] = Color.Black;
                        }
                        if (anzahlnachbaren > 3)
                        {
                            Mapnext[x + y * screenWidth] = 0;
                            Mapprint[x + y * screenWidth] = Color.Black;
                        }
                    }
                    else
                    {
                        if (anzahlnachbaren == 3)
                        {
                            Mapnext[x + y * screenWidth] = 1;
                            Mapprint[x + y * screenWidth] = Color.White;
                        }
                    }
                }
            }

            Mapnext.CopyTo(Map, 0);
        }*/

        private void NächsterZyklus()
        {

            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    anzahlnachbaren_alle[x + y * screenWidth] = 0;
                }
            }
            for (int x = 1; x < screenWidth_1; x++)
            {
                for (int y = 1; y < screenHeight_1; y++)
                {
                    if (Map[x + y * screenWidth] == 1)
                    {
                        anzahlnachbaren_alle[x+1 + (y+1) * screenWidth]++;
                        anzahlnachbaren_alle[x+1 + (y-1) * screenWidth]++;
                        anzahlnachbaren_alle[x+1 + (y) * screenWidth]++;
                        anzahlnachbaren_alle[x + (y-1) * screenWidth]++;
                        anzahlnachbaren_alle[x + (y+1) * screenWidth]++;
                        anzahlnachbaren_alle[x-1 + (y+1) * screenWidth]++;
                        anzahlnachbaren_alle[x-1 + (y-1) * screenWidth]++;
                        anzahlnachbaren_alle[x-1 + (y) * screenWidth]++;
                    }
                }
            }
            for (int x = 1; x < screenWidth_1; x++)
            {
                anzahlnachbaren_alle[x + 1 * screenWidth] += anzahlnachbaren_alle[x + (screenHeight_1) * screenWidth];
                anzahlnachbaren_alle[x + (screenHeight - 2) * screenWidth] += anzahlnachbaren_alle[x + 0 * screenWidth];
            }
            for (int y = 1; y < screenHeight - 1; y++)
            {
                anzahlnachbaren_alle[1 + y * screenWidth] += anzahlnachbaren_alle[(screenWidth_1) + y * screenWidth];
                anzahlnachbaren_alle[(screenWidth - 2) + y * screenWidth] += anzahlnachbaren_alle[0 + y * screenWidth];
            }
            for (int x = 1; x < screenWidth_1; x++)
            {
                for (int y = 1; y < screenHeight_1; y++)
                {
                    if (Map[x + y * screenWidth] == 1)
                    {
                        if (anzahlnachbaren_alle[x + y * screenWidth] < 2)
                        {
                            Map[x + y * screenWidth] = 0;
                            Mapprint[x + y * screenWidth] = Color.Black;
                        }
                        if (anzahlnachbaren_alle[x + y * screenWidth] > 3)
                        {
                            Map[x + y * screenWidth] = 0;
                            Mapprint[x + y * screenWidth] = Color.Black;
                        }
                    }
                    else
                    {
                        if (anzahlnachbaren_alle[x + y * screenWidth] == 3)
                        {
                            Map[x + y * screenWidth] = 1;
                            Mapprint[x + y * screenWidth] = Color.White;
                        }
                    }
                }
            }
        }

        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
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
            graphics.GraphicsDevice.Textures[0] = null;
            Maptexture.SetData(Mapprint);
            spriteBatch.Draw(Maptexture, screenRectangle, Color.White);
        }
    }
}
