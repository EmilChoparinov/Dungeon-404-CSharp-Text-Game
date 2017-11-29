using System;
using Utils;
using Decks;
namespace Dungeon404
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.Renderer.ShowTitle();
            Utils.Parser.ParseExtensions();
            Decks.ExtensionDeck deck = new Decks.ExtensionDeck();
            System.Console.WriteLine(deck);
        }
    }
}
