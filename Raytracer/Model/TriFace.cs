using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    class TriFace : Plane
        {
        Vector3 vertA;
        Vector3 vertB;
        Vector3 vertC;

        public float faces;

        public TriFace(Vector3 vertA, Vector3 vertB, Vector3 vertC, Material material) : base(material)
            {
            this.vertA = vertA;
            this.vertB = vertB;
            this.vertC = vertC;

            Vector3 AB = vertB - vertA;
            Vector3 CA = vertC - vertA;

            normal = Vector3.Cross(AB, CA).GetNormalized();
            position = (vertA + vertB + vertC) / 3;
            }

        public override bool CheckCollision(Ray inputRay, out float distance)
            {
            bool returnValue = true;
            float dotNormal = Vector3.Dot(normal, inputRay.direction);

            distance = Vector3.Dot(normal, vertA)/dotNormal;
            float t = (Vector3.Dot(normal, inputRay.origin) + distance)/dotNormal;

            if (dotNormal <= 1e-6 || t < 0)
                {
                returnValue = false;
                }

            Vector3 C;
            Vector3 collisionPoint = inputRay.origin + inputRay.direction*t;

            
            //Check if it's within the polygon
            if (returnValue)
                {
                Vector3 edgeAB = vertB - vertA;
                Vector3 vp0 = collisionPoint - vertA;
                C = Vector3.Cross(edgeAB, vp0);
                returnValue = Vector3.Dot(normal, C) > 0;
                }

            if (returnValue)
                {
                Vector3 edgeCB = vertC - vertB;
                Vector3 vp1 = collisionPoint - vertB;
                C = Vector3.Cross(edgeCB, vp1);
                returnValue = Vector3.Dot(normal, C) > 0;
                }

            if (returnValue)
                {
                Vector3 edgeAC = vertA - vertC;
                Vector3 vp2 = collisionPoint - vertC;
                C = Vector3.Cross(edgeAC, vp2);
                returnValue = Vector3.Dot(normal, C) > 0;
                }
            
            return (returnValue);
            }

        public override Vector3 GetNormalAtPoint(Vector3 hitPoint)
            {
            return (base.GetNormalAtPoint(hitPoint));
            }

        public override void HandleCollision(Ray inputRay)
            {
            }
        }
    }
