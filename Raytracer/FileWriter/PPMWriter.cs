using Raytracer.Model;
using System;
using System.IO;

namespace Raytracer.FileWriter
    {
    public static class PPMWriter
        {
        /*
         * Simple PPM writer to write the results to file.
        */
        public static void WriteBitmapToPPM(string file, Color[][] bitmap)
            {
            int width = bitmap.Length;
            int height = bitmap[0].Length;
            //Use a streamwriter to write the text part of the encoding
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("P3");
            writer.WriteLine($"{width}  {height}");
            writer.WriteLine("255");
            for (int y = 0; y < height; y++)
                {
                for (int x = 0; x < width; x++)
                    {
                    Color color = bitmap[x][y];
                    writer.Write(color.R + " ");
                    writer.Write(color.G + " ");
                    writer.Write(color.B + "\n");
                    }
                }

            writer.Close();
            }
        }
    }
