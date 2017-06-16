using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            //45/100
            var line = Console.ReadLine();

            List<string> resultList = new List<string>();
            while (line != "END")
            {
                MatchCollection collection = Regex.Matches(line, @"(\w+)[+=].*?[+%20\w/:.*]+");
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

                foreach (Match match in collection)
                {
                    var pair = match.ToString().Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    var field = Regex.Match(pair[0], @"\w+").ToString();
                    var values = pair[1].Split(new[] { "%20" }, StringSplitOptions.RemoveEmptyEntries).Select(w => Regex.Replace(w, "[+]+", " ")).Select(w => w.Trim()).ToList();

                    FillTheDictionary(dict, field, values);
                }
                StringBuilder sb = new StringBuilder();
                foreach (var pair in dict)
                {
                    sb.Append($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }
                resultList.Add(sb.ToString());

                line = Console.ReadLine();
            }
            foreach (var item in resultList)
            {
                Console.WriteLine(item);
            }
        }

        public static void FillTheDictionary(Dictionary<string, List<string>> dictionary, string field, List<string> valuesList)
        {
            if (!dictionary.ContainsKey(field))
            {
                dictionary.Add(field, new List<string>());
            }

            foreach (var value in valuesList)
            {
                dictionary[field].Add(value);
            }
        }


    }
}
