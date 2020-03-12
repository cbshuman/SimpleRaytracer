using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public abstract class RenderObject
        {
        public abstract bool CheckCollision(Ray inputRay, out float distance);
        public abstract void HandleCollision(Ray inputRay);
        public abstract Color GetColor(Ray ray);
        }
    }
