using System;
using System.Collections.Generic;
using System.Text;

namespace Project2D
{
    public class Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        #region Perpendicular
        Vector2 GetPerpendicularRH()
        {
            return new Vector2(-y, x);
        }

        Vector2 GetPerpendicularLH()
        {
            return new Vector2(y, -x);
        }
        #endregion

        #region Operators
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }

        public static Vector2 operator *(Matrix2 lhs, Vector2 rhs)
        {
            return new Vector2(
                (lhs.m1 * rhs.x) + (lhs.m2 * rhs.y),
                (lhs.m3 * rhs.x) + (lhs.m4 * rhs.y)
                );
        }
        public static Vector2 operator *(Vector2 lhs, Matrix2 rhs)
        {
            return new Vector2(
                (rhs.m1 * lhs.x) + (rhs.m3 * lhs.y),
                (rhs.m2 * lhs.x) + (rhs.m4 * lhs.y)
                );
        }

        public static Vector2 operator /(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs / rhs.x, lhs / rhs.y);
        }
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }
        #endregion

        #region Magnitude
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y);
        }

        public float Distance(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }
        #endregion

        #region Normalisation
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
        }

        public Vector2 GetNormalised()
        {
            return (this / Magnitude());
        }
        #endregion

        #region Dot
        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }

        float AngleBetween(Vector2 other)
        {
            // normalise the vectors
            Vector2 a = GetNormalised();
            Vector2 b = other.GetNormalised();

            // calculate the dot product
            float d = a.x * b.x + a.y * b.y;

            // return the angle between them
            return (float)Math.Acos(d);
        }

        #endregion
    }
}
