using System;

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

        public static float Dot(Vector3 value1, Vector3 value2)
            {
            return value1.x * value2.x + value1.y * value2.y + value1.z * value2.z;
            }

        public static Vector3 Cross(Vector3 vectorA, Vector3 vectorB)
            {
            float x = vectorA.y * vectorB.z - vectorB.y * vectorA.z;
            float y = vectorA.z * vectorB.x - vectorB.z * vectorA.x;
            float z = vectorA.x * vectorB.y - vectorB.x * vectorA.y;

            Vector3 returnValue = new Vector3(x,y,z);

            return (returnValue);
            }

        public float Length()
            {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
            }

        public Vector3 GetNormalized()
            {
            float factor = (float)Math.Sqrt((x * x) + (y * y) + (z * z));
            factor = 1f / factor;
            float normalX = x * factor;
            float normalY = y * factor;
            float normalZ = z * factor;

            return (new Vector3(normalX, normalY, normalZ));
            }

        public static Vector3 operator - (Vector3 value)
            {
            return new Vector3(-value.x, -value.y, -value.z);
            }

        public static Vector3 operator -(Vector3 value1, float value2)
            {
            return (new Vector3(value1.x - value2, value1.y - value2, value1.z - value2));
            }

        public static Vector3 operator - (Vector3 value1, Vector3 value2)
            {
            return (new Vector3(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z));
            }

        public static Vector3 operator +(Vector3 value1, Vector3 value2)
            {
            return (new Vector3(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z));
            }

        public static Vector3 operator *(Vector3 value1, float value2)
            {
            return (new Vector3(value1.x * value2, value1.y * value2, value1.z * value2));
            }

        public static Vector3 operator /(Vector3 Vector, float value)
            {
            return (new Vector3(Vector.x / value, Vector.y / value, Vector.z / value));
            }

        public override string ToString()
            {
            return ("X: " + x + "; Y: " + y + "; Z: " +z);
            }
        }
    }