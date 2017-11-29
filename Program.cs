using System;
using Game;
using Utils;
using Cards;
namespace Dungeon404
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Game game = new Game.Game();
            game.Init().Start();
            // System.Collections.Generic.List<Cards.Hero> list = Utils.Parser.ParseHeroes();
            // foreach(Cards.Hero item in list){
            //     System.Console.WriteLine(item.ToString());
            //     item.PrintArt();
            // }
        }
    }
}