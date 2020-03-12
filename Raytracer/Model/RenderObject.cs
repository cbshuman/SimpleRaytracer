using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public abstract class RenderObject
        {
        public float albedo = 32f;
        public Color color;

        public Color GetColor(Ray ray, float distance, Scene scene)
            {
            Color returnValue = new Color(color);
            Vector3 collisionPoint = ray.GetPoint(distance);
            Vector3 normal = GetNormalAtPoint(collisionPoint);

            Color lightColor = new Color(0, 0, 0);

            //Apply directional lights
            for (int i = 0; i < scene.lamps.Count; i++)
                {
                float lightReflected = albedo / MathF.PI;
                DirectionalLamp lamp = scene.lamps[i];
                Vector3 directionToLamp = (-lamp.direction).GetNormalized();

                float lightIntensity = lamp.intensity;

                Ray shadowRay = new Ray(collisionPoint + (normal * (1/2000f)), directionToLamp);
                for (int j = 0; j < scene.objects.Count; j++)
                    {
                    if(scene.objects[j].CheckCollision(shadowRay, out distance))
                        {
                        lightIntensity = 0;
                        break;
                        }
                    }

                lightColor += lamp.color * lightReflected * lightIntensity * MathF.Max(0, Vector3.Dot(directionToLamp, normal));
                }

            returnValue = returnValue * lightColor;
            returnValue.Clamp();
            return (returnValue);
            }

        public abstract bool CheckCollision(Ray inputRay, out float distance);
        public abstract void HandleCollision(Ray inputRay);
        public abstract Vector3 GetNormalAtPoint(Vector3 hitPoint);
        }
    }
