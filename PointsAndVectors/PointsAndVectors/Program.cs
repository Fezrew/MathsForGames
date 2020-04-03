using System;

namespace PointsAndVectors
{
    class Program
    {
        class Vector2
        {
            public float x, y;
        }

        class Vector3
        {
            public float x, y, z;
            
            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            #region Operators
            public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
            {
                return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
            }
            public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
            {
                return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
            }

            public static Vector3 operator *(float lhs, Vector3 rhs)
            {
                return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
            }
            public static Vector3 operator *(Vector3 lhs, float rhs)
            {
                return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
            }

            public static Vector3 operator /(float lhs, Vector3 rhs)
            {
                return new Vector3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
            }
            public static Vector3 operator /(Vector3 lhs, float rhs)
            {
                return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
            }
            #endregion

            public float Magnitude()
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }

            public float MagnitudeSqr()
            {
                return (x * x + y * y + z * z);
            }

            public float Distance(Vector3 other)
            {
                float diffX = x - other.x;
                float diffY = y - other.y;
                float diffZ = z - other.z;
                return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
            }

            public void Normalize()
            {
                float m = Magnitude();
                this.x /= m;
                this.y /= m;
                this.z /= m;
            }

            public Vector3 GetNormalised()
            {
                return (this / Magnitude());
            }

            static void Main()
            {
                Vector3 myVec = new Vector3(1, 1, 1);
                float mag = myVec.Magnitude();
                myVec /= mag;
            }
        }
    }
}
