using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathUtility;

namespace Project2D
{
    class Bullet : SceneObject
    {
        SpriteObject bulletSprite = new SpriteObject();
        static Texture2D bulletTexture = LoadTextureFromImage(LoadImage("./Images/bulletRed.png"));


        private float bulletSpeed = 50, bulletAcceleration = 166.666667f, maxSpeed = 550;

        public Bullet()
        {
            bulletSprite.SetTexture(bulletTexture);
            bulletSprite.SetPosition(-bulletSprite.Width / 2.0f, 0);
            AddChild(bulletSprite);
        }

        public override void OnUpdate(float deltaTime)
        {
            if (maxSpeed > bulletSpeed)
            {
                bulletSpeed += bulletAcceleration * deltaTime;
                if (bulletSpeed > maxSpeed)
                {
                    bulletSpeed = maxSpeed;
                }
            }

            float bulletAngle = -(float)Math.Atan2(localTransform.m5, localTransform.m4);

            Translate(-(float)Math.Cos(bulletAngle) * bulletSpeed * deltaTime, (float)Math.Sin(bulletAngle) * bulletSpeed * deltaTime);

            if (globalTransform.m7 < 0 || globalTransform.m7 > GetScreenWidth() ||
                    globalTransform.m8 < 0 || globalTransform.m8 > GetScreenHeight())
            {
                Rotate((float)Math.PI);

                if (globalTransform.m7 < 0)
                {
                    globalTransform.m7 = 0;
                }

                if (globalTransform.m8 < 0)
                {
                    globalTransform.m8 = 0;
                }

                if (globalTransform.m7 > GetScreenWidth())
                {
                    globalTransform.m7 = GetScreenWidth();
                }

                if (globalTransform.m8 > GetScreenHeight())
                {
                    globalTransform.m8 = GetScreenHeight();
                }
            }
        }
    }
}
