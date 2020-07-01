using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Project2D
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern int SetWindowPos(IntPtr wHandle, IntPtr wHandleInsertAfter, int X, int Y, int cx, int cy, uint flags);

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowRect(IntPtr wHandle, out System.Drawing.Rectangle rect);

        static void Main(string[] args)
        {
            Game game = new Game();

            SetConfigFlags(ConfigFlag.FLAG_WINDOW_UNDECORATED);
            InitWindow(1280, 720, "I regret nothing");

            //Workaround for raylib forcing fullscreen upon us trying to make the window 1:1
            System.Drawing.Rectangle desktopRectangle;
            GetWindowRect(GetDesktopWindow(), out desktopRectangle);
            Console.WriteLine("WINDOW RESIZE SHENNANIGANS " + SetWindowPos(GetWindowHandle(), IntPtr.Zero, (desktopRectangle.Width / 2) - (desktopRectangle.Height / 2), 0, desktopRectangle.Height, desktopRectangle.Height, 0x0040));

            game.Init();

            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }

            game.Shutdown();

            CloseWindow();
        }
    }
}
