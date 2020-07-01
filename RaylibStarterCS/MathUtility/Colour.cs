using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtility
{
    public class Colour
    {
        public UInt32 colour;

        public Colour()
        {

        }
        public Colour(UInt32 col)
        {
            colour = col;
        }

        public Colour(byte r, byte g, byte b, byte a)
        {
            SetRed(r);
            SetGreen(g);
            SetBlue(b);
            SetAlpha(a);
        }


        public static bool operator ==(Colour lhs, Colour rhs)
        {
            return lhs.colour == rhs.colour;
        }

        public static bool operator !=(Colour lhs, Colour rhs)
        {
            return lhs.colour != rhs.colour;
        }

        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
            UInt32 value = colour & 0xff000000;
        }
        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);
            UInt32 value = colour & 0x00ff0000;
        }
        public byte GetBlue()
        {
            return (byte)((colour & 0x0000ff00) >> 8);
            UInt32 value = colour & 0x0000ff00;
        }
        public byte GetAlpha()
        {
            return (byte)((colour & 0x000000ff));
            UInt32 value = colour & 0x000000ff;
        }

        public void SetRed(byte r)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)r << 24;
        }
        public void SetGreen(byte g)
        {
            colour = colour & 0xff00ffff;
            colour |= (UInt32)g << 16;
        }
        public void SetBlue(byte b)
        {
            colour = colour & 0xffff00ff;
            colour |= (UInt32)b << 8;
        }
        public void SetAlpha(byte a)
        {
            colour = colour & 0xffffff00;
            colour |= (UInt32)a;
        }
    }
}
