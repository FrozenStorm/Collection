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

namespace Space_survive
{
    public struct Particle
    {
        public Texture2D particleTexture;
        public Vector2 Position;
        public Vector2 Direction; // länge=anzahl mal schieben      winkel=richtung
        public int radius;
        public int masse;
    }
    public struct Player
    {
        public Texture2D playerTexture;
        public Vector2 Position;
        public Vector2 Direction; // länge=anzahl mal schieben      winkel=richtung
        public int radius;
        public bool isalive;
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        SpriteFont font;
        Texture2D hintergrundTexture;

        int screenWidth;
        int screenHeight;
        Vector2 Wandlinksrechts = new Vector2(1, 0);
        Vector2 Wandobenunten = new Vector2(0, 1);

        char[] schlüssel = new char[] { 'x', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', ',', '.' };

        public List<Particle> particle;
        
        Player playerone;
        int highscore;
        int Punkte;
        int maximalegeschwindigkeit = 9;
        float minimalegeschwindigkeit = 0.2f;
        float wendewinkel = 0.15f;
        float beschleunigung = 0.15f;
        bool Key_Flag_1 = false;
        bool Key_Flag_2 = false;
        bool Key_Flag_3 = false;

        float gravitationskonstante = 6.674f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Space_survive";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            hintergrundTexture = Content.Load<Texture2D>("Hintergrund");
            font = Content.Load<SpriteFont>("myFont");

            particle = new List<Particle>();
            Punkte = 0;
            Initplayer();
            Initparticle();
        }
        private void Initplayer()
        {
            playerone = new Player();
            playerone.playerTexture = Content.Load<Texture2D>("Space_Ship");
            playerone.Position = new Vector2(screenWidth / 2, screenHeight / 2);
            playerone.Direction = new Vector2(0, -1);
            playerone.radius = (playerone.playerTexture.Width + playerone.playerTexture.Height) / 4;
            playerone.isalive = true;
        }
        private void Initparticle()
        {
            Particle myParticle = new Particle();
            myParticle.particleTexture = Content.Load<Texture2D>("Earth");
            myParticle.Direction = new Vector2(1, 1);
            myParticle.radius = myParticle.particleTexture.Width / 2;
            myParticle.Position = new Vector2(screenWidth / 2, screenHeight / 4);
            myParticle.masse = myParticle.particleTexture.Width / 10;
            particle.Add(myParticle);
        }
        private void Addparticle(string name)
        {
            int anzahlpartikel = particle.IndexOf(particle.Last<Particle>());
            Random myRandom = new Random();
            Particle myParticle = new Particle();
            bool set = false;
            myParticle.particleTexture = Content.Load<Texture2D>(name);
            myParticle.radius = myParticle.particleTexture.Width/2;
            myParticle.masse = myParticle.particleTexture.Width/10;
            while (set == false)
            {
                float abstand;
                set = true;
                myParticle.Position = new Vector2(myRandom.Next(myParticle.radius, screenWidth - myParticle.radius), myRandom.Next(myParticle.radius, screenHeight - myParticle.radius));
                for (int j = 0; j <= anzahlpartikel; j++)
                {
                    abstand = Vector2.Distance(myParticle.Position, particle[j].Position);
                    if (abstand < myParticle.radius + particle[j].radius)
                    {
                        set = false;
                    }
                }
                abstand = Vector2.Distance(myParticle.Position, playerone.Position);
                if (abstand < myParticle.radius + playerone.radius*10)
                {
                    set = false;
                }
            }
            myParticle.Direction = Vector2.Normalize(myParticle.Position - playerone.Position) * myRandom.Next(1,4);
            particle.Add(myParticle);
        }
        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState keybState = Keyboard.GetState();
            if (keybState.IsKeyDown(Keys.Space)) LoadContent();
            if (keybState.IsKeyDown(Keys.Escape)) this.Exit();
            UpdatePlayer();
            UpdateParticle();
            UpdatePunkte();
            UpdateStatus();
            base.Update(gameTime);
        }
        private void UpdateStatus()
        {
            try
            {
                FileStream fi;
                try
                {
                    fi = new FileStream(this.Content.RootDirectory + "/bla.txt", FileMode.Open);
                    StreamReader sr = new StreamReader(fi);
                    highscore = Decode(sr.ReadLine());
                    sr.Close();
                }
                catch
                {
                    fi = new FileStream(this.Content.RootDirectory+"/bla.txt", FileMode.Create);
                    highscore = 0;
                }
                    //fi = new FileStream("C:/Savedata_Space_survive.txt", FileMode.OpenOrCreate);
                fi.Close();

                fi = new FileStream(this.Content.RootDirectory + "/bla.txt", FileMode.OpenOrCreate);
                //fi = new FileStream("C:/Savedata_Space_survive.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fi);
                if (Punkte > highscore) sw.WriteLine(Code(Punkte));
                sw.Close();
                fi.Close();
            }
            catch
            {
                highscore = 0;
            }
        }
        private string Code(int zahl)
        {
            string code;
            char[] arraycode = new char[20];
            int längezahl = 1;
            int produkt = 1;
            for (int i = 1; zahl / i >= 10; i = i * 10)
            {
                längezahl++;
            }
            for (int i = 0; i < längezahl; i++)
            {
                arraycode[i] = schlüssel[(zahl/(int)Math.Pow(10,i)) % 10];
                produkt = produkt * ((zahl / (int)Math.Pow(10, i)) % 10);
            }
            if (zahl == 0) produkt = 0;

            arraycode[längezahl] = schlüssel[10];

            int längeprodukt = 1;
            for (int i = 1; produkt / i >= 10; i = i * 10)
            {
                längeprodukt++;
            }
            for (int i = 0; i < längeprodukt; i++)
            {
                arraycode[i + längezahl + 1] = schlüssel[(produkt / (int)Math.Pow(10,i)) % 10];
            }

            arraycode[längezahl + längeprodukt + 1] = schlüssel[11];
            code = new String(arraycode);
            return code;
        }
        private int Decode(string code)
        {
            int zahl = 0;
            int produktincode = 0;
            int produktsoll = 1;
            char[] arraycode = code.ToArray<char>();
            int längezahl = 0;
            for (int i = 0; arraycode[i] != schlüssel[10]; i++)
            {
                if(indexofschlüssel(arraycode[i])==-1)return 0;
                zahl += indexofschlüssel(arraycode[i])*(int)Math.Pow(10,i);
                produktsoll = produktsoll * indexofschlüssel(arraycode[i]);
                längezahl = i;
            }
            längezahl+=2;
            for (int i = 0; arraycode[i + längezahl] != schlüssel[11]; i++)
            {
                if (indexofschlüssel(arraycode[i + längezahl]) == -1) return 0;
                produktincode += indexofschlüssel(arraycode[i + längezahl]) * (int)Math.Pow(10, i);
            }
            if (produktincode != produktsoll) return 0;
            return zahl;
        }
        private int indexofschlüssel(char gesucht)
        {
            for (int i = 0; i < 10; i++)
            {
                if (schlüssel[i] == gesucht) return i;
            }
            return -1;
        }

        private void UpdatePunkte()
        {
            if (Punkte % 200 == 0 && playerone.isalive == true) Addparticle("Moon");
            if (Punkte % 400 == 0 && playerone.isalive==true) Addparticle("Earth");
            if (Punkte % 600 == 0 && playerone.isalive == true) Addparticle("Sun");
        }
        private void UpdatePlayer()
        {
            int schritte = 0;
            int anzahlpartikel = particle.IndexOf(particle.Last<Particle>());
            if (playerone.Direction.Length() <= 0.5f)
            {
                for (int j = 0; j <= anzahlpartikel; j++)
                {
                    float abstand;
                    abstand = Vector2.Distance(playerone.Position, particle[j].Position);
                    if (abstand < playerone.radius + particle[j].radius)
                    {
                        playerone.isalive = false;
                    }
                }
            }
            else
            {
                while (schritte < playerone.Direction.Length())
                {
                    playerone.Position = playerone.Position + Vector2.Normalize(playerone.Direction);
                    schritte++;
                    for (int j = 0; j <= anzahlpartikel; j++)
                    {
                        float abstand;
                        abstand = Vector2.Distance(playerone.Position, particle[j].Position);
                        if (abstand < playerone.radius + particle[j].radius)
                        {
                            playerone.isalive = false;
                        }
                    }
                    if (playerone.Position.X < 0 || playerone.Position.X > screenWidth)
                    {
                        playerone.isalive = false;
                    }
                    if (playerone.Position.Y < 0 || playerone.Position.Y > screenHeight)
                    {
                        playerone.isalive = false;
                    }
                }
            }
            if (playerone.isalive == true)
            {
                Punkte++;
                KeyboardState keybState = Keyboard.GetState();
                if (keybState.IsKeyDown(Keys.Up) && playerone.Direction.Length() < maximalegeschwindigkeit)
                    playerone.Direction += Vector2.Normalize(playerone.Direction) * beschleunigung;
                if (!keybState.IsKeyDown(Keys.Up) && playerone.Direction.Length() > minimalegeschwindigkeit)
                    playerone.Direction -= Vector2.Normalize(playerone.Direction) * beschleunigung / 2;
                if (keybState.IsKeyDown(Keys.Right))
                    playerone.Direction = Vector2.Transform(playerone.Direction, Matrix.CreateRotationZ(wendewinkel));
                if (keybState.IsKeyDown(Keys.Left))
                    playerone.Direction = Vector2.Transform(playerone.Direction, Matrix.CreateRotationZ(-wendewinkel));
                if (keybState.IsKeyDown(Keys.D1)&& Key_Flag_1 == false) 
                {
                    Key_Flag_1 = true;
                    Particle myParticle = new Particle();
                    myParticle.particleTexture = Content.Load<Texture2D>("Moon");
                    myParticle.radius = myParticle.particleTexture.Width / 2;
                    myParticle.masse = myParticle.particleTexture.Width / 10;
                    myParticle.Position = playerone.Position + Vector2.Normalize(playerone.Direction) * playerone.radius + Vector2.Normalize(playerone.Direction) * myParticle.radius;
                    myParticle.Direction = Vector2.Normalize(playerone.Direction) * 11f;
                    particle.Add(myParticle);
                }
                if (keybState.IsKeyDown(Keys.D2) && Key_Flag_2 == false)
                {
                    Key_Flag_2 = true;
                    Particle myParticle = new Particle();
                    myParticle.particleTexture = Content.Load<Texture2D>("Earth");
                    myParticle.radius = myParticle.particleTexture.Width / 2;
                    myParticle.masse = myParticle.particleTexture.Width / 10;
                    myParticle.Position = playerone.Position + Vector2.Normalize(playerone.Direction) * playerone.radius + Vector2.Normalize(playerone.Direction) * myParticle.radius;
                    myParticle.Direction = Vector2.Normalize(playerone.Direction) * 11f;
                    particle.Add(myParticle);
                }
                if (keybState.IsKeyDown(Keys.D3) && Key_Flag_3 == false)
                {
                    Key_Flag_3 = true;
                    Particle myParticle = new Particle();
                    myParticle.particleTexture = Content.Load<Texture2D>("Sun");
                    myParticle.radius = myParticle.particleTexture.Width / 2;
                    myParticle.masse = myParticle.particleTexture.Width / 10;
                    myParticle.Position = playerone.Position + Vector2.Normalize(playerone.Direction) * playerone.radius + Vector2.Normalize(playerone.Direction) * myParticle.radius;
                    myParticle.Direction = Vector2.Normalize(playerone.Direction) * 11f;
                    particle.Add(myParticle);
                }
                if (keybState.IsKeyUp(Keys.D1)) Key_Flag_1 = false;
                if (keybState.IsKeyUp(Keys.D2)) Key_Flag_2 = false;
                if (keybState.IsKeyUp(Keys.D3)) Key_Flag_3 = false;
            }
            else
            {
                playerone.Direction = Vector2.Normalize(playerone.Direction) * minimalegeschwindigkeit;
            }
        }

        private void UpdateParticle()
        {
            Vector2[] particleDirection = new Vector2[2];
            float abstand;
            int anzahlpartikel = particle.IndexOf(particle.Last<Particle>());
            for (int i = 0; i <= anzahlpartikel; i++)
            {
                int schritte = 0;
                while (schritte < particle[i].Direction.Length())
                {
                    Particle particlenow = particle[i];
                    /*Gravitation
                    for (int j = 0; j <= anzahlpartikel; j++)
                    {
                        Particle particlesecond = particle[j];
                        if (particlenow.Position != particlesecond.Position)
                        {
                            particleDirection[0] = particlesecond.Position - particlenow.Position;
                            particleDirection[0] = Vector2.Normalize(particleDirection[0]) * (gravitationskonstante * particlesecond.masse / particleDirection[0].Length()) * 0.02f;
                            particlenow.Direction += particleDirection[0];
                        }
                    }
                    */
                    for (int j = 0; j <= anzahlpartikel; j++)
                    {
                        Particle particlesecond = particle[j];
                        if (particlenow.Position != particlesecond.Position)
                        {
                            abstand = Vector2.Distance(particlenow.Position + Vector2.Normalize(particlenow.Direction), particlesecond.Position);
                            if (abstand < particlenow.radius + particlesecond.radius)
                            {
                                particleDirection = Collision(particlenow, particlesecond);
                                particlenow.Direction = particleDirection[0];
                                particlesecond.Direction = particleDirection[1];
                                particle[j] = particlesecond;
                            }
                        }
                    }
                    if ((particlenow.Position + Vector2.Normalize(particlenow.Direction)).X < particlenow.radius || (particlenow.Position + Vector2.Normalize(particlenow.Direction)).X > screenWidth - particlenow.radius)
                    {
                        particlenow.Direction = Vector2.Reflect(particlenow.Direction, Wandlinksrechts);
                    }
                    if ((particlenow.Position + Vector2.Normalize(particlenow.Direction)).Y < particlenow.radius || (particlenow.Position + Vector2.Normalize(particlenow.Direction)).Y > screenHeight - particlenow.radius)
                    {
                        particlenow.Direction = Vector2.Reflect(particlenow.Direction, Wandobenunten);
                    }
                    particlenow.Position = particlenow.Position + Vector2.Normalize(particlenow.Direction);
                    particle[i] = particlenow;
                    schritte++;
                }
            }
        }

        private Vector2[] Collision(Particle particle1, Particle particle2)
        {
            int m1 = particle1.masse;
            int m2 = particle2.masse;
            Vector2 v1 = particle1.Direction;
            Vector2 v2 = particle2.Direction;
            Vector2 w1 = Vector2.Normalize(particle2.Position - particle1.Position);
            Vector2 w2 = Vector2.Normalize(particle1.Position - particle2.Position);
            float x1 = Vector2.Dot(v1, w1);
            float x2 = Vector2.Dot(v2, w2);
            Vector2 s1 = w1 * x1;
            Vector2 s2 = w2 * x2;
            Vector2 p1 = v1 - s1;
            Vector2 p2 = v2 - s2;
            Vector2 a1 = p1 + (2 * (m1 * s1 + m2 * s2) / (m1 + m2) - s1);
            Vector2 a2 = p2 + (2 * (m1 * s1 + m2 * s2) / (m1 + m2) - s2);
            return new Vector2[2] { a1, a2 };
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            DrawHintergrund();
            DrawParticle();
            DrawPlayer();
            DrawPunkte();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void DrawHintergrund()
        {
            spriteBatch.Draw(hintergrundTexture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
        }
        private void DrawParticle()
        {
            int anzahlpartikel = particle.IndexOf(particle.Last<Particle>());
            for (int j = 0; j <= anzahlpartikel; j++)
            {
                spriteBatch.Draw(particle[j].particleTexture, particle[j].Position, null, Color.White, 0, new Vector2(particle[j].radius, particle[j].radius), 1f, SpriteEffects.None, 1);
            }
        }
        private void DrawPlayer()
        {
            spriteBatch.Draw(playerone.playerTexture, playerone.Position, null, Color.White, (float)(Math.Atan2(playerone.Direction.Y, playerone.Direction.X) + Math.PI / 2), new Vector2(playerone.playerTexture.Width / 2, playerone.playerTexture.Height / 2), 1f, SpriteEffects.None, 1);
        }
        private void DrawPunkte()
        {
            spriteBatch.DrawString(font, "Press: 1,2,3 for Fire / Space for Restart       Points = " + Punkte.ToString() + "      Highscore = " + highscore.ToString(), new Vector2(50, 10), Color.White);
        }
    }
}