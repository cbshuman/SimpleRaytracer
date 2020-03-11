using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public abstract class RenderObject
        {
        public abstract void CheckCollision(Ray inputRay);
        }
    }
