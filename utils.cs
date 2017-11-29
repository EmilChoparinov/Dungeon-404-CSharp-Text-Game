using System;
using System.Collections.Generic;
using Cards;
namespace Utils
{
    class Parser
    {
        public static void parseHeros()
        {
        }
        public static List<Cards.Extension> ParseExtensions()
        {
            List<Cards.Extension> extensions = new List<Extension>();
            string[] data = System.IO.File.ReadAllLines("Extensions.txt");
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Equals("-"))
                {
                    i++;
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    while (!data[i].Equals("-"))
                    {
                        string ability = data[i].Substring(0, data[i].IndexOf(':'));
                        string value = data[i].Substring(data[i].IndexOf(':') + 1);
                        dict.Add(ability, value);
                        i++;
                        if (i > data.Length - 1) break;
                    }
                    Cards.Extension extension = new Cards.Extension(dict["name"], int.Parse(dict["firewall"]), int.Parse(dict["hacking"]));
                    extensions.Add(extension);
                    i--;
                }
            }
            return extensions;
        }
    }
}