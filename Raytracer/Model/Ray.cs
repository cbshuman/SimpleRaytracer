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

        public Ray(Vector3 origin, Vector3 direction)
            {
            this.origin = origin;
            this.direction = direction;
            }

        public void AddChild(Ray input)
            {
            children.Add(input);
            }

        internal Color GetCast(Scene scene)
            {
            Color returnColor = new Color();

            RenderObject collision = null;

            //Get the closest collision
            for (int i = 0; i < scene.objects.Count; i++)
                {
                if(collision == null)
                    {

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
                }

            return (returnColor);
            }
        }
    }
