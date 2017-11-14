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

namespace Überleben
{
    public struct Mikros
    {
        public int art;
        public int zeit;
        public bool moved;
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D Maptexture;
        Rectangle screenRectangle;


        int screenWidth;
        int screenHeight;
        int screenWidth_1;
        int screenHeight_1;

        Mikros[] Map;
        Color[] Mapprint;
        
        Color Black = Color.Black;
        Color Red = Color.Red;
        Color Blue = Color.Blue;
        Color Green = Color.Green;
        Color Yellow = Color.Yellow;

        int fps;
        int schritte;
        int totaltime;
        int anzahlnachbaren;
        int aktuelleArt;
        bool Move = false;
        Random myRandom = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
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
            Map = new Mikros[screenWidth * screenHeight];
            Mapprint = new Color[screenWidth * screenHeight];
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            this.IsFixedTimeStep = false;

            LoadMap();
        }

        private void LoadMap()
        {
            Mikros new_mikro = new Mikros();
            new_mikro.art = 0;
            new_mikro.moved = false;
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    Map[x + y * screenWidth] = new_mikro;
                }
            }
            new_mikro.art = 1;
            for (int x = screenWidth / 6 * 2; x < screenWidth/6*3; x++)
            {
                for (int y = screenHeight / 6 * 2; y < screenHeight/6*3; y++)
                {
                    Map[x + y * screenWidth] = new_mikro;
                }
            }
            /*
            new_mikro.art = 1;
            Map[screenWidth / 10 + (screenHeight / 10) * screenWidth] = new_mikro;

            new_mikro.art = 2;
            Map[screenWidth - screenWidth / 10 + (screenHeight / 10) * screenWidth] = new_mikro;

            new_mikro.art = 3;
            Map[screenWidth / 10 + (screenHeight - screenHeight / 10) * screenWidth] = new_mikro;

            new_mikro.art = 4;
            Map[screenWidth - screenWidth / 10 + (screenHeight - screenHeight / 10) * screenWidth] = new_mikro;
            */
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

        private void NächsterZyklus()
        {
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    if (Map[x + y * screenWidth].moved == Move)
                    {
                        Map[x + y * screenWidth].moved = !Map[x + y * screenWidth].moved;
                        aktuelleArt = Map[x + y * screenWidth].art;
                        anzahlnachbaren = 0;
                        /*
                        if (Map[x_test(x + 1) + y * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        if (Map[x_test(x - 1) + y * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        if (Map[x + y_test(y + 1) * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        if (Map[x + y_test(y - 1) * screenWidth].art == aktuelleArt) anzahlnachbaren++;

                        if (Map[x_test(x + 1) + y_test(y - 1) * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        if (Map[x_test(x - 1) + y_test(y - 1) * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        if (Map[x_test(x + 1) + y_test(y + 1) * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        if (Map[x_test(x - 1) + y_test(y + 1) * screenWidth].art == aktuelleArt) anzahlnachbaren++;
                        */
                        if (aktuelleArt == 0)
                        {
                            
                        }
                        if (aktuelleArt == 1)
                        {
                            LessvisitedMove(x, y);
                        } 
                        if (aktuelleArt == 2)
                        {
                            
                        }
                        if (aktuelleArt == 3)
                        {
                            
                        }
                        if (aktuelleArt == 4)
                        {

                        }
                    }
                }
            }
            Move = !Move;
        }
        private void LessvisitedMove(int x, int y)
        {
            int kleinstezeit = 67;

            if (Map[x_test(x + 1) + y * screenWidth].art == 0 && Map[x_test(x + 1) + y * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x_test(x + 1) + y * screenWidth].zeit;
            if (Map[x_test(x - 1) + y * screenWidth].art == 0 && Map[x_test(x - 1) + y * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x_test(x - 1) + y * screenWidth].zeit;
            if (Map[x + y_test(y + 1) * screenWidth].art == 0 && Map[x + y_test(y + 1) * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x + y_test(y + 1) * screenWidth].zeit;
            if (Map[x + y_test(y - 1) * screenWidth].art == 0 && Map[x + y_test(y - 1) * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x + y_test(y - 1) * screenWidth].zeit;

            if (Map[x_test(x + 1) + y_test(y - 1) * screenWidth].art == 0 && Map[x_test(x + 1) + y_test(y - 1) * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x_test(x + 1) + y_test(y - 1) * screenWidth].zeit;
            if (Map[x_test(x - 1) + y_test(y - 1) * screenWidth].art == 0 && Map[x_test(x - 1) + y_test(y - 1) * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x_test(x - 1) + y_test(y - 1) * screenWidth].zeit;
            if (Map[x_test(x + 1) + y_test(y + 1) * screenWidth].art == 0 && Map[x_test(x + 1) + y_test(y + 1) * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x_test(x + 1) + y_test(y + 1) * screenWidth].zeit;
            if (Map[x_test(x - 1) + y_test(y + 1) * screenWidth].art == 0 && Map[x_test(x - 1) + y_test(y + 1) * screenWidth].zeit < kleinstezeit) kleinstezeit = Map[x_test(x - 1) + y_test(y + 1) * screenWidth].zeit;

            int wo = myRandom.Next(2, 10);
            while (wo >= 0)
            {
                wo--;
                if (Map[x_test(x + 1) + y * screenWidth].art == 0 && Map[x_test(x + 1) + y * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x_test(x + 1) + y * screenWidth].art = 1;
                    }
                }
                if (Map[x_test(x - 1) + y * screenWidth].art == 0 && Map[x_test(x - 1) + y * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x_test(x - 1) + y * screenWidth].art = 1;
                    }
                }
                if (Map[x + y_test(y + 1) * screenWidth].art == 0 && Map[x + y_test(y + 1) * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x + y_test(y + 1) * screenWidth].art = 1;
                    }
                }
                if (Map[x + y_test(y - 1) * screenWidth].art == 0 && Map[x + y_test(y - 1) * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x + y_test(y - 1) * screenWidth].art = 1;
                    }
                }

                if (Map[x_test(x + 1) + y_test(y - 1) * screenWidth].art == 0 && Map[x_test(x + 1) + y_test(y - 1) * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x_test(x + 1) + y_test(y - 1) * screenWidth].art = 1;
                    }
                }
                if (Map[x_test(x - 1) + y_test(y - 1) * screenWidth].art == 0 && Map[x_test(x - 1) + y_test(y - 1) * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x_test(x - 1) + y_test(y - 1) * screenWidth].art = 1;
                    }
                }
                if (Map[x_test(x + 1) + y_test(y + 1) * screenWidth].art == 0 && Map[x_test(x + 1) + y_test(y + 1) * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x_test(x + 1) + y_test(y + 1) * screenWidth].art = 1;
                    }
                }
                if (Map[x_test(x - 1) + y_test(y + 1) * screenWidth].art == 0 && Map[x_test(x - 1) + y_test(y + 1) * screenWidth].zeit == kleinstezeit)
                {
                    wo--;
                    if (wo == 0)
                    {
                        Map[x + y * screenWidth].art = 0;
                        Map[x + y * screenWidth].zeit++;
                        Map[x_test(x - 1) + y_test(y + 1) * screenWidth].art = 1;
                    }
                }
            }
        }
        /*
        private void moveRadomEatSmaler(int x, int y)
        {
            int art = Map[x + y * screenWidth].art;
            int wo = myRandom.Next(2, 10);
            while (wo >= 0)
            {
                wo--;
                if (Map[x_test(x + 1) + y * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x_test(x + 1) + y * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;
                }
                if (Map[x_test(x - 1) + y * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x_test(x - 1) + y * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }
                if (Map[x + y_test(y + 1) * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x + y_test(y + 1) * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }
                if (Map[x + y_test(y - 1) * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x + y_test(y - 1) * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }

                if (Map[x_test(x + 1) + y_test(y - 1) * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x_test(x + 1) + y_test(y - 1) * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }
                if (Map[x_test(x - 1) + y_test(y - 1) * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x_test(x - 1) + y_test(y - 1) * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }
                if (Map[x_test(x + 1) + y_test(y + 1) * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x_test(x + 1) + y_test(y + 1) * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }
                if (Map[x_test(x - 1) + y_test(y + 1) * screenWidth].art <= art) wo--;
                if (wo == 0)
                {
                    Map[x + y * screenWidth].zeit += Map[x_test(x + 1) + y * screenWidth].zeit;
                    Map[x_test(x - 1) + y_test(y + 1) * screenWidth] = Map[x + y * screenWidth];
                    Map[x + y * screenWidth].art = 0;
                    Map[x + y * screenWidth].zeit = 1;

                }
            }
        }
        private void Born(int x,int y,int art)
        {
            int wo = myRandom.Next(2,10);
            int artalt = Map[x + y * screenWidth].art;
            Map[x + y * screenWidth].art=art;
            while (wo >= 0)
            {
                wo--;
                if (Map[x_test(x + 1) + y * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x_test(x + 1) + y * screenWidth] = Map[x + y * screenWidth];
                if (Map[x_test(x - 1) + y * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x_test(x - 1) + y * screenWidth] = Map[x + y * screenWidth];
                if (Map[x + y_test(y + 1) * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x + y_test(y + 1) * screenWidth] = Map[x + y * screenWidth];
                if (Map[x + y_test(y - 1) * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x + y_test(y - 1) * screenWidth] = Map[x + y * screenWidth];

                if (Map[x_test(x + 1) + y_test(y - 1) * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x_test(x + 1) + y_test(y - 1) * screenWidth] = Map[x + y * screenWidth];
                if (Map[x_test(x - 1) + y_test(y - 1) * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x_test(x - 1) + y_test(y - 1) * screenWidth] = Map[x + y * screenWidth];
                if (Map[x_test(x + 1) + y_test(y + 1) * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x_test(x + 1) + y_test(y + 1) * screenWidth] = Map[x + y * screenWidth];
                if (Map[x_test(x - 1) + y_test(y + 1) * screenWidth].art == 0) wo--;
                if (wo == 0) Map[x_test(x - 1) + y_test(y + 1) * screenWidth] = Map[x + y * screenWidth];
            }
            Map[x + y * screenWidth].art = artalt;
        }
         * */
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
            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    if (Map[x + y * screenWidth].art == 0) Mapprint[x + y * screenWidth] = Black;
                    if (Map[x + y * screenWidth].art == 1) Mapprint[x + y * screenWidth] = Red;
                    if (Map[x + y * screenWidth].art == 2) Mapprint[x + y * screenWidth] = Blue;
                    if (Map[x + y * screenWidth].art == 3) Mapprint[x + y * screenWidth] = Green;
                    if (Map[x + y * screenWidth].art == 4) Mapprint[x + y * screenWidth] = Yellow;
                }
            }
            Maptexture.SetData(Mapprint);
            spriteBatch.Draw(Maptexture, screenRectangle, Color.White);
        }
    }
}
