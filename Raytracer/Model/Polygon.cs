﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    class Polygon : RenderObject
        {
        public List<Vector3> verts;
        public float faces;

        public override bool CheckCollision(Ray inputRay, out float distance)
            {
            throw new NotImplementedException();
            }

        public override Vector3 GetNormalAtPoint(Vector3 hitPoint)
            {
            throw new NotImplementedException();
            }

        public override void HandleCollision(Ray inputRay)
            {
            throw new NotImplementedException();
            }
        }
    }