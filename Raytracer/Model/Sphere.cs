using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    /*
     * Class to define spheres to be rendered
    */
    public class Sphere : RenderObject
        {
        public Vector3 position;
        public float radius;
        public Color color;

        public Sphere(Vector3 position, float radius, Color color)
            {
            this.position = position;
            this.radius = radius;
            this.color = color;
            }
        }
    }
