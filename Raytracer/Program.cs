using Raytracer.Model;
using Raytracer.FileWriter;
using System;

namespace Raytracer
    {
    class Program
        {
        static void Main(string[] args)
            {
            float bias = (1 / 2000f);

            //Start a new scene
            Scene scene = new Scene(65f, 750, 1500, new Color(25, 25, 80));

            scene.AddLamp(new DirectionalLamp(new Vector3(30, -3, -25), new Color(155, 155, 155), .25f));
            scene.AddLamp(new DirectionalLamp(new Vector3(0,-1,0), new Color(155, 155, 155), .05f));

            //Plane
            scene.AddObject(new Plane(new Vector3(0,-3,0), new Vector3(0,-1,0), new Material(32f, 0f,bias,new Color(155, 155, 155))));
            //Spheres
            scene.AddObject(new Sphere(new Vector3(5, 2.25f, -8),    4.5f, new Material(32f, .75f, bias, new Color(255, 10, 10))));    // Red
            scene.AddObject(new Sphere(new Vector3(-10f, 2.5f, -15),   6f, new Material(32f, .25f, bias, new Color(80, 200, 50)))); // blue
            scene.AddObject(new Sphere(new Vector3(0, 2, -15),       4.5f, new Material(32f,  .1f,  bias, new Color(100, 100, 200))));   // green
            scene.AddObject(new Sphere(new Vector3(-5, 1, -8),        .5f, new Material(32f,    0,  bias, new Color(10, 200, 200))));     // Cyan

            scene.AddObject(new Sphere(new Vector3(2, .15f, -2), .5f, new Material(32f, 1, bias, new Color(255, 255, 255))));     // Cyan


            //Draw the image
            scene.Render();

            //Write the image to file
            PPMWriter.WriteBitmapToPPM("./save.ppm", scene.GetScreenContents());
            }
        }
    }