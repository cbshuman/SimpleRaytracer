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
        public Color backgroundColor;
        public Color[][] screen;
        public Vector3 cameraPosition;

        public List<RenderObject> objects;

        public Scene(float fov, int screenHeight, int screenWidth, Color backgroundColor)
            {
            this.fov = fov;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.backgroundColor = backgroundColor;

            screen = new Color[screenWidth][];

            //Set up the array
            for(int i = 0; i < screen.Length; i++)
                {
                screen[i] = new Color[screenHeight];
                }

            objects = new List<RenderObject>();
            }
        
        public void Render()
            {
            for(int x = 0; x < screenWidth; x++)
                {
                for(int y = 0; y < screenHeight; y++)
                    {
                    Ray primeRay = CreatePrimeRay(x, y);
                    screen[x][y] = primeRay.GetCast();
                    }
                }
            }

        private Ray CreatePrimeRay(float x, float y)
            {
            float xDir = ((x + .5f) / screenWidth * 2) - 1;
            float yDir = ((y + .5f) / screenHeight * 2) - 1;

            Ray primeRay = new Ray(Vector3.zero,new Vector3(xDir,yDir,0));

            return (primeRay);
            }

        public Color[][] GetScreenContents()
            {
            return (screen);
            }
        }
    }
