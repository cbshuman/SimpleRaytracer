using Raytracer.Model;
using System;
using System.IO;

namespace Raytracer.FileWriter
    {
    public static class FileWriter
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
            writer.WriteLine("P6");
            writer.WriteLine($"{width}  {height}");
            writer.WriteLine("255");
            writer.Close();
            //Switch to a binary writer to write the data
            BinaryWriter writerB = new BinaryWriter(new FileStream(file, FileMode.Append));
            for (int x = 0; x < width; x++)
                {
                for (int y = 0; y < height; y++)
                    {
                    Color color = bitmap[x][y];
                    writerB.Write(color.r);
                    writerB.Write(color.g);
                    writerB.Write(color.b);
                    }
                }

            writerB.Close();
            }
        }
    }
