using System;
using System.Collections.Generic;
using System.Text;

namespace MathUtility
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;

        }

        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }

        #region Operators
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
        #endregion

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

        #region Set
        public void Set(Matrix4 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3; m4 = m.m4; 
            m5 = m.m5; m6 = m.m6; m7 = m.m7; m8 = m.m8; 
            m9 = m.m9; m10 = m.m10; m11 = m.m11; m12 = m.m12;
            m13 = m.m13; m14 = m.m14; m15 = m.m15; m16 = m.m16;
        }
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }
        #endregion

        #region Scale
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = v.y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = v.z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        void Scale(float x, float y, float z)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(x, y, z);
            Set(this * m);
        }
        void Scale(Vector3 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }
        #endregion

        #region Rotation
        public void SetRotateX(float radians)
        {
            Set(1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
                0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1
                );
        }
        public void SetRotateY(float radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1
                );
        }
        public void SetRotateZ(float radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );
        }

        public void RotateX(float radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void RotateY(float radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void RotateZ(float radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            // combine rotations in a specific order
            Set(z * y * x);
        }
        #endregion

        #region Translation
        public void SetTranslation(float x, float y, float z)
        {
            m13 = x; m14 = y; m15 = z; m16 = 1;
        }

        void Translate(float x, float y, float z)
        {
            // apply vector offset
            m13 += x; m14 += y; m15 += z;
        }
        #endregion
    }
}
