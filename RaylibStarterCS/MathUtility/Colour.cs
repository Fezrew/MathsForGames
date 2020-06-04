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

        public Colour(byte r, byte g, byte b, byte a)
        {

        }

        public byte GetRed()
        {
            throw new NotImplementedException();

        }
        public byte GetGreen()
        {
            throw new NotImplementedException();
        }
        public byte GetBlue()
        {
            throw new NotImplementedException();
        }
        public byte GetAlpha()
        {
            throw new NotImplementedException();
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
