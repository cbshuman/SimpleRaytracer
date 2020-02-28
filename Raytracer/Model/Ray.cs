using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public class Ray
        {
        public Vector3 origin;
        public Vector3 direction;

        public Ray(Vector3 origin, Vector3 direction)
            {
            this.origin = origin;
            this.direction = direction;
            }

        internal Color GetCast()
            {
            Color returnColor = new Color();

            return (returnColor);
            }
        }
    }
