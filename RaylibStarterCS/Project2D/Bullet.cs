using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathUtility;

namespace Project2D
{
    class Bullet : SceneObject
    {
        SpriteObject bulletSprite = new SpriteObject();

        private float bulletSpeed = 50, bulletAcceleration = 166.666667f, maxSpeed = 550;

        public Bullet()
        {
            bulletSprite.Load("./Images/bulletRed.png");
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
        }
    }
}
