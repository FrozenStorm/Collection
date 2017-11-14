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

namespace _3D_Erde
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;

        Effect effect;
        VertexPositionColor[] vertices;
        Matrix viewMatrix;
        Matrix projectionMatrix;
        short[] indices;

        private int radiusmax = 30;
        private int auflösung = 50;

        float rotation = 0.01f;
        float anglex = 0;
        float anglez = 0;
        float distanz = 0;
        Vector3 camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "3D-Erde";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            device = graphics.GraphicsDevice;

            effect = Content.Load<Effect>("effects");

            SetCamera();
            SetUpVertices();
            SetUpIndices();
        }

        protected override void UnloadContent()
        {
        }
        private void SetCamera()
        {
            camera = new Vector3(0, -4 * radiusmax,0);
            viewMatrix = Matrix.CreateLookAt(camera, new Vector3(0, 0, 0), new Vector3(0, 0, -1));
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);
        }
        private void SetUpVertices()
        {
            vertices = new VertexPositionColor[(auflösung + 1) * (auflösung + 1)];
            double winkelx = 0;
            double winkely = 0;
            float radius = 0;
            for (int x = 0; x <= auflösung; x++)
            {
                winkelx = Math.PI / auflösung * x;
                radius = (float)(Math.Sin(winkelx) * radiusmax);
                for (int y = 0; y <= auflösung; y++)
                {
                    winkely = 2 * Math.PI / auflösung * y;
                    vertices[x + y * (auflösung + 1)].Position = new Vector3((float)Math.Cos(winkely) * radius, (float)(Math.Cos(winkelx) * radiusmax), (float)Math.Sin(winkely) * radius);

                    vertices[x + y * (auflösung + 1)].Color = Color.Blue;
                    if (winkelx > 7 * Math.PI / 8) vertices[x + y * (auflösung + 1)].Color = Color.White;
                    if (winkelx < 1 * Math.PI / 8) vertices[x + y * (auflösung + 1)].Color = Color.White;
                }
            }
        }

        private void SetUpIndices()
        {
            indices = new short[(auflösung) * (auflösung) * 6];
            int counter = 0;
            for (int y = 0; y < auflösung; y++)
            {
                for (int x = 0; x < auflösung; x++)
                {
                    int lowerLeft = x + y * (auflösung + 1);
                    int lowerRight = (x + 1) + y * (auflösung + 1);
                    int topLeft = x + (y + 1) * (auflösung + 1);
                    int topRight = (x + 1) + (y + 1) * (auflösung + 1);

                    indices[counter++] = (short)topLeft;
                    indices[counter++] = (short)lowerRight;
                    indices[counter++] = (short)lowerLeft;

                    indices[counter++] = (short)topLeft;
                    indices[counter++] = (short)topRight;
                    indices[counter++] = (short)lowerRight;
                }
            }
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ProcessKeyboard(gameTime);
            base.Update(gameTime);
        }
        private void ProcessKeyboard(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();
            anglex = 0;
            anglez = 0;
            if (keys.IsKeyDown(Keys.Right))
                anglex = rotation;
            if (keys.IsKeyDown(Keys.Left))
                anglex =- rotation;
            if (keys.IsKeyDown(Keys.Down))
                anglez = rotation;
            if (keys.IsKeyDown(Keys.Up))
                anglez =- rotation;
            if (keys.IsKeyDown(Keys.PageDown))
                distanz--;
            if (keys.IsKeyDown(Keys.PageUp))
                distanz++;
            
            
            /*
            camera.X = (float)(Math.Sin(anglex));
            camera.Z = (float)(Math.Sin(anglez));
            camera.Y = (float)(Math.Cos(anglez) * Math.Cos(anglex));
            camera.Normalize();
            camera = camera * distanz;*/
            camera=Vector3.Transform(camera,Matrix.CreateRotationX(anglez));
            camera=Vector3.Transform(camera, Matrix.CreateRotationZ(anglex));
            viewMatrix = Matrix.CreateLookAt(camera, new Vector3(0, 0, 0), new Vector3(0, 0, -1));
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);
        }
        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.DarkSlateBlue);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            device.RasterizerState = rs;

            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];
            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            Matrix worldMatrix = Matrix.Identity;
            effect.Parameters["xWorld"].SetValue(worldMatrix);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);
            }

            base.Draw(gameTime);
        }
    }
}
