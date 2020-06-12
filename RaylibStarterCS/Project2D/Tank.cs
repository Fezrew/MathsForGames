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
    class Tank : SceneObject
    {
        private float curBulletDelay, curTankDelay, cantank = 1;
        public float initBulletDelay = 50, initTankDelay = 1;
        protected SceneObject turretObject = new SceneObject();
        public SpriteObject tankSprite = new SpriteObject();
        public SpriteObject turretSprite = new SpriteObject();
        Game game;
        

        public SceneObject TurretObject
        {
            get => turretObject;
        }

        public Tank(Game gm)
        {
            this.game = gm;
            curTankDelay = initTankDelay;
            curBulletDelay = initBulletDelay;

            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject.AddChild(turretSprite);
            AddChild(tankSprite);
            AddChild(turretObject);

            tankSprite.Load("./Images/tankBlue_outline.png");
            // sprite is facing the wrong way... fix that here
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // sets an offset for the base, so it rotates around the centre
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);
            turretSprite.Load("./Images/barrelBlue.png");
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set the turret offset from the tank base
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            // having an empty object for the tank parent means we can set the
            // position/rotation of the tank without
            // affecting the offset of the base sprite
            SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        }

        public override void OnUpdate(float deltaTime)
        {
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                Rotate(-deltaTime * 5);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                Rotate(deltaTime * 5);
            }

            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                MathUtility.Vector3 facing = new MathUtility.Vector3(
                LocalTransform.m1,
                LocalTransform.m2, 1) * deltaTime * 500;
                Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                MathUtility.Vector3 facing = new MathUtility.Vector3(
                LocalTransform.m1,
                LocalTransform.m2, 1) * deltaTime * -250;
                Translate(facing.x, facing.y);
            }

            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime * 20);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime * 20);
            }

            if (IsKeyDown(KeyboardKey.KEY_Z) && curBulletDelay <= 0)
            {
                Bullet bullet = new Bullet();
                bullet.CopyTransformToLocal(turretObject.GlobalTransform);

                bullet.Translate(0, 50);

                game.SObject.Add(bullet);
                curBulletDelay = initBulletDelay;
                game.bullets++;
            }

            if (IsKeyDown(KeyboardKey.KEY_X) && curTankDelay <= 0 && cantank > 0)
            {
                Tank tank2 = new Tank(game);
                game.SObject.Add(tank2);

                tank2.GlobalTransform.Set(
                    TurretObject.GlobalTransform.m1, TurretObject.GlobalTransform.m2, 0,
                    TurretObject.GlobalTransform.m4, TurretObject.GlobalTransform.m5, 0,
                    GetScreenWidth() / 2, GetScreenHeight() / 2, 1);

                tank2.UpdateTransform();
                curTankDelay = initTankDelay;
                cantank--;
                game.tanks++;
            }
            curBulletDelay--;
            curTankDelay--;
            Draw();
        }
    }
}
