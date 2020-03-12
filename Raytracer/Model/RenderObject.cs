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
            Vector3 normal = GetNormalAtPoint(ray.GetPoint(distance));

            //Apply directional lights
            for (int i = 0; i < scene.lamps.Count; i++)
                {
                DirectionalLamp lamp = scene.lamps[i];
                Vector3 directionToLamp = (-lamp.direction).GetNormalized();
                float lightReflected = albedo / MathF.PI;

                //hitColor = hitObject->albedo / M_PI * light->intensity * light->color * std::max(0.f, hitNormal.dotProduct(L));

                Color lightColor = lamp.color * lightReflected * lamp.intensity * MathF.Max(0, Vector3.Dot(directionToLamp, normal));

                returnValue = returnValue * lightColor;
                }

            return (returnValue);
            }

        public abstract bool CheckCollision(Ray inputRay, out float distance);
        public abstract void HandleCollision(Ray inputRay);
        public abstract Vector3 GetNormalAtPoint(Vector3 hitPoint);
        }
    }
