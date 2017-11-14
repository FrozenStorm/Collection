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

namespace Wator
{
    public struct Tier
    {
        public int Art;//oder Generation 0=nichts
        public int Alter;
        public int LebensEnergie;
        public bool Schonbewegt;
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
        int MapWidth;
        int MapHeight;

        Tier[,] Map;
        List<Color> Tierarten = new List<Color>();
        Random myrandom = new Random();
        int zähler = 0;
        int geschwindikeit = 50;

       
        int ArtHai = 2;
        int LebensEnergieGewinnHai = 2;
        int VermehrungsAlterHai = 2;

        int ArtFisch = 1;
        int VermehrungsAlterFisch = 1;

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
            Window.Title = "Nahrungskette";
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
            Map = new Tier[MapWidth, MapHeight];
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            LoadTierarten();
            LoadMap();
        }
        private void LoadTierarten()
        {
            Tierarten.Clear();
            Tierarten.Add(Color.Black);
            Tierarten.Add(Color.Green);
            Tierarten.Add(Color.Red);
            Tierarten.Add(Color.Blue);
            Tierarten.Add(Color.Yellow);
            Tierarten.Add(Color.Orange);
            Tierarten.Add(Color.Gray);
            
        }
        private void LoadMap()
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    if (myrandom.Next(2) == 1)
                    {
                        if (myrandom.Next(20) == 1)
                        {
                            Map[x, y].Art = ArtFisch;
                            Map[x, y].Alter = 0;
                            Map[x, y].LebensEnergie = 1;
                        }
                        if(myrandom.Next(20) == 1)
                        {
                            Map[x, y].Art = ArtHai;
                            Map[x, y].Alter = 0;
                            Map[x, y].LebensEnergie = LebensEnergieGewinnHai;
                        }
                    }
                    else
                    {
                        Map[x, y].Art = 0;
                        Map[x, y].Alter = 0;
                        Map[x, y].LebensEnergie = 0;
                    }
                }
            }
            for (int x = 0; x < MapWidth; x++)
            {
                Map[x, 0].Art = 0;
                Map[x, 0].LebensEnergie = 0;
                Map[x, 0].Alter = 0;
                Map[x, MapHeight - 1].Art = 0;
                Map[x, MapHeight - 1].LebensEnergie = 0;
                Map[x, MapHeight - 1].Alter = 0;
            }
            for (int y = 0; y < MapHeight; y++)
            {
                Map[0, y].Art = 0;
                Map[0, y].LebensEnergie = 0;
                Map[0, y].Alter = 0;
                Map[MapWidth - 1, y].Art = 0;
                Map[MapWidth - 1, y].LebensEnergie = 0;
                Map[MapWidth - 1, y].Alter = 0;
            }
            Maptexture = Maptotexture(Map);
        }

        protected override void UnloadContent()
        {
        }

        private Texture2D Maptotexture(Tier[,] PrintedMap)
        {
            int width = PrintedMap.GetLength(0);
            int height = PrintedMap.GetLength(1);
            Color[] color1D = new Color[width * height];
            Texture2D neutexture = new Texture2D(device, width, height, false, SurfaceFormat.Color);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    try { color1D[x + y * width] = Tierarten[PrintedMap[x, y].Art]; }
                    catch { color1D[x + y * width] = Color.White; }
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
            zähler++;
            if (zähler % geschwindikeit == 0) NächsterZyklus();
            
            base.Update(gameTime);
        }

        private void NächsterZyklus()
        {
            Vector2 nächstesfeld;
            for (int x = 1; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    if (Map[x, y].Schonbewegt == false)
                    {
                        Map[x, y].Schonbewegt = true;
                        if (Map[x, y].Art == ArtFisch)
                        {
                            Map[x, y].Alter++;
                            nächstesfeld = Futtersuche(new Vector2(x, y));
                            if (nächstesfeld != new Vector2(-1))
                            {
                                Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Alter = Map[x, y].Alter;
                                Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Art = Map[x, y].Art;
                                Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Schonbewegt = Map[x, y].Schonbewegt;
                                Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].LebensEnergie = Map[x, y].LebensEnergie;
                                if (Map[x, y].Alter % VermehrungsAlterFisch == 0)
                                {
                                    Vermehren(new Vector2(x, y), ArtFisch, 1);
                                }
                            }
                        }
                        if (Map[x, y].Art == ArtHai)
                        {
                            Map[x, y].Alter++;
                            nächstesfeld = Futtersuche(new Vector2(x, y));
                            Map[x, y].LebensEnergie--;
                            if (Map[x, y].LebensEnergie == 0)
                            {
                                Sterben(new Vector2(x, y));
                            }
                            else
                            {
                                if (nächstesfeld != new Vector2(-1))
                                {
                                    if (Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Art != 0)
                                    {
                                        Map[x, y].LebensEnergie = LebensEnergieGewinnHai;
                                    }
                                    Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Alter = Map[x, y].Alter;
                                    Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Art = Map[x, y].Art;
                                    Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].Schonbewegt = Map[x, y].Schonbewegt;
                                    Map[(int)nächstesfeld.X, (int)nächstesfeld.Y].LebensEnergie = Map[x, y].LebensEnergie;
                                    if (Map[x, y].Alter % VermehrungsAlterHai == 0)
                                    {
                                        Vermehren(new Vector2(x, y), ArtHai, LebensEnergieGewinnHai);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int x = 1; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    Map[x, y].Schonbewegt = false;
                }
            }
            Maptexture = Maptotexture(Map);
        }
        private void Sterben(Vector2 position)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            Map[x, y].Art = 0;
            Map[x, y].Alter = 0;
            Map[x, y].LebensEnergie = 0;
        }
        private void Vermehren(Vector2 position,int Art,int StartLebensEnergie)//position=Wo soll das Jungtier geboren werden
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            Map[x, y].Art = Art;
            Map[x, y].LebensEnergie = StartLebensEnergie;
            Map[x, y].Alter = 0;
            Map[x, y].Schonbewegt = true;
        }
        private Vector2 Futtersuche(Vector2 position)
        {
            List<Vector2> bestesfutterposition = new List<Vector2>();
            int bestesfutterenergie = -1;
            int x = (int)position.X;
            int y = (int)position.Y;
            bestesfutterposition.Add(new Vector2(-1));
            for (int a = x - 1; a <= x + 1; a++)
            {
                for (int b = y - 1; b <= y + 1; b++)
                {
                    int c = a;
                    int d = b;
                    if (c == MapWidth - 1) c = 1;
                    if (c == 0) c = MapWidth - 2;
                    if (d == MapHeight - 1) d = 1;
                    if (d == 0) d = MapHeight - 2;
                    if (Map[c, d].Art < Map[x, y].Art && Map[c, d].LebensEnergie > bestesfutterenergie && new Vector2(c, d) != position)
                    {
                        bestesfutterposition.Clear();
                        bestesfutterenergie = Map[c, d].LebensEnergie;
                        bestesfutterposition.Add(new Vector2(c, d));
                    }
                    if (Map[c, d].Art < Map[x, y].Art && Map[c, d].LebensEnergie == bestesfutterenergie && new Vector2(c, d) != position)
                    {
                        bestesfutterposition.Add(new Vector2(c, d));
                    }
                }
            }
            return bestesfutterposition[myrandom.Next(0, bestesfutterposition.IndexOf(bestesfutterposition.Last<Vector2>())+1)];
        }
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (keybState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                LoadMap();
            }
            if (keybState.IsKeyDown(Keys.D1)) geschwindikeit = 5;
            if (keybState.IsKeyDown(Keys.D2)) geschwindikeit = 10;
            if (keybState.IsKeyDown(Keys.D3)) geschwindikeit = 50;
            if (keybState.IsKeyDown(Keys.D4)) geschwindikeit = 100;
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
