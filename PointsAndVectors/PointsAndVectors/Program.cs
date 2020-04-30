using System;

namespace MathUtility
{
    class Program
    {
        class Vector2
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

            public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
            {
                return new Vector3(
                    (lhs.m1 * rhs.x) + (lhs.m2 * rhs.y) + (lhs.m3 * rhs.z), 
                    (lhs.m4 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m6 * rhs.z),
                    (lhs.m7 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m9 * rhs.z)
                    );
            }
            public static Vector3 operator *(Vector3 lhs, Matrix3 rhs)
            {
                return new Vector3(
                    (rhs.m1 * lhs.x) + (rhs.m4 * lhs.y) + (rhs.m7 * lhs.z), 
                    (rhs.m2 * lhs.x) + (rhs.m5 * lhs.y) + (rhs.m8 * lhs.z),
                    (rhs.m3 * lhs.x) + (rhs.m6 * lhs.y) + (rhs.m9 * lhs.z)
                    );
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
            #endregion

            #region Dot&Cross
            public float Dot(Vector3 rhs)
            {
                return x * rhs.x + y * rhs.y + z * rhs.z;
            }

            public Vector3 Cross(Vector3 rhs)
            {
                return new Vector3(
               y * rhs.z - z * rhs.y,
               z * rhs.x - x * rhs.z,
               x * rhs.y - y * rhs.x);
            }

            float AngleBetween(Vector3 other)
            {
                // normalise the vectors
                Vector3 a = GetNormalised();
                Vector3 b = other.GetNormalised();

                // calculate the dot product
                float d = a.x * b.x + a.y * b.y + a.z * b.z;

                // return the angle between them
                return (float)Math.Acos(d);
            }

            #endregion

            static void VectorMain()
            {
                Vector3 Vec1 = new Vector3(0.857f, 0, -0.514f);
                Vector3 Vec2 = new Vector3(-7.5f, 0, 7);
                Vector3 Vec3 = new Vector3(10, 0, 18);
                Vector3 Upward = new Vector3(0, 1, 0);

                //Dot&Cross
                //Vector3 Forward = Vec1 - Vec2;
                //Vector3 Right = Forward.Cross(Upward);
                //Console.WriteLine($"Forward Vector: {Forward.x}, {Forward.y}, {Forward.z}" +
                //    $"\nRightHand Vector: {Right.x}, {Right.y}, {Right.z}");
                //Vector3 EnemyToPlayer = Vec3 - Vec2;
                //float IsRight = Right.Dot(EnemyToPlayer);
                //float IsInFront = Forward.AngleBetween(EnemyToPlayer);
                //if(IsRight >= 0)
                //{
                //    Console.WriteLine("\nYou are to the right of the enemy");
                //}
                //else
                //{
                //    Console.WriteLine("\nYou are not to the right of the enemy");
                //}
                //if(IsInFront <= 90 && IsInFront >= -90)
                //{
                //    Console.WriteLine("\nYou are in front of the enemy");
                //}
                //else
                //{
                //    Console.WriteLine("\nYou are not in front of the enemy");
                //}


                //Magnitude&Distance
                //float mag = Vec1.Magnitude();
                //float dist = Vec1.Distance(Vec2);
                //Console.WriteLine($"{dist}");

                //Normalisation Code
                //myVec /= mag;

                Console.ReadKey();
            }

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
            // Question 4
            // 
            // You are to the right of the enemy
            // You are within a 90 degree field-of-view from the Enemy A.I.
            //
            #endregion
        }

        class Vector4
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
                    (lhs.m1 * rhs.x) + (lhs.m2 * rhs.y) + (lhs.m3 * rhs.z) + (lhs.m4 * rhs.w), 
                    (lhs.m5 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m7 * rhs.z) + (lhs.m8 * rhs.w), 
                    (lhs.m9 * rhs.x) + (lhs.m10 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m12 * rhs.w),
                    (lhs.m13 * rhs.x) + (lhs.m14 * rhs.y) + (lhs.m15 * rhs.z) + (lhs.m16 * rhs.w)
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

        public class Matrix2
        {
            public readonly static Matrix2 identity = new Matrix2(
                1, 0,
                0, 1
                );

            public float m1, m2, m3, m4;
            public Matrix2()
            {
                m1 = 1; m2 = 0;
                m3 = 0; m4 = 1;

            }

            public Matrix2(float m1, float m2, float m3, float m4)
            {
                this.m1 = m1;
                this.m2 = m2;
                this.m3 = m3;
                this.m4 = m4;
            }

            public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
            {
                return new Matrix2(
                lhs.m1 * rhs.m1 + lhs.m2 * rhs.m3, lhs.m1 * rhs.m2 + lhs.m2 * rhs.m4,
                lhs.m3 * rhs.m1 + lhs.m4 * rhs.m3, lhs.m3 * rhs.m2 + lhs.m4 * rhs.m4);
            }

            public static Matrix2 operator -(Matrix2 lhs, Matrix2 rhs)
            {
                return new Matrix2(
                    lhs.m1 - rhs.m1, lhs.m2 - rhs.m2, 
                    lhs.m3 - rhs.m3, lhs.m4 - rhs.m4
                    );
            }
            public static Matrix2 operator +(Matrix2 lhs, Matrix2 rhs)
            {
                return new Matrix2(
                    lhs.m1 + rhs.m1, lhs.m2 + rhs.m2, 
                    lhs.m3 + rhs.m3, lhs.m4 + rhs.m4
                    );
            }

            Matrix2 GetTransposed()
            {
                // flip row and column
                return new Matrix2(
               m1, m3,
               m2, m4);
            }
        }

        public class Matrix3
        {
            public readonly static Matrix3 identity = new Matrix3(
                1, 0, 0,
                0, 1, 0,
                0, 0, 1);

            public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
            public Matrix3()
            {
                m1 = 1; m2 = 0; m3 = 0;
                m4 = 0; m5 = 1; m6 = 0;
                m7 = 0; m8 = 0; m9 = 1;

            }

            public Matrix3(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
            {
                this.m1 = m1;
                this.m2 = m2;
                this.m3 = m3;
                this.m4 = m4;
                this.m5 = m5;
                this.m6 = m6;
                this.m7 = m7;
                this.m8 = m8;
                this.m9 = m9;
            }

            public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3(
                rhs.m1 * lhs.m1 + rhs.m4 * lhs.m2 + rhs.m7 * lhs.m3, rhs.m2 * lhs.m1 + rhs.m5 * lhs.m2 + rhs.m8 * lhs.m3, rhs.m3 * lhs.m1 + rhs.m6 * lhs.m2 + rhs.m9 * lhs.m3,
                rhs.m1 * lhs.m4 + rhs.m4 * lhs.m5 + rhs.m7 * lhs.m6, rhs.m2 * lhs.m4 + rhs.m5 * lhs.m5 + rhs.m8 * lhs.m6, rhs.m3 * lhs.m4 + rhs.m6 * lhs.m5 + rhs.m9 * lhs.m6,
                rhs.m1 * lhs.m7 + rhs.m4 * lhs.m8 + rhs.m7 * lhs.m9, rhs.m2 * lhs.m7 + rhs.m5 * lhs.m8 + rhs.m8 * lhs.m9, rhs.m3 * lhs.m7 + rhs.m6 * lhs.m8 + rhs.m9 * lhs.m9);
            }

            public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3(
                    lhs.m1 - rhs.m1, lhs.m2 - rhs.m2, lhs.m3 - rhs.m3,
                    lhs.m4 - rhs.m4, lhs.m5 - rhs.m5, lhs.m6 - rhs.m6,
                    lhs.m7 - rhs.m7, lhs.m8 - rhs.m8, lhs.m9 - rhs.m9
                    );
            }
            public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3(
                    lhs.m1 + rhs.m1, lhs.m2 + rhs.m2, lhs.m3 + rhs.m3,
                    lhs.m4 + rhs.m4, lhs.m5 + rhs.m5, lhs.m6 + rhs.m6,
                    lhs.m7 + rhs.m7, lhs.m8 + rhs.m8, lhs.m9 + rhs.m9
                    );
            }

            Matrix3 GetTransposed()
            {
                // flip row and column
                return new Matrix3(
               m1, m4, m7,
               m2, m5, m8,
               m3, m6, m9);
            }
        }

        public class Matrix4
        {
            public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
            public Matrix4()
            {
                m1 = 1; m2 = 0; m3 = 0; m4 = 0;
                m5 = 0; m6 = 1; m7 = 0; m8 = 0; 
                m9 = 0; m10 = 0; m11 =1; m12 = 0;
                m13 = 0; m14 = 0; m15 = 0; m16 = 1;

            }

            public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
            {
                this.m1 = m1;
                this.m2 = m2;
                this.m3 = m3;
                this.m4 = m4;
                this.m5 = m5;
                this.m6 = m6;
                this.m7 = m7;
                this.m8 = m8;
                this.m9 = m9;
                this.m10 = m10;
                this.m11 = m11;
                this.m12 = m12;
                this.m13 = m13;
                this.m14 = m14;
                this.m15 = m15;
                this.m16 = m16;
            }

            public static Matrix4 operator *(Matrix4 rhs, Matrix4 lhs)
            {
                return new Matrix4(
                     rhs.m1 * lhs.m1 + rhs.m5 * lhs.m2 + rhs.m9 * lhs.m3 + rhs.m13 * lhs.m4, rhs.m2 * lhs.m1 + rhs.m6 * lhs.m2 + rhs.m10 * lhs.m3 + rhs.m14 * lhs.m4, rhs.m3 * lhs.m1 + rhs.m7 * lhs.m2 + rhs.m11 * lhs.m3 + rhs.m15 * lhs.m4, rhs.m4 * lhs.m1 + rhs.m8 * lhs.m2 + rhs.m12 * lhs.m3 + rhs.m16 * lhs.m4,
                     rhs.m1 * lhs.m5 + rhs.m5 * lhs.m6 + rhs.m9 * lhs.m7 + rhs.m13 * lhs.m8, rhs.m2 * lhs.m5 + rhs.m6 * lhs.m6 + rhs.m10 * lhs.m7 + rhs.m14 * lhs.m8, rhs.m3 * lhs.m5 + rhs.m7 * lhs.m6 + rhs.m11 * lhs.m7 + rhs.m15 * lhs.m8, rhs.m4 * lhs.m5 + rhs.m8 * lhs.m6 + rhs.m12 * lhs.m7 + rhs.m16 * lhs.m8,
                     rhs.m1 * lhs.m9 + rhs.m5 * lhs.m10 + rhs.m9 * lhs.m11 + rhs.m13 * lhs.m12, rhs.m2 * lhs.m9 + rhs.m6 * lhs.m10 + rhs.m10 * lhs.m11 + rhs.m14 * lhs.m12, rhs.m3 * lhs.m9 + rhs.m7 * lhs.m10 + rhs.m11 * lhs.m11 + rhs.m15 * lhs.m12, rhs.m4 * lhs.m9 + rhs.m8 * lhs.m10 + rhs.m12 * lhs.m11 + rhs.m16 * lhs.m12,
                     rhs.m1 * lhs.m13 + rhs.m5 * lhs.m14 + rhs.m9 * lhs.m15 + rhs.m13 * lhs.m16, rhs.m2 * lhs.m13 + rhs.m6 * lhs.m14 + rhs.m10 * lhs.m15 + rhs.m14 * lhs.m16, rhs.m3 * lhs.m13 + rhs.m7 * lhs.m14 + rhs.m11 * lhs.m15 + rhs.m15 * lhs.m16, rhs.m4 * lhs.m13 + rhs.m8 * lhs.m14 + rhs.m12 * lhs.m15 + rhs.m16 * lhs.m16
                    );
            }

            public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
            {
                return new Matrix4(
                    lhs.m1 - rhs.m1, lhs.m2 - rhs.m2, lhs.m3 - rhs.m3, lhs.m4 - rhs.m4,
                    lhs.m5 - rhs.m5, lhs.m6 - rhs.m6, lhs.m7 - rhs.m7, lhs.m8 - rhs.m8, 
                    lhs.m9 - rhs.m9, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12,
                    lhs.m13 - rhs.m13, lhs.m14 - rhs.m14, lhs.m15 - rhs.m15, lhs.m16 - rhs.m16
                    );
            }
            public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
            {
                return new Matrix4(
                    lhs.m1 + rhs.m1, lhs.m2 + rhs.m2, lhs.m3 + rhs.m3, lhs.m4 + rhs.m4,
                    lhs.m5 + rhs.m5, lhs.m6 + rhs.m6, lhs.m7 + rhs.m7, lhs.m8 + rhs.m8,
                    lhs.m9 + rhs.m9, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12,
                    lhs.m13 + rhs.m13, lhs.m14 + rhs.m14, lhs.m15 + rhs.m15, lhs.m16 + rhs.m16
                    );
            }

            Matrix4 GetTransposed()
            {
                // flip row and column
                return new Matrix4(
               m1, m5, m9, m13,
               m2, m6, m10, m14,
               m3, m7, m11, m15,
               m4, m8, m12, m16
               );
            }
        }

        static void Main()
        {
            Matrix3 Mat1 = new Matrix3(
                1, 4, 7,
                2, 5, 8,
                3, 6, 9
                );
            Matrix3 Mat2 = new Matrix3(
                9, 6, 3,
                8, 5, 2,
                7, 4, 1
                );
            Matrix3 Mat3 = new Matrix3(
                90, 54, 18,
                114, 69, 24,
                138, 84, 30
                );
            Vector3 Vec1 = new Vector3(2, 4, 6);

            Matrix3 Goal1 = new Matrix3(
                90, 54, 18,
                114, 69, 24,
                138, 84, 30
                );
            Vector3 Goal2 = new Vector3(504, 648, 792);

            Matrix3 Res1 = Mat1 * Mat2;
            Vector3 Res2 = Mat3 * Vec1;

            Console.WriteLine(
                $"{Res1.m1}, {Res1.m2}, {Res1.m3},\n" +
                $"{Res1.m4}, {Res1.m5}, {Res1.m6},\n" +
                $"{Res1.m7}, {Res1.m8}, {Res1.m9}\n" +
                $"\n{Res2.x}, {Res2.y}, {Res2.z}\n"
                );
            Console.ReadLine();
        }
    }
}
