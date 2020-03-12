using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public class DirectionalLamp
        {
        public Vector3 direction;
        public Color color;
        public float intensity;

        public DirectionalLamp(Vector3 direction, Color color, float intensity)
            {
            this.direction = direction.GetNormalized();
            this.color = color;
            this.intensity = intensity;
            }
        }
    }
