using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;


namespace Project2D
{
    public class SpriteObject : SceneObject
    {
        public Texture2D texture = new Texture2D();
        public Image image = new Image();
        public float Width
        {
            get { return texture.width; }
        }
        public float Height
        {
            get { return texture.height; }
        }
        public SpriteObject()
        {
        }
        public void Load(string filename)
        {
            image = LoadImage(filename);
            if (image.width > 0 && image.height > 0)
            {
                texture = LoadTextureFromImage(image);
            }
            else
            {
                Console.WriteLine("Error: you suck");
            }
        }

        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(
            globalTransform.m2, globalTransform.m1);
            DrawTextureEx(
            texture,
            new Raylib.Vector2(globalTransform.m7, globalTransform.m8),
            rotation * (float)(180.0f / Math.PI),
            1, Color.WHITE);
        }
    }
}
