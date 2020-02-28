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

        public int R
            {
            get => red;
            set
                {
                if (value > 225)
                    {
                    red = 225;
                    }
                else if(value < 0)
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
                else if(value< 0)
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

        public Color()
            {
            R = 0;
            G = 0;
            B = 0;
            }

        public Color(int R, int G, int B)
            {
            this.R = R;
            this.G = G;
            this.B = B;
            }
        }

    }
