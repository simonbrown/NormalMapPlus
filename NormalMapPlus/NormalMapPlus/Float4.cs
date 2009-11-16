using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using PaintDotNet;

namespace NormalMapPlus
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Float4
    {
        public float A;
        public float R;
        public float G;
        public float B;
        public float X
        {
            get
            {
                return this.R;
            }
            set
            {
                this.R = value;
            }
        }
        public float Y
        {
            get
            {
                return this.G;
            }
            set
            {
                this.G = value;
            }
        }
        public float Z
        {
            get
            {
                return this.B;
            }
            set
            {
                this.B = value;
            }
        }
        public float W
        {
            get
            {
                return this.A;
            }
            set
            {
                this.A = value;
            }
        }
        public static explicit operator ColorBgra(Float4 c)
        {
            return ColorBgra.FromBgra((byte)(255f * c.B), (byte)(255f * c.G), (byte)(255f * c.R), (byte)(255f * c.A));
        }

        public static explicit operator Float4(ColorBgra c)
        {
            return FromBgra(((float)c.B) / 255f, ((float)c.G) / 255f, ((float)c.R) / 255f, ((float)c.A) / 255f);
        }

        public static Float4 operator +(Float4 c, float s)
        {
            c.A += s;
            c.B += s;
            c.G += s;
            c.R += s;
            return c;
        }

        public static Float4 operator *(Float4 c, float s)
        {
            c.A *= s;
            c.R *= s;
            c.G *= s;
            c.B *= s;
            return c;
        }

        public static Float4 operator *(float s, Float4 c)
        {
            c.A *= s;
            c.R *= s;
            c.G *= s;
            c.B *= s;
            return c;
        }

        public static Float4 operator +(Float4 c0, Float4 c1)
        {
            c0.A += c1.A;
            c0.R += c1.R;
            c0.G += c1.G;
            c0.B += c1.B;
            return c0;
        }

        public static float Dot(Float4 c0, Float4 c1)
        {
            return ((((c0.A * c1.A) + (c0.B * c1.B)) + (c0.G * c1.G)) + (c0.R * c1.R));
        }

        public static Float4 operator -(Float4 c0, Float4 c1)
        {
            c0.A -= c1.A;
            c0.R -= c1.R;
            c0.G -= c1.G;
            c0.B -= c1.B;
            return c0;
        }

        public void Normalize()
        {
            float num = 1f / ((float)Math.Sqrt((double)((((this.A * this.A) + (this.R * this.R)) + (this.G * this.G)) + (this.B * this.B))));
            this = (Float4)(this * num);
        }

        public Float4(float x, float y, float z, float w)
        {
            this.R = x;
            this.G = y;
            this.B = z;
            this.A = w;
        }

        public static Float4 FromBgra(float b, float g, float r, float a)
        {
            Float4 num = new Float4();
            num.A = a;
            num.B = b;
            num.G = g;
            num.R = r;
            return num;
        }
    }
}
