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
        public static List<Cards.Extension> parseExtensions()
        {
            List<Cards.Extension> extensions = new List<Extension>();
            string[] data = System.IO.File.ReadAllLines("Extensions.txt");
            for(int i = 0; i < data.Length; i++){
                if(data[i].Equals("-")){
                    i++;
                    Dictionary<string,string> dict = new Dictionary<string, string>();
                    System.Console.WriteLine("----------");
                    while(!data[i].Equals("-")){
                        string ability = data[i].Substring(0,data[i].IndexOf(':'));
                        string value = data[i].Substring(data[i].IndexOf(':')+1);
                        i++;
                        if(i > data.Length-1)break;
                    }
                    System.Console.WriteLine("----------");
                    i--;
                }
            }
            return extensions;
        }
    }
}