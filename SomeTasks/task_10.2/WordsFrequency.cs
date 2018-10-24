using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task_10._2
{
    class WordsFrequency
    {
        public Dictionary<string, int> CountWords(string inputString)
        {
            if (String.IsNullOrWhiteSpace(inputString))
                throw new NullReferenceException("The string is null");
            var dict = new Dictionary<string, int>();
            var stringArray = Regex.Split(inputString, "[,|!|.|:|)|;|\"|?|...|]*\\s");
            foreach (var s in stringArray)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s] += 1;
                }
                else
                {
                    dict.Add(s,1);
                }
            }

            return dict;
        }
    }
}
