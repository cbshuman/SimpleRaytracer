using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    class Scene
        {
        //Camera information
        public float fov;
        public int screenHeight;
        public int screenWidth;
        public Color[][] screen;
        public Vector3 cameraPosition;

        public List<RenderObject> objects;

        public Scene(float fov, int screenHeight, int screenWidth)
            {
            this.fov = fov;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;

            screen = new Color[screenWidth][];

            for(int i = 0; i < screen.Length; i++)
                {
                screen[i] = new Color[screenHeight];
                }

            objects = new List<RenderObject>();
            }
        
        public void Render()
            {

            }

        public Color[][] GetScreenContents()
            {
            return (screen);
            }
        }
    }
