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

            //scene.AddLamp(new DirectionalLamp(new Vector3(1, 1, 1), new Color(255, 255, 255), 1));

            scene.AddObject(new Sphere(new Vector3(-1f, 2.5f, -15), 2.5f, new Color(80, 200, 50)));
            scene.AddObject(new Sphere(new Vector3(1, 2, -10), 2.5f, new Color(255, 0, 0)));

            scene.AddObject(new Sphere(new Vector3(5, -3, -15), 2.5f, new Color(100, 100, 200)));

            scene.Render();

            PPMWriter.WriteBitmapToPPM("./save.ppm", scene.GetScreenContents());
            }
        }
    }