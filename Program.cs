using System;
namespace Dungeon404
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string[] title = System.IO.File.ReadAllLines("title.txt");
            foreach(string line in title) Console.WriteLine(line);
            System.Console.ReadLine();
        }
    }
}
