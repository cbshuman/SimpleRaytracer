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

        public Sphere(Vector3 position, float radius, Color color)
            {
            this.position = position;
            this.radius = radius;
            this.color = color;
            }


        public override bool CheckCollision(Ray inputRay)
            {
            bool returnValue = true;
            Vector3 l = position - inputRay.origin;
            float tca = Vector3.Dot(l, inputRay.direction);
            float radiusSquared = radius * radius;

            if (tca < 0)
                {
                returnValue = false;
                }

            float d2 = Vector3.Dot(l, l) - (tca * tca);
            if (d2 > radiusSquared)
                {
                returnValue = false;
                }

            return (returnValue);
            }

        public override bool CheckCollision(Ray inputRay, out float distance)
            {
            bool returnValue = true;
            Vector3 l = position - inputRay.origin;
            float tca = Vector3.Dot(l, inputRay.direction);
            float radiusSquared = radius * radius;

            if (tca < 0)
                {
                returnValue = false;
                }

            float d2 = Vector3.Dot(l, l) - (tca * tca);
            if (d2 > radiusSquared)
                {
                returnValue = false;
                }

            float thc = MathF.Sqrt(radiusSquared - d2);
            float t0 = tca - thc;
            float t1 = tca + thc;

            if (t0 < t1)
                {
                distance = t0;
                }
            else
                {
                distance = t1;
                }

            return (returnValue);
            }

        public override Vector3 GetNormalAtPoint(Vector3 hitPoint)
            {
            Vector3 normal = hitPoint - position;
            return (normal.GetNormalized());
            }

        public override void HandleCollision(Ray inputRay)
            {
            //Send out rays from the collision
            }
        }
    }
