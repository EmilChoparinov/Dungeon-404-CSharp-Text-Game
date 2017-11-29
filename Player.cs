using System.Collections.Generic;
using Cards;
namespace Player{
    class Player{
        private string _name;
        private List<Extension> hand;

        public string Name{
            get{
                return _name;
            }
            set{
                if(value.Length == 0){
                    throw new System.Exception("Name cannot be of length 0");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the player</param>
        public Player(string name){
            Name = name;
        }

        /// <summary>
        /// Add an extension to player deck
        /// </summary>
        /// <param name="card">The extension card</param>
        /// <returns>this context</returns>
        public Player addExt(Extension card){
            hand.Add(card);
            return this;
        }
    }
}