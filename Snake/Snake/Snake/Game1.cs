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
using System.IO.Ports;

namespace Snake
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D backgroundTexture;
        Texture2D playerheadupTexture;
        Texture2D playerheaddownTexture;
        Texture2D playerheadrightTexture;
        Texture2D playerheadleftTexture;
        Texture2D playerbodyTexture;
        Texture2D playertrailTexture;
        Texture2D eggTexture;

        int screenWidth;
        int screenHeight;
        int playerdirection;
        int playerlenght;
        int lastplayerdirection;
        int maxlenght;
        int time;

        bool restart;
        bool alive;
        bool sleep;
        bool sleep_state;

        int speed = 100;
        int anzahlfelder = 25;
        int mitte = 10;

        List<Vector2> player;
        Vector2 egg;
        Random myrandom = new Random();

        int x;
        int y;
        int x0;
        int y0;
        SerialPort sp;
        string nstring;

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
            Window.Title = "Snake";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            backgroundTexture = Content.Load<Texture2D>("Snake");
            playerheadupTexture = Content.Load<Texture2D>("Head_up");
            playerheaddownTexture = Content.Load<Texture2D>("Head_down");
            playerheadleftTexture = Content.Load<Texture2D>("Head_left");
            playerheadrightTexture = Content.Load<Texture2D>("Head_right");
            playerbodyTexture = Content.Load<Texture2D>("Body");
            playertrailTexture = Content.Load<Texture2D>("Tail");
            eggTexture = Content.Load<Texture2D>("Egg");
            InitGame();
            initRS323();
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
        }

        private void initRS323()
        {
            try
            {
                sp = new SerialPort("COM1");
                sp.BaudRate = 9600;
                sp.ReadTimeout = 50;
                sp.Open();
            }
            catch { }
        }

        private void InitGame()
        {
            player = new List<Vector2>();
            sleep = false;
            playerdirection = 0;
            lastplayerdirection = 0;
            playerlenght = 0;
            maxlenght = 4;
            player.Add(new Vector2(myrandom.Next(anzahlfelder), myrandom.Next(anzahlfelder)));
            AddEgg();
            alive = true;
            restart = false;
        }

        private void AddEgg()
        {
            do
            {
                egg = new Vector2(myrandom.Next(anzahlfelder), myrandom.Next(anzahlfelder));
            }
            while (player.Contains(egg));
        }

        private void Calibrate()
        {
            x0 = x;
            y0 = y;
        }

        protected override void UnloadContent()
        {
            sp.Close();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ProcessKeyboard();
            time += gameTime.ElapsedGameTime.Milliseconds;
            if ((time >= speed) && alive==true && sleep==false)
            {
                time = 0;
                Updateplayer();
            }
            base.Update(gameTime);
        }

        private void sp_DataReceived(object sender, EventArgs e)
        {
            try
            {
                nstring = sp.ReadLine();
                if (nstring.Contains("X")) x = Convert.ToInt16(sp.ReadLine());
                if (nstring.Contains("Y")) y = Convert.ToInt16(sp.ReadLine());
            }
            catch { }
            if (x > x0 + mitte && lastplayerdirection != 2) playerdirection = 4;
            if (x < x0 - mitte && lastplayerdirection != 4) playerdirection = 2;
            if (y > y0 + mitte && lastplayerdirection != 1) playerdirection = 3;
            if (y < y0 - mitte && lastplayerdirection != 3) playerdirection = 1;
        }

        private void ProcessKeyboard()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) && lastplayerdirection != 4)
                playerdirection = 2;
            if (keyState.IsKeyDown(Keys.Down) && lastplayerdirection != 2)
                playerdirection=4;
            if (keyState.IsKeyDown(Keys.Right) && lastplayerdirection != 3)
                playerdirection=1;
            if (keyState.IsKeyDown(Keys.Left) && lastplayerdirection != 1)
                playerdirection = 3;
            if (keyState.IsKeyDown(Keys.P))
                sleep_state = true;
            if (keyState.IsKeyUp(Keys.P) && sleep_state == true)
            {
                sleep_state = false;
                sleep = !sleep;
            }
            if (keyState.IsKeyDown(Keys.Space))
                Calibrate();
            if (keyState.IsKeyDown(Keys.Enter))
                restart = true;
            if (keyState.IsKeyUp(Keys.Enter) && restart == true)
                InitGame();

            if (keyState.IsKeyDown(Keys.NumPad8) && anzahlfelder < 100)
                anzahlfelder++;
            if (keyState.IsKeyDown(Keys.NumPad2) && anzahlfelder > 5)
                anzahlfelder--;
            if (keyState.IsKeyDown(Keys.NumPad6) && speed < 200)
                speed++;
            if (keyState.IsKeyDown(Keys.NumPad4) && speed > 1)
                speed--;
        }

        private void Updateplayer()
        {
            Vector2 next;
            next=player[playerlenght];
            lastplayerdirection = playerdirection;
            switch (playerdirection)
            {
                case 0:
                    break;
                case 1:
                    next.X++;
                    break;
                case 2:
                    next.Y--;
                    break;
                case 3:
                    next.X--;
                    break;
                case 4:
                    next.Y++;
                    break;
            }
            if (next == egg)
            {
                maxlenght++;
                AddEgg();
            }
            if ((next.X < anzahlfelder) && (next.X >= 0) && (next.Y < anzahlfelder) && (next.Y >= 0) && (!player.Contains(next)))
            {
                player.Add(next);
                if (playerlenght == maxlenght) player.RemoveAt(0);
                else playerlenght++;
            }
            else
            {
                if (playerdirection != 0)
                {
                    alive = false;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Green);
            spriteBatch.Begin();
            DrawBackground();
            DrawEgg();
            DrawPlayer();
            spriteBatch.End();
            base.Draw(gameTime);
            DrawPoint();
        }
        private void DrawPoint()
        {
            Window.Title = "Snake------"+maxlenght.ToString();
        }
        private void DrawPlayer()
        {
            Color myColor;
            if (alive == true) myColor = Color.GreenYellow;
            else myColor = Color.Red;
            spriteBatch.Draw(playertrailTexture, new Rectangle((int)player[0].X * (screenHeight / anzahlfelder), (int)player[0].Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), myColor);
            if(playerdirection<=1)spriteBatch.Draw(playerheadrightTexture, new Rectangle((int)player[playerlenght].X * (screenHeight / anzahlfelder), (int)player[playerlenght].Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), myColor);
            if (playerdirection == 2) spriteBatch.Draw(playerheadupTexture, new Rectangle((int)player[playerlenght].X * (screenHeight / anzahlfelder), (int)player[playerlenght].Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), myColor);
            if (playerdirection == 3) spriteBatch.Draw(playerheadleftTexture, new Rectangle((int)player[playerlenght].X * (screenHeight / anzahlfelder), (int)player[playerlenght].Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), myColor);
            if (playerdirection == 4) spriteBatch.Draw(playerheaddownTexture, new Rectangle((int)player[playerlenght].X * (screenHeight / anzahlfelder), (int)player[playerlenght].Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), myColor);
            if (playerlenght > 1)
            {
                for (int i = 1; i < player.LastIndexOf(player.Last<Vector2>()); i++)
                {
                    spriteBatch.Draw(playerbodyTexture, new Rectangle((int)player[i].X * (screenHeight / anzahlfelder), (int)player[i].Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), myColor);
                }
            }
        }
        private void DrawEgg()
        {
            spriteBatch.Draw(eggTexture, new Rectangle((int)egg.X * (screenHeight / anzahlfelder), (int)egg.Y * (screenHeight / anzahlfelder), (screenHeight / anzahlfelder), (screenHeight / anzahlfelder)), Color.White);
        }
        private void DrawBackground()
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
        }
    }
}
