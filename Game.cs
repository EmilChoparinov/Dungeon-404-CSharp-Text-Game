using System;
using Player;
using Decks;
using Utils;
using System.Collections.Generic;

namespace Game
{
    class Game
    {
        private List<Player.Player> players;

        private Decks.HeroDeck heroDeck;

        private Decks.ExtensionDeck extensionDeck;
        public Game()
        {
            players = new List<Player.Player>();
            heroDeck = new HeroDeck();
            extensionDeck = new ExtensionDeck();
        }

        public Game init()
        {
            Utils.Renderer.ClearScreen();
            Utils.Renderer.ShowTitle();
            System.Console.Write("How many players will be playing: ");
            string input = Console.ReadLine();
            int playerCount = -1;
            while (!int.TryParse(input, out playerCount) || playerCount < 2 || playerCount > heroDeck.Deck.Count)
            {
                System.Console.WriteLine($"Invalid input. Must be an integer and can only be from 2 or the max player count. (It's currently {heroDeck.Deck.Count-1}\n");
                System.Console.Write("How many players will be playing: ");
                input = Console.ReadLine();
            }
            for(int i = 1; i <= playerCount; i++){
                System.Console.Write($"Player {i}, please typee your name: ");
                input = Console.ReadLine();
                while(input.Length == 0){
                    System.Console.WriteLine("Invalid input. You must have a name!");
                    System.Console.Write($"Player {i}, please type your name: ");
                    input = Console.ReadLine();
                }
                players.Add(new Player.Player(input));
            }
            PrintPlayers();
            System.Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();
            Utils.Renderer.ClearScreen();
            for(int i = 0; i < playerCount; i++){
                System.Console.WriteLine($"For {players[i].Name}");
                System.Console.WriteLine("Pick your hero from this list:");
                System.Console.WriteLine(heroDeck.ToString());
                System.Console.Write("Type a name here: ");
                input = Console.ReadLine();
                Cards.Hero hero = getHeroInDeck(input);
                while(hero == null){
                    System.Console.WriteLine("Invalid input. The name you entered was not one of the available cards!");
                    System.Console.Write("Type a name here: ");
                    input = Console.ReadLine();
                    hero = getHeroInDeck(input);
                }
                heroDeck.Deck.Remove(hero);
                players[i].Hero = hero;
                System.Console.WriteLine($"You chose {players[i].Hero.Name} as your hero!");
                Console.ReadLine();
            }
            return this;
        }


        private Cards.Hero getHeroInDeck(string name){
            for(int i = 0; i < heroDeck.Deck.Count; i++){
                if(heroDeck.Deck[i].Name.Equals(name)){
                    return heroDeck.Deck[i];
                }
            }
            return null;
        }
        private void PrintPlayers(){
            string s = "Players that will be playing this game:\n";
            foreach(Player.Player player in players){
                s += player.ToString() + "\n";
            }
            System.Console.WriteLine(s);
        }

        public void forNow()
        {
            Utils.Parser.ParseExtensions();
            ExtensionDeck deck = new Decks.ExtensionDeck();
            HeroDeck heroDeck = new HeroDeck();
            System.Console.WriteLine(deck);
            System.Console.WriteLine(heroDeck);
        }
    }
}