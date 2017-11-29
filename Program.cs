using System;
using Utils;
using Decks;
namespace Dungeon404
{
    class Program
    {
        static void Main(string[] args)
        {
            // Utils.Renderer.ShowTitle();
            Utils.Parser.ParseExtensions();
            ExtensionDeck deck = new Decks.ExtensionDeck();
            HeroDeck heroDeck = new HeroDeck();
            System.Console.WriteLine(deck);
            System.Console.WriteLine(heroDeck);
        }
    }
}
