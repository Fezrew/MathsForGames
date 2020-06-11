using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    class Bullet : SceneObject
    {
        protected SceneObject bulletObject = new SceneObject();
        public SpriteObject bulletSprite = new SpriteObject();

        public SceneObject BulletObject
        {
            get => bulletObject;
        }
    }
}
