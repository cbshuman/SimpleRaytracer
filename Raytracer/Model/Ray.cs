using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public class Ray
        {
        public Vector3 origin;
        public Vector3 direction;

        public List<Ray> children;

        //What we've collided with
        RenderObject collision = null;

        public Ray(Vector3 origin, Vector3 direction)
            {
            this.origin = origin;
            this.direction = direction.GetNormalized();
            }

        public void AddChild(Ray input)
            {
            children.Add(input);
            }

        public Vector3 GetPoint(float distance)
            {
            Vector3 point = new Vector3(origin.x + (direction.x * distance), origin.y + (direction.y * distance), origin.z + (direction.z * distance));
            return (point);
            }

        internal Color GetCast(Scene scene)
            {
            Color returnColor;
            float distance = -1;

            //Get the closest collision
            for (int i = 0; i < scene.objects.Count; i++)
                {
                float newDistance;
                if(scene.objects[i].CheckCollision(this, out newDistance))
                    {
                    if (collision == null || newDistance < distance)
                        {
                        collision = scene.objects[i];
                        distance = newDistance;
                        }
                    }

                }

            //Build the tree from this point
            if(collision == null)
                {
                returnColor = scene.backgroundColor;
                }
            else
                {
                //Get the color from the tree
                collision.HandleCollision(this);
                returnColor = collision.GetColor(this,distance,scene);
                }

            return (returnColor);
            }
        }
    }
