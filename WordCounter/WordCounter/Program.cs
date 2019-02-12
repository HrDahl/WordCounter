using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = GetWordFrequency("LoremIpsum.txt");

            foreach (var val in result.OrderByDescending(i => i.Value))
            {
                Console.WriteLine(val.Key + " occurs: " + val.Value + " times.");
            }

            Console.ReadKey();
        }

        public static Dictionary<string, int> GetWordFrequency(string file)
        {
            Regex rgx = new Regex("[^a-zA-Z' ]");            

            var words = File.ReadLines(file).SelectMany(x => x.ToLower().Split()).ToList();

            for (int i = 0; i < words.Count(); i++)
            {
                words[i] = rgx.Replace(words[i], "");
            }

            return words.Where(x => x != string.Empty)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
