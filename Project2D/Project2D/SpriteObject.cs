using System;
using System.Collections.Generic;
using System.Text;


namespace Project2D
{
    public class SpriteObject : SceneObject
    {
        Texture2D texture = new Texture2D();
        Image image = new Image();
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
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);
        }
    }
}
