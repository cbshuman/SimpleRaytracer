using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public abstract class RenderObject
        {
        public float albedo = 32f;
        public float reflectivity = .5f;
        public float bias = (1 / 2000f);
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

                Ray shadowRay = new Ray(collisionPoint + (normal * bias), directionToLamp,-1);
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

            Color reflectionColor = new Color(1, 1, 1);
            if (reflectivity > 0 && ray.recusiveNumber > 0)
                {
                returnValue -= new Color(255, 255, 255) * reflectivity;
                Vector3 reflectionOrigin = collisionPoint + (normal * bias);
                Vector3 reflectionDirection = ray.direction - (normal * (2.0f * Vector3.Dot(ray.direction, normal)));

                Ray reflectionRay = new Ray(reflectionOrigin, reflectionDirection, ray.recusiveNumber - 1);
                reflectionColor = reflectionRay.GetCast(scene);
                }

            returnValue += reflectionColor;

            returnValue.Clamp();
            return (returnValue);
            }

        public abstract bool CheckCollision(Ray inputRay, out float distance);
        public abstract void HandleCollision(Ray inputRay);
        public abstract Vector3 GetNormalAtPoint(Vector3 hitPoint);
        }
    }
