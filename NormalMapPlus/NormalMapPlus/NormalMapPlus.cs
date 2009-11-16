using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintDotNet;
using PaintDotNet.Effects;
using PaintDotNet.IndirectUI;
using PaintDotNet.PropertySystem;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NormalMapPlus
{
    public class NormalMapPlus : PropertyBasedEffect
    {
        public NormalMapPlus(): base("NormalMapPlus", null, SubmenuNames.Stylize, EffectFlags.Configurable)
        {

        }

        protected override PropertyCollection OnCreatePropertyCollection()
        {
            List<Property> propsBuilder = new List<Property>();
            propsBuilder.Add(new DoubleProperty("X", 0.3, 0, 1));
            propsBuilder.Add(new DoubleProperty("Y", 0.5, 0, 1));
            propsBuilder.Add(new DoubleProperty("Z", 0.11, 0, 1));

            return new PropertyCollection(propsBuilder.ToArray());
        }

        protected override void OnRender(Rectangle[] renderRects, int startIndex, int length)
        {
            EnvironmentParameters.GetSelection(SrcArgs.Bounds);

            float lightX = (float)(double)Token.GetProperty("X").Value;
            float lightY = (float)(double)Token.GetProperty("Y").Value;
            float lightZ = (float)(double)Token.GetProperty("Z").Value;

            Float4 num = new Float4(lightX, lightY, lightZ, 0f);

            for (int i = startIndex; i < (startIndex + length); i++)
            {
                Rectangle rectangle = renderRects[i];
                for (int j = rectangle.Top; j < rectangle.Bottom; j++)
                {
                    Float4 num3;
                    Float4 num4;
                    Float4 num5;
                    Float4 num6;
                    Float4 num7;
                    Float4 num8;
                    Float4 num9;
                    Float4 num10;
                    Float4 num11;
                    if (j == 0)
                    {
                        num3 = (Float4)SrcArgs.Surface[0, j];
                        num4 = num3;
                        num5 = (Float4)SrcArgs.Surface[1, j];
                        num6 = num3;
                        num7 = num6;
                        num8 = num5;
                        num9 = (Float4)SrcArgs.Surface[0, j + 1];
                        num10 = num9;
                        num11 = (Float4)SrcArgs.Surface[1, j + 1];
                        for (int k = rectangle.Left; k < rectangle.Right; k++)
                        {
                            Float4 num14 = ((Float4)((((num3 + (2f * num6)) + num9) - num5) - (2f * num8))) - num11;
                            Float4 num15 = ((Float4)((((num3 + (2f * num4)) + num5) - num9) - (2f * num10))) - num11;
                            float x = Float4.Dot(num14, num);
                            float y = Float4.Dot(num15, num);
                            Float4 num18 = new Float4(x, y, 1f, 0f);
                            num18.Normalize();
                            num18 = (Float4)((num18 * 0.5f) + 0.5f);
                            num18.W = 1f;

                            DstArgs.Surface[k, j] = (ColorBgra)num18;

                            if (k == (rectangle.Right - 1))
                            {
                                break;
                            }
                            num3 = num4;
                            num4 = num5;
                            num5 = (Float4)SrcArgs.Surface[k + 1, j];
                            num6 = num7;
                            num7 = num8;
                            num8 = num5;
                            num9 = num10;
                            num10 = num11;
                            num11 = (Float4)SrcArgs.Surface[k + 1, j + 1];
                        }
                    }
                    else if (j == (rectangle.Bottom - 1))
                    {
                        num3 = (Float4)SrcArgs.Surface[0, j - 1];
                        num4 = num3;
                        num5 = (Float4)SrcArgs.Surface[1, j - 1];
                        num6 = (Float4)SrcArgs.Surface[0, j];
                        num7 = num6;
                        num8 = (Float4)SrcArgs.Surface[1, j];
                        num9 = num6;
                        num10 = num9;
                        num11 = num8;
                        for (int m = rectangle.Left; m < rectangle.Right; m++)
                        {
                            Float4 num20 = ((Float4)((((num3 + (2f * num6)) + num9) - num5) - (2f * num8))) - num11;
                            Float4 num21 = ((Float4)((((num3 + (2f * num4)) + num5) - num9) - (2f * num10))) - num11;
                            float num22 = Float4.Dot(num20, num);
                            float num23 = Float4.Dot(num21, num);
                            Float4 num24 = new Float4(num22, num23, 1f, 0f);
                            num24.Normalize();
                            num24 = (Float4)((num24 * 0.5f) + 0.5f);
                            num24.W = 1f;
                            DstArgs.Surface[m, j] = (ColorBgra)num24;
                            if (m == (rectangle.Right - 1))
                            {
                                break;
                            }
                            num3 = num4;
                            num4 = num5;
                            num5 = (Float4)SrcArgs.Surface[m + 1, j - 1];
                            num6 = num7;
                            num7 = num8;
                            num8 = (Float4)SrcArgs.Surface[m + 1, j];
                            num9 = num10;
                            num10 = num11;
                            num11 = num8;
                        }
                    }
                    else
                    {
                        num3 = (Float4)SrcArgs.Surface[0, j - 1];
                        num4 = num3;
                        num5 = (Float4)SrcArgs.Surface[1, j - 1];
                        num6 = (Float4)SrcArgs.Surface[0, j];
                        num7 = num6;
                        num8 = (Float4)SrcArgs.Surface[1, j];
                        num9 = (Float4)SrcArgs.Surface[0, j + 1];
                        num10 = num9;
                        num11 = (Float4)SrcArgs.Surface[1, j + 1];
                        for (int n = rectangle.Left; n < rectangle.Right; n++)
                        {
                            Float4 num26 = ((Float4)((((num3 + (2f * num6)) + num9) - num5) - (2f * num8))) - num11;
                            Float4 num27 = ((Float4)((((num3 + (2f * num4)) + num5) - num9) - (2f * num10))) - num11;
                            float num28 = Float4.Dot(num26, num);
                            float num29 = Float4.Dot(num27, num);
                            Float4 num30 = new Float4(num28, num29, 1f, 0f);
                            num30.Normalize();
                            num30 = (Float4)((num30 * 0.5f) + 0.5f);
                            num30.W = 1f;
                            DstArgs.Surface[n, j] = (ColorBgra)num30;
                            if (n == (rectangle.Right - 1))
                            {
                                break;
                            }
                            num3 = num4;
                            num4 = num5;
                            num5 = (Float4)SrcArgs.Surface[n + 1, j - 1];
                            num6 = num7;
                            num7 = num8;
                            num8 = (Float4)SrcArgs.Surface[n + 1, j];
                            num9 = num10;
                            num10 = num11;
                            num11 = (Float4)SrcArgs.Surface[n + 1, j + 1];
                        }
                    }
                }
            }
        }
    }
}