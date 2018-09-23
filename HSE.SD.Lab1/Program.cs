using System;
using System.IO;

namespace HSE.SD.Lab1
{
    class Program
    {
        static void Main()
        {
            string file = File.ReadAllText("input.txt");
            string[] lines = file.Split('\n');

            //Remove \r from lines
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Replace("\r", string.Empty);

            Node tree = Parser.Parse(lines);
            Console.ReadLine();
        }
    }
}
