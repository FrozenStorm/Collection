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

namespace Series3D1
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

        Vector3 cameraposition = new Vector3(0, 0, 0);
        Vector3 cameradirection = new Vector3(0, 0, 10);
        Vector3 camerarotation = new Vector3(0, -1, 0);
        private float angle = 0f;
        short[] indices;

        private int terrainWidth = 4;
        private int terrainHeight = 3;
        private float[,] heightData;

        float wave = 0;

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
            LoadHeightData();
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
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    if (heightData[x, y] < minHeight)
                        minHeight = heightData[x, y];
                    if (heightData[x, y] > maxHeight)
                        maxHeight = heightData[x, y];
                }
            }
            vertices = new VertexPositionColorNormal[terrainWidth * terrainHeight];
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, heightData[x, y], -y);
                    if (heightData[x, y] < minHeight + (maxHeight - minHeight) / 4)
                        vertices[x + y * terrainWidth].Color = Color.Blue;
                    else if (heightData[x, y] < minHeight + (maxHeight - minHeight) * 2 / 4)
                        vertices[x + y * terrainWidth].Color = Color.Green;
                    else if (heightData[x, y] < minHeight + (maxHeight - minHeight) * 3 / 4)
                        vertices[x + y * terrainWidth].Color = Color.Brown;
                    else
                        vertices[x + y * terrainWidth].Color = Color.White;

                }
            }
        }


        private void SetUpIndices()
        {
            indices = new short[(terrainWidth - 1) * (terrainHeight - 1) * 6];
            int counter = 0;
            for (int y = 0; y < terrainHeight - 1; y++)
            {
                for (int x = 0; x < terrainWidth - 1; x++)
                {
                    int lowerLeft = x + y * terrainWidth;
                    int lowerRight = (x + 1) + y * terrainWidth;
                    int topLeft = x + (y + 1) * terrainWidth;
                    int topRight = (x + 1) + (y + 1) * terrainWidth;

                    indices[counter++] = (short)topLeft;
                    indices[counter++] = (short)lowerRight;
                    indices[counter++] = (short)lowerLeft;

                    indices[counter++] = (short)topLeft;
                    indices[counter++] = (short)topRight;
                    indices[counter++] = (short)lowerRight;
                }
            }
        }



        private void LoadHeightData()
        {
            terrainWidth = 90;
            terrainHeight = 90;
            wave+=2f;
            heightData = new float[terrainWidth, terrainHeight];
            for (int x = 0; x < terrainWidth; x++)
                for (int y = 0; y < terrainHeight; y++)
                    heightData[x, y] = (float)(Math.Sin((80 * Math.Sqrt(x * x + y * y) - 2 * wave) / 360 * 2 * Math.PI) + 2*Math.Sin((20 * Math.Sqrt(x * x + y * y) - 2 * wave) / 360 * 2 * Math.PI));
            
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


        private void SetUpCamera()
        {
            viewMatrix = Matrix.CreateLookAt(cameraposition, cameradirection, camerarotation);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);//Linse,bildverhältnis,minimale sichtweite,maximale sichtweite
        }

        
        protected override void Update(GameTime gameTime)
        {
            UpdateCamera();
            LoadHeightData();
            SetUpVertices();
            SetUpIndices();
            CalculateNormals();
            base.Update(gameTime);
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

            Matrix worldMatrix = Matrix.CreateTranslation(-terrainWidth / 2.0f, 0, terrainHeight / 2.0f) * Matrix.CreateRotationY(angle);
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
