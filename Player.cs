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

        public Cards.Hero Hero{
            get{
                return _hero;
            }
            set{
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
            return this;
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
    }
}