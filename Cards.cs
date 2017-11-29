using System;
using System.Collections.Generic;

namespace Cards
{
    public class Hero
    {
        private string _name;
        private int _belt_score;
        private int _hacks;
        private string[] _art;
        private int _firewall;
        private string _description;

        /// <summary>
        /// Name of hero
        /// </summary>
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
                    throw new ArgumentException("Name field is empty");
                }
                else
                {
                    _name = value;
                }
            }
        }
        /// <summary>
        /// Belt_Score is equivalent to heroes health
        /// </summary>
        public int Belt_score
        {
            get
            {
                return _belt_score;
            }
            set
            {
                _belt_score = value;
            }
        }
        /// <summary>
        /// Attack points
        /// </summary>
        public int Hacks
        {
            get
            {
                return _hacks;
            }
            set
            {
                _hacks = value;
            }
        }
        /// <summary>
        /// Art for hero card
        /// </summary>
        public string[] Art
        {
            get
            {
                return _art;
            }
            set
            {
                _art = value;
            }
        }
        /// <summary>
        /// Defense points
        /// </summary>
        public int Firewall
        {
            get
            {
                return _firewall;
            }
            set
            {
                _firewall = value;
            }
        }
        /// <summary>
        /// Description of hero cards
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the hero</param>
        /// <param name="belt_score">Health of hero</param>
        /// <param name="hacks">Damage of hero</param>
        /// <param name="firewall">Defense point changer of the hero</param>
        /// <param name="description">Description of hero</param>
        public Hero(string name, int belt_score, int hacks, int firewall, string description)
        {
            this.Name = name;
            this.Belt_score = belt_score;
            this.Hacks = hacks;
            this.Firewall = firewall;
            this.Description = description;
        }

        /// <summary>
        /// Constructor with extra parameter
        /// </summary>
        /// <param name="name">Name of the hero</param>
        /// <param name="belt_score">Health of hero</param>
        /// <param name="hacks">Damage of hero</param>
        /// <param name="firewall">Defense point changer of the hero</param>
        /// <param name="description">Description of hero</param>
        /// <param name="art">Art of each hero</param>
        public Hero(string name, int belt_score, int hacks, int firewall, string description, string[] art)
        {
            this.Name = name;
            this.Belt_score = belt_score;
            this.Hacks = hacks;
            this.Firewall = firewall;
            this.Description = description;
            this.Art = art;
        }
        public class Extension
        {
            private string _name;
            private int _firewall;
            private int _hacking;
            private string[] _art;
            private string _description;
            /// <summary>
            /// Name of Extension Card
            /// </summary>
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
                        throw new ArgumentException("Name string is empty");
                    }
                    _name = value;
                }
            }

            /// <summary>
            /// Firewall point adder 
            /// </summary>
            public int FireWall
            {
                get
                {
                    return _firewall;
                }
                set
                {
                    _firewall = value;
                }
            }

            /// <summary>
            /// Attack point adder
            /// </summary>
            public int Hacking
            {
                get
                {
                    return _hacking;
                }
                set
                {
                    _hacking = value;
                }
            }
            
            /// <summary>
            /// Art of the extension card
            /// </summary>
            public string[] Art
            {
                get
                {
                    return _art;
                }
                set
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentException("Art is empty");
                    }
                    _art = value;
                }
            }
            /// <summary>
            /// Description of extension card
            /// </summary>
            /// <returns></returns>
            public string Description
            {
                get
                {
                    return _description;
                }
                set
                {
                    _description = value;
                }
            }
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="name">Name of the extension</param>
            /// <param name="firewall">Defense point changer of the extension</param>
            /// <param name="hacking">Attack point changer of the extension</param>
            public Extension(string name, int firewall, int hacking)
            {
                this.Name = name;
                this.FireWall = firewall;
                this.Hacking = hacking;
                this.Art = new string[] { "No card :(" };
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="name">Name of the extension</param>
            /// <param name="firewall">Defense point changer of the extension</param>
            /// <param name="hacking">Attack point changer of the extension</param>
            /// <param name="art">Art for the card</param>
            public Extension(string name, int firewall, int hacking, string[] art)
            {
                this.Name = name;
                this.FireWall = firewall;
                this.Hacking = hacking;
                this.Art = art;
            }
        }

    }
}