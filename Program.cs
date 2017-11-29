using System;
using Utils;
using Decks;
namespace Dungeon404
{
    class Program
    {
        static void Main(string[] args)
        {
            showTitle();
            Utils.Parser.ParseExtensions();
            Decks.ExtensionDeck deck = new Decks.ExtensionDeck();
            System.Console.WriteLine(deck);
        }

        static void showTitle(){
            Console.Clear();
            string[] title = System.IO.File.ReadAllLines("title.txt");
            foreach(string line in title) Console.WriteLine(line);
            System.Console.ReadLine();
        }
    }
}
