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
            scene.AddLamp(new DirectionalLamp(new Vector3(0,-1,0), new Color(155, 155, 155), .05f));

            //Plane
            scene.AddObject(new Plane(new Vector3(0,-3,0), new Vector3(0,-1,0), new Color(155, 155, 155)));
            //Spheres
            scene.AddObject(new Sphere(new Vector3(5, 2.25f, -8), 4.5f, new Color(255, 1, 1)));    // Red
            scene.AddObject(new Sphere(new Vector3(-10f, 2.5f, -15), 6f, new Color(80, 200, 50))); // blue
            scene.AddObject(new Sphere(new Vector3(0, 2, -15), 4.5f, new Color(100, 100, 200)));   // green
            scene.AddObject(new Sphere(new Vector3(-5, 1, -8), .5f, new Color(10, 200, 200)));     // Cyan

            scene.Render();

            PPMWriter.WriteBitmapToPPM("./save.ppm", scene.GetScreenContents());
            }
        }
    }