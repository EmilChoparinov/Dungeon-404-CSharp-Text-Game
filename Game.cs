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

        private List<Player.Player> playersDead;
        Random rand;
        public Game()
        {
            rand = new Random();
            players = new List<Player.Player>();
            heroDeck = new HeroDeck();
            extensionDeck = new ExtensionDeck();
            extensionDeck.shuffle().shuffle();
            playersDead = new List<Player.Player>();
        }

        public Game Init()
        {
            Utils.Renderer.ClearScreen();
            Utils.Renderer.ShowTitle();
            System.Console.Write("How many players will be playing: ");
            string input = Console.ReadLine();
            int playerCount = -1;
            while (!int.TryParse(input, out playerCount) || playerCount < 2 || playerCount > heroDeck.Deck.Count)
            {
                System.Console.WriteLine($"Invalid input. Must be an integer and can only be from 2 or the max player count. (It's currently {heroDeck.Deck.Count})\n");
                System.Console.Write("How many players will be playing: ");
                input = Console.ReadLine();
            }
            System.Console.WriteLine();
            for (int i = 1; i <= playerCount; i++)
            {
                System.Console.Write($"Player {i}, please type your name: ");
                input = Console.ReadLine();
                while (input.Length == 0)
                {
                    System.Console.WriteLine("Invalid input. You must have a name!");
                    System.Console.Write($"Player {i}, please type your name: ");
                    input = Console.ReadLine();
                }
                players.Add(new Player.Player(input));
            }
            System.Console.WriteLine();
            PrintPlayers();
            System.Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();
            Utils.Renderer.ClearScreen();
            for (int i = 0; i < playerCount; i++)
            {
                System.Console.WriteLine($"For {players[i].Name}'s hero setup:");
                System.Console.WriteLine("Pick your hero from this list:\n");
                System.Console.WriteLine(heroDeck.ToString());
                System.Console.Write("Type a name here: ");
                input = Console.ReadLine();
                Cards.Hero hero = getHeroInDeck(input);
                while (hero == null)
                {
                    System.Console.WriteLine("Invalid input. The name you entered was not one of the available cards!");
                    System.Console.Write("Type a name here: ");
                    input = Console.ReadLine();
                    hero = getHeroInDeck(input);
                }
                heroDeck.Deck.Remove(hero);
                players[i].Hero = hero;
                Utils.Renderer.ClearScreen();
                hero.PrintArt();
                System.Console.WriteLine($"You chose {players[i].Hero.Name} as your hero!");
                System.Console.Write("Press enter to setup your extension cards: ");
                Console.ReadLine();
                Utils.Renderer.ClearScreen();
                System.Console.WriteLine($"You drew these three starter cards!");
                for (int j = 0; j < 3; j++)
                {
                    Cards.Extension extension = extensionDeck.deal();
                    System.Console.WriteLine(extension.ToString() + "\n");
                    players[i].addExt(extension);
                    System.Console.WriteLine();
                }
                if (i + 1 == playerCount)
                {
                    System.Console.WriteLine("Press enter to continue:");
                }
                else
                {
                    System.Console.Write("Press enter to let the next player setup his hero: ");

                }
                Console.ReadLine();
                Utils.Renderer.ClearScreen();
            }
            System.Console.WriteLine("Thats it! Press enter one more time to start the game!");
            Console.ReadLine();
            return this;
        }

        public void Start()
        {
            Utils.Renderer.ClearScreen();
            System.Console.WriteLine("Welcome to the game! type help to get a list of actions you can do!\n");
            int curPlayer = 0;
            for (int i = 0; i < this.players.Count; i++)
            {
                if (i == curPlayer)
                {
                    System.Console.Write("you" + this.players[i].Hero.ToString().Substring(3) + "\n\n");
                }
                else
                {
                    System.Console.Write(this.players[i].Hero.ToString() + "\n\n");
                }
            }
            while (true)
            {
                if(this.extensionDeck.Deck.Count == 0){
                    System.Console.WriteLine("The deck doesn't have any more cards! A new deck was made");
                    this.extensionDeck = new ExtensionDeck();
                    this.extensionDeck.shuffle().shuffle();
                }
                if (this.players.Count == 1)
                {
                    GameOver();
                    break;
                }
                System.Console.Write($"\n{players[curPlayer].Name}'s turn: ");
                string input = Console.ReadLine();
                string response = doCommand(input, curPlayer);
                while (response.Equals("fail"))
                {
                    System.Console.WriteLine("Invalid input. That command did not exist!");
                    System.Console.Write($"{players[curPlayer].Name}'s turn: ");
                    input = Console.ReadLine();
                    response = doCommand(input, curPlayer);
                }
                if (response.EndsWith("next"))
                {
                    curPlayer++;
                    curPlayer = curPlayer % this.players.Count;
                    Utils.Renderer.ClearScreen();
                    for (int i = 0; i < this.players.Count; i++)
                    {
                        if (i == curPlayer)
                        {
                            System.Console.Write("you" + this.players[i].Hero.ToString().Substring(3) + "\n\n");
                        }
                        else
                        {
                            System.Console.Write(this.players[i].Hero.ToString() + "\n\n");
                        }
                    }
                }
                if (response.EndsWith("print"))
                {
                    for (int i = 0; i < this.players.Count; i++)
                    {
                        if (i == curPlayer)
                        {
                            System.Console.Write("you" + this.players[i].Hero.ToString().Substring(3) + "\n");
                        }
                        else
                        {
                            System.Console.Write(this.players[i].Hero.ToString() + "\n");
                        }
                    }
                }
            }
        }

        private void GameOver()
        {
            System.Console.WriteLine(String.Join("\n", this.players[0].Hero.Art));
            System.Console.WriteLine($"{this.players[0].Name} won!");
            Console.ReadLine();
        }

        private string doCommand(string input, int curPlayer)
        {
            switch (input)
            {
                case "help":
                    string[] data = System.IO.File.ReadAllLines("help.txt");
                    foreach (string line in data) System.Console.WriteLine(line);
                    System.Console.WriteLine();
                    return "success";
                case "show hero":
                    Utils.Renderer.ClearScreen();
                    this.players[curPlayer].Hero.PrintArt();
                    System.Console.WriteLine("Press enter to go back to game");
                    Console.ReadLine();
                    Utils.Renderer.ClearScreen();
                    return "success print";
                case "show extensions":
                    this.players[curPlayer].ShowHand();
                    return "success";
                case "draw":
                    Cards.Extension extension = this.extensionDeck.deal();
                    System.Console.WriteLine("You drew a card!\n");
                    System.Console.WriteLine(extension + "\n");
                    this.players[curPlayer].addExt(extension);
                    System.Console.WriteLine();
                    System.Console.Write("Press enter to continue: ");
                    System.Console.ReadLine();
                    return "success next";
                case "board":
                    for (int i = 0; i < this.players.Count; i++)
                    {
                        System.Console.WriteLine(this.players[i].Hero.ToString());
                        System.Console.WriteLine("Art:");
                        this.players[i].Hero.PrintArt();
                    }
                    return "success";
                case "show chars":
                    System.Collections.Generic.List<Cards.Hero> list = Utils.Parser.ParseHeroes();
                    foreach (Cards.Hero item in list)
                    {
                        System.Console.WriteLine(item.ToString());
                        item.PrintArt();
                    }
                    return "success";
            }
            if (input.StartsWith("attack"))
            {
                Cards.Hero hero = getHeroFromPlayers(input.Substring(7));
                if (hero == null)
                {
                    System.Console.WriteLine($"The hero {input.Substring(7)} does not exist on the board!");
                    return "try again";
                }
                else
                {
                    if (hero.Name == this.players[curPlayer].Hero.Name)
                    {
                        System.Console.WriteLine($"You can't attack your own hero! Thats mean!");
                        return "try again";
                    }
                    Player.Player result = this.players[curPlayer].Attack(hero);
                    System.Console.Write("Press enter to continue: ");
                    System.Console.ReadLine();
                    if (result == null)
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Hero.Name.Equals(input.Substring(7)))
                            {
                                Player.Player deadPlayer = players[i];
                                players.RemoveAt(i);
                                playersDead.Add(deadPlayer);
                            }
                        }
                    }
                    return "success next";
                }
            }
            return "fail";
        }

        private Cards.Hero getHeroFromPlayers(string name)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Hero.Name.Equals(name))
                {
                    return players[i].Hero;
                }
            }
            return null;
        }
        private Cards.Hero getHeroInDeck(string name)
        {
            for (int i = 0; i < heroDeck.Deck.Count; i++)
            {
                if (heroDeck.Deck[i].Name.Equals(name))
                {
                    return heroDeck.Deck[i];
                }
            }
            return null;
        }
        private void PrintPlayers()
        {
            string s = "Players that will be playing this game:\n";
            foreach (Player.Player player in players)
            {
                s += player.ToString() + "\n";
            }
            System.Console.WriteLine(s);
        }
    }
}