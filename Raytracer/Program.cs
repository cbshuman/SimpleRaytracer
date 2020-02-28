using Raytracer.Model;
using Raytracer.FileWriter;
using System;

namespace Raytracer
    {
    class Program
        {
        static void Main(string[] args)
            {
            Scene scene = new Scene(65f,500,1000, new Color(25,25,80));
            scene.Render();

            PPMWriter.WriteBitmapToPPM("./save.ppm",scene.GetScreenContents());
            }
        }
    }
