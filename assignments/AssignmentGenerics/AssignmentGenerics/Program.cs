// Project: Assignment Generics
// File:    Program.cs
// Name:    Justin Behunin
// Date:    2/13/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            FindDuplicateWordsInSentence();
            ModifyList();
        }


        #region FindDuplicateWorsInSentence
        public static void FindDuplicateWordsInSentence()
        {
            Console.WriteLine("Please enter a sentence");
            string sentence = Console.ReadLine();
            Console.WriteLine();

            sentence = RemoveCapsPunctuation(sentence);

            //used dictionary to store the words because it allows for a key/value pair.
            //which allowed the storage of the number of times the word appeared.
            IDictionary<string, int> wordList = new Dictionary<string, int>();
            string[] wordArray = sentence.Split();
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (!wordList.ContainsKey(wordArray[i]))
                {
                    wordList.Add(wordArray[i], 1);
                }
                else
                {
                    wordList[wordArray[i]]++;
                }
            }

            foreach (KeyValuePair<string, int> el in wordList)
                Console.WriteLine("{0} {1}", el.Key, el.Value);

            Console.WriteLine("\nNumber of words that appear more than once: {0}", NumberWordsMoreThanOnce(wordList));

            int shortest = GetShortestWordLength(wordList);
            Console.Write("Shortest word(s): ");
            foreach (KeyValuePair<string, int> el in wordList)
                if (el.Key.Length == shortest)
                    Console.Write("{0} ", el.Key);
            Console.WriteLine();

            int most = GetNumberOfMostOccurances(wordList);
            Console.Write("Word(s) that appear most often: ");
            foreach (KeyValuePair<string, int> el in wordList)
                if (el.Value == most)
                    Console.Write("{0} ", el.Key);
            Console.WriteLine("\n");
        }

        private static int GetNumberOfMostOccurances(IDictionary<string, int> wordList)
        {
            int most = 0;
            foreach (KeyValuePair<string, int> el in wordList)
                if (most < el.Value)
                    most = el.Value;
            return most;
        }

        private static int GetShortestWordLength(IDictionary<string, int> wordList)
        {
            int shortest = 50;//enuser longer then longest word
            foreach (KeyValuePair<string, int> el in wordList)
                if (el.Key.Length < shortest)
                    shortest = el.Key.Length;
            return shortest;
        }

        private static int NumberWordsMoreThanOnce(IDictionary<string, int> wordList)
        {
            int count = 0;
            foreach (KeyValuePair<string, int> el in wordList)
            {
                if (el.Value > 1)
                    count++;
            }
            return count;
        }

        private static string RemoveCapsPunctuation(string s)
        {
            StringBuilder editString = new StringBuilder();
            foreach (char el in s)
            {
                if (char.IsLetter(el) || el == ' ')
                    editString.Append(char.ToLower(el));
            }
            return editString.ToString();
        }
        #endregion


        #region ModifyList
        public static void ModifyList()
        {
            Random randomNumber = new Random(17);
            List<int> numberList = new List<int>();
            for (int i = 0; i < 25; i++)
                numberList.Add(randomNumber.Next(20, 80));
            Console.WriteLine("List of random numbers seeded with 17");
            PrintNumberList(numberList);

            Console.WriteLine("List of random numbers after removing every third number");
            RemoveEveryThirdNumber(numberList);
            PrintNumberList(numberList);

            Console.WriteLine("List of random numbers after adding first five prime numbers on index 3");
            InsertPrimeNumbers(numberList);
            PrintNumberList(numberList);

            Console.WriteLine("List of random numbers reversed");
            numberList.Reverse();
            PrintNumberList(numberList);

            Console.WriteLine("List of random numbers sorted");
            numberList.Sort();
            PrintNumberList(numberList);

            PrintMean(numberList);
            PrintMode(numberList);
            PrintMedian(numberList);
            PrintRange(numberList);

        }

        private static void PrintNumberList(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                Console.Write("{0,3}, ", numberList[i]);
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        private static void RemoveEveryThirdNumber(List<int> numberLIst)
        {
            for (int i = numberLIst.Count - 1; i > 0; i--)
                if ((i + 1) % 3 == 0)
                    numberLIst.RemoveAt(i);

        }

        private static void InsertPrimeNumbers(List<int> numberList)
        {
            numberList.Insert(3, 1);
            numberList.Insert(3, 3);
            numberList.Insert(3, 5);
            numberList.Insert(3, 7);
            numberList.Insert(3, 11);
        }

        private static void PrintMean(List<int> numberList)
        {
            int mode = 0;
            foreach (int el in numberList)
                mode += el;
            mode /= numberList.Count;
            Console.WriteLine("The mode is: {0}", mode);

        }

        private static void PrintMode(List<int> numberList)
        {
            IDictionary<int, int> modeList = new Dictionary<int, int>();
            for (int i = 0; i < numberList.Count; i++)
            {
                if (!modeList.ContainsKey(numberList[i]))
                {
                    modeList.Add(numberList[i], 1);
                }
                else
                {
                    modeList[numberList[i]]++;
                }
            }

            int most = 0;
            foreach (KeyValuePair<int, int> el in modeList)
                if (el.Value > most)
                    most = el.Value;
            Console.Write("The mode is: ");
            foreach (KeyValuePair<int, int> el in modeList)
                if (el.Value == most)
                    Console.WriteLine("{0} ", el.Key);

        }

        private static void PrintMedian(List<int> numberList)
        {
            Console.Write("The median is: ");
            if (numberList.Count % 2 != 0)
                Console.WriteLine("{0}", numberList[(numberList.Count) / 2]);
            else
            {
                int median = (numberList.Count - 1) / 2;
                Console.WriteLine("{0}", (numberList[median] + numberList[median + 1]) / 2);
            }
        }

        private static void PrintRange(List<int> numberList)
        {
            Console.WriteLine("The range is {0}:", numberList[numberList.Count - 1] - numberList[0]);
        }
        #endregion
    }
}
