using System;
using System.Collections.Generic;
using System.Text;

namespace Project2D
{
    class Program
    {
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
