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

        public override Color GetColor(Ray ray, float distance, Scene scene)
            {
            Color returnValue = new Color(color);
            Vector3 normal = GetNormalAtPoint(ray.origin + (ray.direction * distance));

            //Apply directional lights
            for (int i = 0; i < scene.lamps.Count; i++)
                {
                DirectionalLamp lamp = scene.lamps[i];
                float lightPower = Vector3.Dot((-lamp.direction).GetNormalized(), normal) * lamp.intensity;
                returnValue *= (lamp.color * (lightPower * (float)(reflective/Math.PI)));
                }
            //Console.WriteLine(normal);
            //Console.WriteLine(returnValue);
            return (returnValue);
            }

        public override Vector3 GetNormalAtPoint(Vector3 hitPoint)
            {
            return ((hitPoint - position).GetNormalized());
            }

        public override void HandleCollision(Ray inputRay)
            {
            //Send out rays from the collision
            }
        }
    }
