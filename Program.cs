using System;
using Game;
namespace Dungeon404
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Game game = new Game.Game();
            game.Init().start();
            // game.forNow();
        }
    }
}