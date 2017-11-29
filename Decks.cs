using System.Collections.Generic;
using Cards;
using Utils;
namespace Decks
{
    class ExtensionDeck
    {
        private List<Cards.Extension> _deck;
        public List<Cards.Extension> Deck
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
        public ExtensionDeck()
        {
            Deck = Utils.Parser.ParseExtensions();
        }

        public override string ToString()
        {
            string s = "";
            foreach (Cards.Extension card in _deck)
            {
                s += card.ToString();
            }
            return s;
        }

        public ExtensionDeck shuffle()
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < _deck.Count; i++)
            {
                int moveTo = rand.Next(0, _deck.Count);
                Cards.Extension temp = _deck[i];
                _deck[i] = _deck[moveTo];
                _deck[moveTo] = temp;
            }
            return this;
        }

        public ExtensionDeck deal()
        {
            Cards.Extension dealtCard = _deck[0];
            _deck.RemoveAt(0);   
            return this;
        }

        public ExtensionDeck deal(int num)
        {
            return this;
        }
    }
}