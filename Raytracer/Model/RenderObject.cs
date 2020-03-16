using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public abstract class RenderObject
        {
        Material material;

        public RenderObject(Material material)
            {
            this.material = material;
            }

        public Color GetColor(Ray ray, float distance, Scene scene)
            {
            return (material.GetColor(ray,distance,this,scene));
            }

        public abstract bool CheckCollision(Ray inputRay, out float distance);
        public abstract void HandleCollision(Ray inputRay);
        public abstract Vector3 GetNormalAtPoint(Vector3 hitPoint);
        }
    }
