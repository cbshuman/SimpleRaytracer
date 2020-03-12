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
                bool inShadow = false;
                float lightReflected = albedo / MathF.PI;
                DirectionalLamp lamp = scene.lamps[i];
                Vector3 directionToLamp = (-lamp.direction).GetNormalized();

                //Check if we are in shadow
                Ray shadowRay = new Ray(collisionPoint, directionToLamp);
                for(i = 0; i < scene.objects.Count; i++)
                    {
                    if (scene.objects[i].CheckCollision(shadowRay))
                        {
                        inShadow = true;
                        break;
                        }
                    }

                //hitColor = hitObject->albedo / M_PI * light->intensity * light->color * std::max(0.f, hitNormal.dotProduct(L));

                float intensity;
                if(inShadow)
                    {
                    intensity = 0;
                    }
                else
                    {
                    intensity = lamp.intensity;
                    }

                lightColor += lamp.color * lightReflected * intensity * MathF.Max(0, Vector3.Dot(directionToLamp, normal));
                }

            returnValue = returnValue * lightColor;
            returnValue.Clamp();
            return (returnValue);
            }

        public abstract bool CheckCollision(Ray inputRay);
        public abstract bool CheckCollision(Ray inputRay, out float distance);
        public abstract void HandleCollision(Ray inputRay);
        public abstract Vector3 GetNormalAtPoint(Vector3 hitPoint);
        }
    }
