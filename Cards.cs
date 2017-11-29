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
        public int Hacks
        {
            get
            {
                return _hacks;
            }
            set
            {
                throw new ArgumentException("Name field is empty");
            }
        }
        public string[] Art
        {
            get
            {
                return _art;
            }
            set
            {
                throw new ArgumentException("Name field is empty");
            }
        }
        public int Firewall
        {
            get
            {
                return _firewall;
            }
            set
            {
                throw new ArgumentException("Name field is empty");
            }
    public class Extension
        {
            private string _name;
            private int _firewall;
            private int _hacking;
            private string[] _art;
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