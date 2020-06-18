//#define aie

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathUtility;

namespace Project2D
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0, lastTime = 0;
        private float timer = 0, deltaTime = 0.005f;
        private int fps = 1;
        public int tanks = 1;
        public int bullets = 0;
        private int frames;

        //Image logo;
        //Texture2D texture;

        public List<SceneObject> SObject = new List<SceneObject>();
        Tank tank;

        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            tank = new Tank(this);

            SObject.Add(tank);

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

#if aie
            //logo = LoadImage("..\\Images\\aie-logo-dark.jpg");
            //logo = LoadImage(@"..\Images\aie-logo-dark.jpg");
            logo = LoadImage("../Images/aie-logo-dark.jpg");
            texture = LoadTextureFromImage(logo);
#endif
        }

        public void Shutdown()
        {
        }

        public void Update()
        {
            lastTime = currentTime;

            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;

            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            lastTime = currentTime;

            for (int i = 0; i < SObject.Count(); i++)
            {
                SObject[i].Update(deltaTime);
            }
        }

        public void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.WHITE);

            foreach (SceneObject so in SObject)
            {
                so.Draw();
            }

            DrawText(fps.ToString(), 10, 20, 32, Color.RED);
            DrawText(tanks.ToString(), 200, 20, 32, Color.RED);
            DrawText(bullets.ToString(), 300, 20, 32, Color.RED);

            EndDrawing();
        }
    }
}
