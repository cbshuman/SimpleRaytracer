using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer.Model
    {
    public class Scene
        {
        public const int recursionNumber = 3;
        //Camera information
        public int screenHeight;
        public int screenWidth;
        public float fov;

        //Background colors
        public Color backgroundColor;
        public Color ambientLight;
        public Color[][] screen;

        //Camera position
        public Vector3 cameraPosition;

        //Objects/Lamps
        public List<RenderObject> objects;
        public List<DirectionalLamp> lamps;

        public Scene(float fov, int screenHeight, int screenWidth, Color backgroundColor)
            {
            this.fov = fov;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.backgroundColor = backgroundColor;

            screen = new Color[screenWidth][];

            //Set up the array
            for (int i = 0; i < screen.Length; i++)
                {
                screen[i] = new Color[screenHeight];
                }

            cameraPosition = Vector3.zero;

            objects = new List<RenderObject>();
            lamps = new List<DirectionalLamp>();
            }

        public void Render()
            {
            for (int x = 0; x < screenWidth; x++)
                {
                for (int y = 0; y < screenHeight; y++)
                    {
                    Ray primeRay = CreatePrimeRay(x, y);
                    screen[x][y] = primeRay.GetCast(this);
                    }
                }
            }

        internal void AddObject(RenderObject renderObject)
            {
            objects.Add(renderObject);
            }

        internal void AddLamp(DirectionalLamp lamp)
            {
            lamps.Add(lamp);
            }

        private Ray CreatePrimeRay(float x, float y)
            {
            float aspect_ratio = screenWidth / screenHeight;

            float xDir = (((x + .5f) / screenWidth * 2) - 1) * aspect_ratio;
            float yDir = 1 - ((y + .5f) / screenHeight * 2);

            Ray primeRay = new Ray(cameraPosition, new Vector3(xDir, yDir, -1), recursionNumber);

            return (primeRay);
            }

        public Color[][] GetScreenContents()
            {
            return (screen);
            }
        }
    }