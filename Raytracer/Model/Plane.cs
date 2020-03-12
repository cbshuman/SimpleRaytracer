using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    class Plane : RenderObject
        {
        public Vector3 position;
        public Vector3 normal;

        public Plane(Vector3 position, Vector3 normal, Color color)
            {
            this.position = position;
            this.normal = normal.GetNormalized();
            this.color = color;
            }

        public override bool CheckCollision(Ray inputRay, out float distance)
            {
            float dotNormal = Vector3.Dot(normal, inputRay.direction);

            if(dotNormal > 1e-6)
                {
                Vector3 v = position - inputRay.origin;
                distance = Vector3.Dot(v, normal) / dotNormal;
                }
            else
                {
                distance = float.PositiveInfinity;
                }

            return (dotNormal >= 0);
            }

        public override Vector3 GetNormalAtPoint(Vector3 hitPoint)
            {
            return ((-normal).GetNormalized());
            }

        public override void HandleCollision(Ray inputRay)
            {
            //Send out rays from the collision
            }
        }
    }
