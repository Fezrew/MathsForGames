using System;
using System.Collections.Generic;
using System.Text;

namespace MathUtility
{
    public class Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        #region Operators
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        }
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w),
                (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w),
                (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w),
                (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w)
                );
        }
        public static Vector4 operator *(Vector4 lhs, Matrix4 rhs)
        {
            return new Vector4(
                (rhs.m1 * lhs.x) + (rhs.m5 * lhs.y) + (rhs.m9 * lhs.z) + (rhs.m13 * lhs.w),
                (rhs.m2 * lhs.x) + (rhs.m6 * lhs.y) + (rhs.m10 * lhs.z) + (rhs.m14 * lhs.w),
                (rhs.m3 * lhs.x) + (rhs.m7 * lhs.y) + (rhs.m11 * lhs.z) + (rhs.m15 * lhs.w),
                (rhs.m4 * lhs.x) + (rhs.m8 * lhs.y) + (rhs.m12 * lhs.z) + (rhs.m16 * lhs.w)
                );
        }

        public static Vector4 operator /(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        }
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }
        #endregion

        #region Magnitude
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z + w * w);
        }

        public float Distance(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            float diffW = w - other.w;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ + diffW * diffW);
        }
        #endregion

        #region Normalisation
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
            this.w /= w;
        }

        public Vector4 GetNormalised()
        {
            return (this / Magnitude());
        }
        #endregion

        #region Dot&Cross
        public float Dot(Vector4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }

        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4(
           y * rhs.z - z * rhs.y,
           z * rhs.x - x * rhs.z,
           x * rhs.y - y * rhs.x,
           0);
        }

        float AngleBetween(Vector4 other)
        {
            // normalise the vectors
            Vector4 a = GetNormalised();
            Vector4 b = other.GetNormalised();

            // calculate the dot product
            float d = a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;

            // return the angle between them
            return (float)Math.Acos(d);
        }

        #endregion
    }

}
