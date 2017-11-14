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

namespace _3D_Maze_Map
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Effect effect;
        VertexPositionColorNormal[] vertices;
        Matrix viewMatrix;
        Matrix projectionMatrix;

        int mapWidth;
        int mapHeight;
        float wand = 0f;
        float weg = 3f;
        float wegbesucht = 4f;
        float Spieler = 1f;
        float spielerBesucht = 2f;

        int langsam;
        bool finish;
        bool ki;
        bool ki_state;
        Vector2 vorheriger;
        List<Vector2> way = new List<Vector2>();
        List<Vector2> nachbaren = new List<Vector2>();
        Random myrandom = new Random();



        Vector3 cameraposition = new Vector3(0, 0, 0);
        Vector3 cameradirection = new Vector3(0, 0, 10);
        Vector3 camerarotation = new Vector3(0, -1, 0);
        private float angle = 0f;
        short[] indices;

        private float[,] heightData;
        int zoom;
        private float[,] heightDataMaze;


        public struct VertexPositionColorNormal
        {
            public Vector3 Position;
            public Color Color;
            public Vector3 Normal;

            public readonly static VertexDeclaration VertexDeclaration = new VertexDeclaration
            (
                new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                new VertexElement(sizeof(float) * 3, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(sizeof(float) * 3 + 4, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
            );
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            Window.Title = "Riemer's XNA Tutorials -- Series 1";

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            effect = Content.Load<Effect>("effects");
            SetUpCamera();
            mapWidth = 50;
            mapHeight = 50;
            zoom = 2;
            heightData = new float[mapWidth, mapHeight];
            heightDataMaze = new float[mapWidth * zoom, mapHeight * zoom];
            LoadMap();
            SetUpVertices();
            SetUpIndices();
            CalculateNormals();
        }


        protected override void UnloadContent()
        {
        }

        private void SetUpVertices()
        {
            float minHeight = float.MaxValue;
            float maxHeight = float.MinValue;
            for (int x = 0; x < mapWidth * zoom; x++)
            {
                for (int y = 0; y < mapHeight * zoom; y++)
                {
                    if (heightDataMaze[x, y] < minHeight)
                        minHeight = heightDataMaze[x, y];
                    if (heightDataMaze[x, y] > maxHeight)
                        maxHeight = heightDataMaze[x, y];
                }
            }
            vertices = new VertexPositionColorNormal[mapWidth * mapHeight * zoom * zoom];
            for (int x = 0; x < mapWidth * zoom; x++)
            {
                for (int y = 0; y < mapHeight * zoom; y++)
                {
                    vertices[x + y * mapWidth * zoom].Position = new Vector3(x, heightDataMaze[x, y], -y);
                    if (heightDataMaze[x, y] < minHeight + (maxHeight * zoom - minHeight * zoom) / 4)
                        vertices[x + y * mapWidth * zoom].Color = Color.Blue;
                    else if (heightDataMaze[x, y] < minHeight + (maxHeight * zoom - minHeight * zoom) * 2 / 4)
                        vertices[x + y * mapWidth * zoom].Color = Color.Green;
                    else if (heightDataMaze[x, y] < minHeight + (maxHeight * zoom - minHeight * zoom) * 3 / 4)
                        vertices[x + y * mapWidth * zoom].Color = Color.Brown;
                    else
                        vertices[x + y * mapWidth * zoom].Color = Color.White;

                }
            }
        }

        private void heightDatatoXXL()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    for (int k = 0; k < zoom; k++)
                    {
                        for (int n = 0; n < zoom; n++)
                        {
                            heightDataMaze[x * zoom + k, y * zoom + n] = heightData[x, y];
                        }
                    }
                }
            }
        }

        private void LoadMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    heightData[x, y] = wand;
                }
            }
            for (int x = 2; x < mapWidth - 2; x += 2)
            {
                for (int y = 2; y < mapHeight - 2; y += 2)
                {
                    heightData[x, y] = weg;
                }
            }

            way.Clear();
            heightData[2, 2] = wegbesucht;
            way.Add(new Vector2(2, 2));

            heightData[mapWidth - 2, mapHeight - 4] = wegbesucht;
            heightData[mapWidth - 3, mapHeight - 4] = wegbesucht;

            finish = false;
            ki = false;
            heightDatatoXXL();
        }

        private void SetUpIndices()
        {
            indices = new short[(mapWidth * zoom - 1) * (mapHeight * zoom - 1) * 6];
            int counter = 0;
            for (int y = 0; y < mapHeight * zoom - 1; y++)
            {
                for (int x = 0; x < mapWidth * zoom - 1; x++)
                {
                    int lowerLeft = x + y * mapWidth * zoom;
                    int lowerRight = (x + 1) + y * mapWidth * zoom;
                    int topLeft = x + (y + 1) * mapWidth * zoom;
                    int topRight = (x + 1) + (y + 1) * mapWidth * zoom;

                    indices[counter++] = (short)topLeft;
                    indices[counter++] = (short)lowerRight;
                    indices[counter++] = (short)lowerLeft;

                    indices[counter++] = (short)topLeft;
                    indices[counter++] = (short)topRight;
                    indices[counter++] = (short)lowerRight;
                }
            }
        }

        private void CalculateNormals()
        {
            for (int i = 0; i < vertices.Length; i++)
                vertices[i].Normal = new Vector3(0, 0, 0);
            for (int i = 0; i < indices.Length / 3; i++)
            {
                int index1 = indices[i * 3];
                int index2 = indices[i * 3 + 1];
                int index3 = indices[i * 3 + 2];

                Vector3 side1 = vertices[index1].Position - vertices[index3].Position;
                Vector3 side2 = vertices[index1].Position - vertices[index2].Position;
                Vector3 normal = Vector3.Cross(side1, side2);

                vertices[index1].Normal += normal;
                vertices[index2].Normal += normal;
                vertices[index3].Normal += normal;
            }
            for (int i = 0; i < vertices.Length; i++)
                vertices[i].Normal.Normalize();
        }

        private void Generator()
        {
            nachbaren.Clear();
            if (heightData[(int)way.Last<Vector2>().X + 2, (int)way.Last<Vector2>().Y] == weg) nachbaren.Add(new Vector2(way.Last<Vector2>().X + 2, way.Last<Vector2>().Y));
            if (heightData[(int)way.Last<Vector2>().X - 2, (int)way.Last<Vector2>().Y] == weg) nachbaren.Add(new Vector2(way.Last<Vector2>().X - 2, way.Last<Vector2>().Y));
            if (heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 2] == weg) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y + 2));
            if (heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 2] == weg) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y - 2));

            if ((int)nachbaren.LongCount<Vector2>() == 0)
            {
                way.Remove(way.Last<Vector2>());
                if ((int)way.LongCount<Vector2>() == 0)
                {
                    way.Clear();
                    heightData[1, 2] = Spieler;
                    way.Add(new Vector2(1, 2));
                    finish = true;
                }
                else Generator();
            }
            else
            {
                vorheriger = way.Last<Vector2>();
                way.Add(nachbaren[myrandom.Next((int)nachbaren.LongCount<Vector2>())]);
                heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = wegbesucht;
                heightData[(int)(((way.Last<Vector2>().X - vorheriger.X) / 2) + vorheriger.X), (int)(((way.Last<Vector2>().Y - vorheriger.Y) / 2) + vorheriger.Y)] = wegbesucht;
            }
            heightDatatoXXL();
        }

        private void SetUpCamera()
        {
            viewMatrix = Matrix.CreateLookAt(cameraposition, cameradirection, camerarotation);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);//Linse,bildverhältnis,minimale sichtweite,maximale sichtweite
        }


        protected override void Update(GameTime gameTime)
        {
            UpdateCamera();
            if (finish == false) Generator();
            else ProcessKeyboard();
            SetUpVertices();
            SetUpIndices();
            CalculateNormals();
            base.Update(gameTime);
        }

        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
                if (ki == false)
                {
                    if (keybState.IsKeyDown(Keys.D))
                    {
                        if (heightData[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y] == wegbesucht || heightData[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y] == spielerBesucht)
                        {
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = spielerBesucht;
                            way.Add(new Vector2((int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y));
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = Spieler;
                        }
                    }
                    if (keybState.IsKeyDown(Keys.A))
                    {
                        if (heightData[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y] == wegbesucht || heightData[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y] == spielerBesucht)
                        {
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = spielerBesucht;
                            way.Add(new Vector2((int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y));
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = Spieler;
                        }
                    }
                    if (keybState.IsKeyDown(Keys.W))
                    {
                        if (heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] == wegbesucht || heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] == spielerBesucht)
                        {
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = spielerBesucht;
                            way.Add(new Vector2((int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1));
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = Spieler;
                        }
                    }
                    if (keybState.IsKeyDown(Keys.S))
                    {
                        if (heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1] == wegbesucht || heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1] == spielerBesucht)
                        {
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = spielerBesucht;
                            way.Add(new Vector2((int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1));
                            heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = Spieler;
                        }
                    }
                }
                else
                {
                    nachbaren.Clear();
                    if (heightData[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y] == wegbesucht && heightData[(int)way.Last<Vector2>().X + 1, (int)way.Last<Vector2>().Y] != spielerBesucht) nachbaren.Add(new Vector2(way.Last<Vector2>().X + 1, way.Last<Vector2>().Y));
                    if (heightData[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y] == wegbesucht && heightData[(int)way.Last<Vector2>().X - 1, (int)way.Last<Vector2>().Y] != spielerBesucht) nachbaren.Add(new Vector2(way.Last<Vector2>().X - 1, way.Last<Vector2>().Y));
                    if (heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1] == wegbesucht && heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y + 1] != spielerBesucht) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y + 1));
                    if (heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] == wegbesucht && heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y - 1] != spielerBesucht) nachbaren.Add(new Vector2(way.Last<Vector2>().X, way.Last<Vector2>().Y - 1));

                    if ((int)nachbaren.LongCount<Vector2>() == 0)
                    {
                        heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = spielerBesucht;
                        way.Remove(way.Last<Vector2>());
                        if ((int)way.LongCount<Vector2>() == 0)
                        {
                            LoadMap();
                        }
                        heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = Spieler;
                    }
                    else
                    {
                        heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = spielerBesucht;
                        way.Add(nachbaren[myrandom.Next((int)nachbaren.LongCount<Vector2>())]);
                        heightData[(int)way.Last<Vector2>().X, (int)way.Last<Vector2>().Y] = Spieler;
                    }
                    heightDatatoXXL();
                }

                if (keybState.IsKeyDown(Keys.Space)) ki_state = true;
                if (keybState.IsKeyUp(Keys.Space) && ki_state==true)
                {
                    ki_state = false;
                    ki = !ki;
                }
            if (way.Last<Vector2>() == new Vector2(mapWidth - 3, mapHeight - 4)) LoadMap();
            heightDatatoXXL();
        }

        private void UpdateCamera()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Delete))
                angle += 0.05f;
            if (keyState.IsKeyDown(Keys.PageDown))
                angle -= 0.05f;
            if (keyState.IsKeyDown(Keys.Right))
            {
                cameraposition += new Vector3(0.5f, 0, 0);
                cameradirection += new Vector3(0.5f, 0, 0);
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                cameraposition += new Vector3(-0.5f, 0, 0);
                cameradirection += new Vector3(-0.5f, 0, 0);
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                cameraposition += new Vector3(0, 0, 0.5f);
                cameradirection += new Vector3(0, 0, 0.5f);
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                cameraposition += new Vector3(0, 0, -0.5f);
                cameradirection += new Vector3(0, 0, -0.5f);
            }
            if (keyState.IsKeyDown(Keys.Home))
            {
                cameraposition += new Vector3(0, -0.5f, 0);
                cameradirection += new Vector3(0, -0.5f, 0);
            }
            if (keyState.IsKeyDown(Keys.End))
            {
                cameraposition += new Vector3(0, 0.5f, 0);
                cameradirection += new Vector3(0, 0.5f, 0);
            }
            if (keyState.IsKeyDown(Keys.NumPad8))
            {
                cameradirection += new Vector3(0, -0.2f, 0);
            }
            if (keyState.IsKeyDown(Keys.NumPad2))
            {
                cameradirection += new Vector3(0, 0.2f, 0);
            }
            if (keyState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            viewMatrix = Matrix.CreateLookAt(cameraposition, cameradirection, camerarotation);
        }

        protected override void Draw(GameTime gameTime)
        {
            device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);


            RasterizerState rs = new RasterizerState();         //Alle Dreiecke werden gezeichnet auch die die nicht von vorne gesehen werden
            rs.CullMode = CullMode.None;                        //Alle Dreiecke werden gezeichnet auch die die nicht von vorne gesehen werden
            rs.FillMode = FillMode.Solid;
            device.RasterizerState = rs;                        //Alle Dreiecke werden gezeichnet auch die die nicht von vorne gesehen werden

            Matrix worldMatrix = Matrix.CreateTranslation(-mapWidth / 2.0f, 0, mapHeight / 2.0f) * Matrix.CreateRotationY(angle);
            effect.CurrentTechnique = effect.Techniques["Colored"];

            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            effect.Parameters["xWorld"].SetValue(worldMatrix);

            Vector3 lightDirection = new Vector3(1.0f, -1.0f, -1.0f);
            lightDirection.Normalize();
            effect.Parameters["xLightDirection"].SetValue(lightDirection);
            effect.Parameters["xAmbient"].SetValue(0.4f); effect.Parameters["xEnableLighting"].SetValue(true);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColorNormal.VertexDeclaration);

            }
            base.Draw(gameTime);
        }
    }
}
