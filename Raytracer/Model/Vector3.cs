using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public class Vector3
        {
        public static readonly Vector3 zero = new Vector3(0f, 0f, 0f);
        public static readonly Vector3 unit = new Vector3(1f, 1f, 1f);
        public static readonly Vector3 unitX = new Vector3(1f, 0f, 0f);
        public static readonly Vector3 unitY = new Vector3(0f, 1f, 0f);
        public static readonly Vector3 unitZ = new Vector3(0f, 0f, 1f);
        public static readonly Vector3 up = new Vector3(0f, 1f, 0f);
        public static readonly Vector3 down = new Vector3(0f, -1f, 0f);
        public static readonly Vector3 right = new Vector3(1f, 0f, 0f);
        public static readonly Vector3 left = new Vector3(-1f, 0f, 0f);
        public static readonly Vector3 forward = new Vector3(0f, 0f, -1f);
        public static readonly Vector3 backward = new Vector3(0f, 0f, 1f);

        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
            {
            this.x = x;
            this.y = y;
            this.z = z;
            }

        public static Vector3 Nomalize(Vector3 vector)
            {
            float factor = (float)Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
            factor = 1f / factor;
            return new Vector3(vector.x * factor, vector.y * factor, vector.z * factor);
            }
        }
    }
