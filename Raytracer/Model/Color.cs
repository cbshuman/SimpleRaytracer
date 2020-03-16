using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    //Simple class to store colors.
    public class Color
        {
        private int red;
        private int green;
        private int blue;
        private int a;

        public int R
            {
            get => red;
            set
                {
                if (value > 225)
                    {
                    red = 225;
                    }
                else if (value < 0)
                    {
                    red = 0;
                    }
                else
                    {
                    red = value;
                    }
                }
            }

        public int G
            {
            get => green;
            set
                {
                if (value > 225)
                    {
                    green = 225;
                    }
                else if (value < 0)
                    {
                    green = 0;
                    }
                else
                    {
                    green = value;
                    }
                }
            }

        public int B
            {
            get => blue;
            set
                {
                if (value > 225)
                    {
                    blue = 225;
                    }
                else if (value < 0)
                    {
                    blue = 0;
                    }
                else
                    {
                    blue = value;
                    }
                }
            }

        public int A
            {
            get => a;
            set
                {
                if (value > 225)
                    {
                    a = 225;
                    }
                else if (value < 0)
                    {
                    a = 0;
                    }
                else
                    {
                    a = value;
                    }
                }
            }

        public Color()
            {
            R = 0;
            G = 0;
            B = 0;
            }

        public Color(int R, int G, int B)
            {
            this.red = R;
            this.green = G;
            this.blue = B;
            }

        public Color(Color color)
            {
            R = color.R;
            G = color.G;
            B = color.B;
            }

        public static Color operator *(Color value1, float value2)
            {
            return (new Color((int)(value1.red * value2), (int)(value1.green * value2), (int)(value1.blue * value2)));
            }

        public static Color operator *(Color value1, Color value2)
            {
            return (new Color((value1.R * value2.R)/255, (value1.G * value2.G) / 255, (value1.B * value2.B) / 255));
            }

        public static Color operator +(Color value1, Color value2)
            {
            return (new Color(value1.R + value2.R, value1.G + value2.G, value1.B + value2.B));
            }

        public static Color operator -(Color value1, Color value2)
            {
            return (new Color(value1.R - value2.R, value1.G - value2.G, value1.B - value2.B));
            }

        public void Clamp()
            {
            R = red;
            B = blue;
            G = green;
            }

        public override string ToString()
            {
            return("R: '" + R + "' B: '" + B + "' G: '" + G + "'");
            }
        }
    }