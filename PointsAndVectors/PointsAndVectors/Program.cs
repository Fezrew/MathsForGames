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

            #region Magnitude
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
            #endregion

            #region Normalisation
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
                Vector3 Vec1 = new Vector3(0, 1, 2);
                Vector3 Vec2 = new Vector3(9, -2, 7);
                float mag = Vec1.Magnitude();
                float dist = Vec1.Distance(Vec2);

                Console.WriteLine($"{dist}");
                Console.ReadKey();

                //Normalisation Code
                //myVec /= mag;
            }
            #endregion

            #region Exercise Answers
            //Question 2 
            // 1, 1, 1 = 1.7320508
            // 3, -2 = 3.6055512
            // -1, -1, -1 = 1.7320508
            // 0.5, -1, 0.25 = 1.145644
            //
            // Question 3
            // Distance between (-2, 5.5) and (9, -22) is 29.618406
            // Distance between (0, 1, 2) and (9, -2, 7) is 10.723805
            //
            //
            //
            //
            //
            #endregion
        }
    }
}
