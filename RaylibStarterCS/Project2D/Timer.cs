using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project2D
{
    class Timer
    {
        Stopwatch timer = new Stopwatch();
        private long currentTime = 0, lastTime = 0;
        private float deltaTime = 0.005f;
        public Timer()
        {
            timer.Start();
        }

        public void Restart()
        {
            timer.Restart();
        }

        public float Seconds
        {
            get{ return timer.ElapsedMilliseconds / 1000.0f; }
        }

        public float GetDeltaTime()
        {
            lastTime = currentTime;
            currentTime = timer.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            return deltaTime;
        }
    }
}
