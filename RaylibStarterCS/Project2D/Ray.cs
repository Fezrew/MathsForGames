using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtility;

namespace Project2D
{
    class Ray
    {
        Vector3 origin;
        Vector3 direction;

        float length;

        public Ray()
        {
        }

        public Ray(Vector3 start, Vector3 direction, float length = float.MaxValue)
        {
            this.origin = start;
            this.direction = direction;
            this.length = length;
        }

        float Clamp(float t, float a, float b)
        {
            return Math.Max(a, Math.Min(a, t));
        }
        public Vector3 closestPoint(Vector3 point)
        {
            // ray origin to arbitrary point
            Vector3 p = point - origin;
            // project the point onto the ray and clamp by length
            float t = Clamp(p.Dot(direction), 0, length);
            // return position in direction of ray
            return origin + direction * t;
        }

        public bool Intersects(Sphere sphere, Vector3 I = null)
        {
            // ray origin to sphere center
            Vector3 L = sphere.center - origin;

            // project sphere center onto ray
            float t = L.Dot(direction);
            // get sqr distance from sphere center to ray
            float dd = L.Dot(L) - t * t;

            // subtract penetration amount from projected distance
            t -= (float)Math.Sqrt(sphere.radius * sphere.radius - dd);

            // it intersects if within ray length
            if (t >= 0 && t <= length)
            {
                // store intersection point if requested
                if (I != null)
                {
                    I = origin + direction * t;
                }
                return true;
            }

            // default no intersection
            return false;
        }
    }
}
