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

        private float bulletSpeed = 50, bulletAcceleration = 20, maxSpeed = 1000;

        public Bullet()
        {
            bulletSprite.Load("./Images/bulletRed.png");
            bulletSprite.SetPosition(-bulletSprite.Width / 2.0f, 0);
            AddChild(bulletSprite);
        }

        public override void OnUpdate(float deltaTime)
        {
            if(maxSpeed > bulletSpeed)
            {
                bulletSpeed += bulletAcceleration * deltaTime;
                if(bulletSpeed > maxSpeed)
                {
                    bulletSpeed = maxSpeed;
                }
            }
            
            Translate(0, bulletSpeed * deltaTime);
        }
    }
}
