using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStringManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lowecase
            Console.WriteLine(
               Conventer.toLowerCase(
                   Console.ReadLine()));
            //uppercaese
            Console.WriteLine(
                Conventer.toUpperCase(
                    Console.ReadLine()));
            //Inverter
            Console.WriteLine(
                Inventer.Invert(
                    Console.ReadLine()));
            //Palidrome
            Console.WriteLine(
                Palidrome.CheckIfWordIsPalidrome(
                    Console.ReadLine()));

            //Find sequence:
            Finder finder = new Finder();
            Console.WriteLine(
                finder.HighLight("aa aa aa aa", "aa"));

            Console.WriteLine(Sorter.sortWords(Console.ReadLine()));

            Console.WriteLine(checkTheVariablesOfWord("Some long ass word with. The wrong sequence"));

            Console.WriteLine(Extractor.Extract("asada aaass aa bb basbb bsab bb", new string[] { "aa", "bb", "skd" }));

            Console.WriteLine(characterCounter.countCharacters("xasda dsadasd asd sadas dsadas "));
            Console.WriteLine(DateManipulation.DateTime(Console.ReadLine()));
            Console.WriteLine(mergeStrings.merger("aa", "bb"));

            Console.ReadKey();
        }


        public class mergeStrings
        {
            public static string merger(string str1, string str2)
            {
                return str1 += str2;
            }
        }

        public class DateManipulation
        {
            public static string DateTime(string str)
            {
                char[] chars = str.ToCharArray();


                return $"{chars[6]}{chars[7]}{chars[8]}{chars[9]}-{chars[3]}{chars[4]}-{chars[0]}{chars[1]}";
            }
        }

        public class characterCounter
        {
            public static string countCharacters(string text)
            {
                string retStr = String.Empty;
                char[] chars = text.ToCharArray();
                chars = chars.OrderBy(x => x).ToArray();
                int value = 1;
                char? val = null;
                for (int i = 0; i < chars.Length; i++)
                {
                    try
                    {
                        val = chars[i];
                        if (chars[i + 1] == chars[i])
                        {
                            value++;
                        }
                        else
                        {
                            retStr += $"[{val}]:{value}  ";
                            value = 1;
                        }
                    }
                    catch
                    {
                        retStr += $"[{val}]:{value}  ";
                        value = 1;
                    }
                }
                return retStr.Trim();
            }
        }

        public class Extractor
        {
            public static string Extract(string sequence, string[] subsequences)
            {
                int[] values = new int[subsequences.Length];    
                string returnedVal = "";
                List<string> sequencedWords = sequence.Split(' ').ToList();
                int value = 0;
                foreach (string s in subsequences)
                {
                //search subsequences in string
                marker:
                    if (sequencedWords.Contains(s))
                    {
                        values[value]++;
                        sequencedWords.Remove(s);
                        value++;
                        goto marker;
                    }

                    returnedVal += $"[{s}]:{value}  ";
                    value = 0;
                }
                return returnedVal.Trim();
            }
        }

        public static string checkTheVariablesOfWord(string word)
        {
            char[] chars = word.ToCharArray();
            char[] sortedChars = sortTheChars(chars);
            string[] words = word.Split(' ');
            string[] sequences  = word.Split('.');

            return $"ilość znaków:{sortedChars.Length}, ilość słów:{words.Length}, ilość zdań:{sequences.Length}";
        }

        private static char[] sortTheChars(char[] chars)
        {
           List<char> returnedList = new List<char>();
            foreach(char c in chars)
            {
                if(c!=' ' && c != '.')
                {
                    returnedList.Add(c);    
                }
            }
            return returnedList.ToArray();
        }
    }

    internal static class Sorter
    {
        public static string sortWords(string words)
        {
            string[] tabOfWords = words.Split(' ');
            string newString = "";
            foreach(var word in tabOfWords.OrderBy(x => x))
            {
                newString += word + " ";
            }
            newString.Trim();
            return newString;
        }
    }

    internal class Finder
    {
        public string HighLight(String text, string substring)
        {
            char[] wordsInText = text.ToCharArray();
            char[] wordsInSubstring = substring.ToCharArray();
            List<int> substrings = new List<int>();
            //Jeżeli wczytano HighLight za pierwszym razem:
            for (int i = 0; i < wordsInText.Length; i++)
            {
                if (search(i, wordsInText, wordsInSubstring))
                {
                    substrings.Add(i);
                }
            }
            if (substrings.Count > 0)
            {
                return substrings.Count.ToString();
            }
            else
                return "Empty";
        }

        private bool search(int i, char[] wordsInText, char[] wordsInSubstring)
        {
            int iteration = 0;
            foreach (var word in wordsInSubstring)
            {
                try
                {
                    if (wordsInText[i + iteration] != word)
                    {
                        return false;
                    }
                    iteration++;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }


    internal class Palidrome
    {
        public static bool CheckIfWordIsPalidrome(string word)
        {
            int znacznik = 1;
            char[] chars = word.ToCharArray();
            if (word.Length > 0)
            {
                foreach (char c in chars)
                {
                    if (chars[chars.Length-znacznik]!= c)
                    {
                        return false;
                    }
                    znacznik++;
                }
                return true;
            }
            return false;
        }
    }

    internal class Inventer
    {
        public static string Invert(string napis)
        {
            string returnedString = String.Empty;
            char[] characters = napis.ToCharArray();
            for(int i = characters.Length - 1; i >= 0; i--)
            {
                returnedString += characters[i];
            }

            return returnedString;
        }
    }
    internal class Conventer
    {
        public static string toLowerCase(string str)
        {
            return str.ToLower();
         //   return null;
        }
        public static string toUpperCase(string str)
        {
            return str.ToUpper();
           // return null;
        }
    }
}
