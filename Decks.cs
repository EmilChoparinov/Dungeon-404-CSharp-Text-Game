using System.Collections.Generic;
using Cards;
using Utils;
namespace Decks{
    class ExtensionDeck{
        private List<Cards.Extension> _deck;
        public List<Cards.Extension> Deck{
            get{
                return _deck;
            }
            set{
                if(value == null){
                    throw new System.Exception("Deck given is null");
                }
                _deck = value;
            }
        }
        public ExtensionDeck(){
            Deck = Utils.Parser.ParseExtensions();
        }
    }
}