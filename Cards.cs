using System;
using System.Collections.Generic;

namespace Cards{
    public class Hero{
        private string _name;
        private int _belt_score;
        private int _hacks;
        private string[] _art;
        private int _firewall;

        /// <summary>
        /// Name of hero
        /// </summary>
        public string Name{
            get{
                return _name;
            }
            set{
                if(value.Length == 0){
                    throw new ArgumentException("Name field is empty");
                }
                else{
                    _name = value;
                }
            }
        }
        public int Belt_score{
            get{
                return _belt_score;
            }
            set{
                _belt_score = value;
            }
        }
        public int Hacks{
            get{
                return _hacks;
            }
            set{
                throw new ArgumentException("Name field is empty");
            }
        }
        public string[] Art{
            get{
                return _art;
            }
            set{
                throw new ArgumentException("Name field is empty");
            }
        }
        public int Firewall{
            get{
                return _firewall;
            }
            set{
                throw new ArgumentException("Name field is empty");
            }
        }
    }

}