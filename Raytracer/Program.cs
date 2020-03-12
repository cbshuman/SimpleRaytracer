using Raytracer.Model;
using Raytracer.FileWriter;
using System;

namespace Raytracer
    {
    class Program
        {
        static void Main(string[] args)
            {
            Scene scene = new Scene(65f, 500, 1000, new Color(25, 25, 80));

            scene.AddLamp(new DirectionalLamp(new Vector3(30, -3, -25), new Color(155, 155, 155), .25f));
            scene.AddLamp(new DirectionalLamp(new Vector3(0,-1,0), new Color(155, 155, 155), .15f));

            //Plane
            scene.AddObject(new Plane(new Vector3(0,-3,0), new Vector3(0,-1,0), new Color(105,105,105)));
            //Spheres
            scene.AddObject(new Sphere(new Vector3(5, 2.25f, -8), 4.5f, new Color(255, 0, 0)));    // Red
            scene.AddObject(new Sphere(new Vector3(-10f, 2.5f, -15), 6f, new Color(80, 200, 50))); // Green
            scene.AddObject(new Sphere(new Vector3(0, 2, -15), 4.5f, new Color(100, 100, 200)));   // Blue

            scene.Render();

            PPMWriter.WriteBitmapToPPM("./save.ppm", scene.GetScreenContents());
            }
        }
    }