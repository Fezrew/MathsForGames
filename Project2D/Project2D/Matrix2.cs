using System;
using System.Collections.Generic;
using System.Text;

namespace Project2D
{
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

        #region Operators
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
        #endregion

        Matrix2 GetTransposed()
        {
            // flip row and column
            return new Matrix2(
           m1, m3,
           m2, m4);
        }
    }
}