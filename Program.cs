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
        }
    }
}