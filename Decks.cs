using System.Collections.Generic;
using Cards;
using Utils;
namespace Decks
{
    class HeroDeck
    {
        private List<Hero> _deck;
        public List<Hero> Deck
        {
            get
            {
                return _deck;
            }
            set
            {
                if (value == null)
                {
                    throw new System.Exception("Deck given is null");
                }
                _deck = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HeroDeck()
        {
            Deck = Utils.Parser.ParseHeroes();
        }

        /// <summary>
        /// String representation of class Extension Deck
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";
            foreach (Hero card in _deck)
            {
                s += card.ToString();
            }
            return s;
        }

        /// <summary>
        /// Randomly shuffle the deck
        /// </summary>
        /// <returns>this context</returns>
        public HeroDeck shuffle()
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < _deck.Count; i++)
            {
                int moveTo = rand.Next(0, _deck.Count);
                Hero temp = _deck[i];
                _deck[i] = _deck[moveTo];
                _deck[moveTo] = temp;
            }
            return this;
        }

        /// <summary>
        /// Deals/Removes a card from the deck
        /// </summary>
        /// <returns>Card delt</returns>
        public Hero GiveHero(int num)
        {
            Hero dealtCard = _deck[num];
            _deck.RemoveAt(num);
            return dealtCard;
        }
    }
    class ExtensionDeck
    {
        private List<Extension> _deck;
        public List<Extension> Deck
        {
            get
            {
                return _deck;
            }
            set
            {
                if (value == null)
                {
                    throw new System.Exception("Deck given is null");
                }
                _deck = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ExtensionDeck()
        {
            Deck = Utils.Parser.ParseExtensions();
        }

        /// <summary>
        /// String representation of class Extension Deck
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";
            foreach (Extension card in _deck)
            {
                s += card.ToString();
            }
            return s;
        }

        /// <summary>
        /// Randomly shuffle the deck
        /// </summary>
        /// <returns>this context</returns>
        public ExtensionDeck shuffle()
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < _deck.Count; i++)
            {
                int moveTo = rand.Next(0, _deck.Count);
                Extension temp = _deck[i];
                _deck[i] = _deck[moveTo];
                _deck[moveTo] = temp;
            }
            return this;
        }

        /// <summary>
        /// Deals/Removes a card from the deck
        /// </summary>
        /// <returns>Card delt</returns>
        public Extension deal()
        {
            Extension dealtCard = _deck[0];
            _deck.RemoveAt(0);
            return dealtCard;
        }

        /// <summary>
        /// Deals/Removes num cards from the deck
        /// </summary>
        /// <param name="num">Number of cards to take</param>
        /// <returns>List of cards delt</returns>
        public List<Extension> deal(int num)
        {
            List<Extension> cards = new List<Extension>();
            for (int i = 0; i < num; i++)
            {
                Extension dealtCard = _deck[0];
                cards.Add(dealtCard);
                _deck.RemoveAt(0);
            }
            return cards;
        }
    }
}