using System.Collections.Generic;
using Cards;
namespace Player
{
    class Player
    {
        private string _name;
        private List<Extension> hand;

        private Cards.Hero _hero;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new System.Exception("Name cannot be of length 0");
                }
                _name = value;
            }
        }

        public Cards.Hero Hero
        {
            get
            {
                return _hero;
            }
            set
            {
                _hero = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the player</param>
        public Player(string name)
        {
            hand = new List<Extension>();
            Name = name;
            _hero = null;
        }

        /// <summary>
        /// Add an extension to player deck
        /// </summary>
        /// <param name="card">The extension card</param>
        /// <returns>this context</returns>
        public Player addExt(Extension card)
        {
            hand.Add(card);
            _hero.Hacks += card.Hacking;
            _hero.Firewall += card.FireWall;
            return this;
        }

        public void ShowHand()
        {
            string s = "";
            foreach (Extension ext in hand)
            {
                s += ext.ToString() + "\n";
            }
            System.Console.WriteLine(s);
        }

        public override string ToString()
        {
            string s = "";
            if (_hero == null)
            {
                s += $"Player: {_name}";
            }
            else
            {
                s += $"Player: {_name}\nHero: ";
                s += _hero.ToString();
            }
            return s;
        }

        public Player Attack(Player player)
        {
            player._hero.Belt_score -= this._hero.Hacks / 2;
            System.Console.WriteLine($"{this._hero.Name} just hit {player._hero.Name} with {this._hero.Hacks / 2} hacks! His belt score went down to {this._hero.Belt_score}!");
            return this;
        }

        public Player Attack(Hero hero)
        {
            if (hero.Belt_score - this._hero.Hacks / 2 < 0)
            {
                System.Console.WriteLine($"{this._hero.Name} just gave {hero.Name} a really hard belt exam! His score was 0! Maybe {hero.Name} would have better luck at code fellows?");
                return null;
            }
            else
            {
                decimal def = (decimal) hero.Firewall/2;
                hero.Belt_score -= this._hero.Hacks / (int) System.Math.Round(def);
            }
            System.Console.WriteLine($"{this._hero.Name} just hit {hero.Name} with {this._hero.Hacks / 2} hacks! His belt score went down to {hero.Belt_score}!");
            return this;
        }
    }
}