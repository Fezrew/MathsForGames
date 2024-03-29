﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathUtility
{
    public class Vector3
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
                (lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z)
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

        #region Min/Max
        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
        }
        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
        }

        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            return Max(a, Min(b, t));
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
}
