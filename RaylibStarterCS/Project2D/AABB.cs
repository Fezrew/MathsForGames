using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtility;

namespace Project2D
{
    class AABB
    {
        Vector3 min = new Vector3(
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);

        Vector3 max = new Vector3(
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);

        public bool IsEmpty()
        {
            if (float.IsNegativeInfinity(min.x) &&
           float.IsNegativeInfinity(min.y) &&
           float.IsNegativeInfinity(min.z) &&
           float.IsInfinity(max.x) &&
           float.IsInfinity(max.y) &&
           float.IsInfinity(max.z))
                return true;

            return false;
        }

        public void Empty()
        {
            min = new Vector3(float.NegativeInfinity,
           float.NegativeInfinity,
           float.NegativeInfinity);
            max = new Vector3(float.PositiveInfinity,
           float.PositiveInfinity,
           float.PositiveInfinity);
        }

        void SetToTransformedBox(AABB box, Matrix3 m)
        {
            // If we're empty, then exit (an empty box defined as having the min/max
            // set to infinity)
            if (box.IsEmpty())
            {
                Empty();
                return;
            }
            // Examine each of the nine matrix elements
            // and compute the new AABB
            if (m.m1 > 0.0f)
            {
                min.x += m.m1 * box.min.x; 
                max.x += m.m1 * box.max.x;
            }
            else
            {
                min.x += m.m1 * box.max.x; 
                max.x += m.m1 * box.min.x;
            }

            if (m.m2 > 0.0f)
            {
                min.y += m.m2 * box.min.x; 
                max.y += m.m2 * box.max.x;
            }
            else
            {
                min.y += m.m2 * box.max.x; 
                max.y += m.m2 * box.min.x;
            }
            if (m.m3 > 0.0f)
            {
                min.z += m.m3 * box.min.x; 
                max.z += m.m3 * box.max.x;
            }
            else
            {
                min.z += m.m3 * box.max.x; 
                max.z += m.m3 * box.min.x;
            }

            if (m.m4 > 0.0f)
            {
                min.x += m.m4 * box.min.y;
                max.x += m.m4 * box.max.y;
            }
            else
            {
                min.x += m.m4 * box.max.y;
                max.x += m.m4 * box.min.y;
            }

            if (m.m5 > 0.0f)
            {
                min.y += m.m5 * box.min.y;
                max.y += m.m5 * box.max.y;
            }
            else
            {
                min.y += m.m5 * box.max.y;
                max.y += m.m5 * box.min.y;
            }
            if (m.m6 > 0.0f)
            {
                min.z += m.m6 * box.min.y;
                max.z += m.m6 * box.max.y;
            }
            else
            {
                min.z += m.m6 * box.max.y;
                max.z += m.m6 * box.min.y;
            }
            if (m.m7 > 0.0f)
            {
                min.x += m.m7 * box.min.z;
                max.x += m.m7 * box.max.z;
            }
            else
            {
                min.x += m.m7 * box.max.z;
                max.x += m.m7 * box.min.z;
            }

            if (m.m8 > 0.0f)
            {
                min.y += m.m8 * box.min.z;
                max.y += m.m8 * box.max.z;
            }
            else
            {
                min.y += m.m8 * box.max.z;
                max.y += m.m8 * box.min.z;
            }
            if (m.m9 > 0.0f)
            {
                min.z += m.m9 * box.min.z;
                max.z += m.m9 * box.max.z;
            }
            else
            {
                min.z += m.m9 * box.max.z;
                max.z += m.m9 * box.min.z;
            }
        }
    }
}

