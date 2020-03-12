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

        public override bool CheckCollision(Ray inputRay, out float distance)
            {
            bool returnValue = true;
            Vector3 l = position - inputRay.origin;
            float tca = Vector3.Dot(l, inputRay.direction);
            if (tca < 0)
                {
                returnValue = false;
                }

            float d2 = Vector3.Dot(l, l) - tca * tca;
            if (d2 > radius * radius)
                {
                returnValue = false;
                }

            float thc = MathF.Sqrt((radius * radius) - d2);
            float t0 = tca - thc;
            float t1 = tca + thc;

            if (t0 > t1)
                {
                distance = t0;
                }
            else
                {
                distance = t1;
                }

            return (returnValue);
            }

        public override Color GetColor(Ray ray)
            {
            Color returnValue = color;

            return (returnValue);
            }

        public override void HandleCollision(Ray inputRay)
            {
            //Send out rays from the collision
            }
        }
    }
