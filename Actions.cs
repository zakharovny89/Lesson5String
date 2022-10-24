using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5String
{

    internal class Actions
    {

        internal Queue<string> words = new Queue<string>();                    //очередь слов, формируется в конструкторе
        internal Queue<string> wordsWithMaxNumbers = new Queue<string>();      //очередь слов с максимальным количеством цифр
        internal string longestWord = "";                                      //самое длинное слово
        internal int longestWordCount = 0;                                     //сколько раз самое длинное слово повторяется в тексте
        internal Queue<string> changeWords = new Queue<string>();              //очередь слов с замененными цифрами на числительные
        internal Queue<string> sentences = new Queue<string>();                //очередь предложений, формируется в конструкторе
        internal Queue<string> wordsWithTherSameLetters = new Queue<string>(); //очередь слов, начинающихся и заканчивающихся на одну и ту же букву

        public Actions(string text)
        {
            string[] words1 = text.Split(' ', ',', '.', '?', '!', '\n', '\t', '\r');
            for (int i = 0; i < words1.Length; i++)
            {
                if (words1[i] != "")
                {
                    words.Enqueue(words1[i]);
                }
            }
            Queue<char> sentence = new Queue<char>();
            foreach (char ch in text)
            {
                if (ch != '\n' && ch != '\t' && ch != '\r')
                {                
                    if (ch =='.' || ch == '!' || ch == '?')
                    {
                        sentence.Enqueue(ch);
                        string newString = new string(sentence.ToArray());
                        sentences.Enqueue(newString);
                        sentence.Clear();
                    }
                    else
                    {
                        sentence.Enqueue(ch);
                    }
                }
            }
        }

        internal void ResiveWordsWithMaxNumbers()
        {           
            int max = 0;
            foreach (string word in words)
            {
                int newMax = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsNumber(word[i]))
                    {
                        newMax++;
                    }
                }
                if (newMax > max)
                {
                    max = newMax;
                    wordsWithMaxNumbers.Clear();
                    wordsWithMaxNumbers.Enqueue(word);
                }
                else if (newMax == max)
                {
                    wordsWithMaxNumbers.Enqueue(word);
                }
            }
            foreach (string word in wordsWithMaxNumbers)
            {
                Console.WriteLine(word);
            }
        }        

        internal void LongestWord()
        {
            int NumberOfLetters = 0;
            int letterAtLongestWord = 0;
            foreach (string word in words)
            {
                foreach (char ch in word)
                {
                    NumberOfLetters++;
                }
                if (longestWord == word)
                {
                    longestWordCount++;
                }

                if (NumberOfLetters > letterAtLongestWord)
                {
                    letterAtLongestWord = NumberOfLetters;
                    longestWord = word;
                    longestWordCount = 1;
                }
                NumberOfLetters = 0;
            }
            Console.WriteLine(longestWord);
        }

        internal void ChangeWords()
        {            
            foreach (string word in words)
            {
                bool isNumber = false;
                for (int i = 0; i < word.Length; i++) // проверяем, есть ли цифры в слове
                {
                    if (char.IsNumber(word[i]))
                    {
                        isNumber = true;
                    }
                }
                if (isNumber) // если цифры есть, меняем слово и добавляем в очередь
                {
                    Queue<char> newWord = new Queue<char>();
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (char.IsNumber(word[i]))
                        {
                            switch (word[i])
                            {
                                case '0':
                                    newWord.Enqueue('z'); newWord.Enqueue('e'); newWord.Enqueue('r'); newWord.Enqueue('o');
                                    break;

                                case '1':
                                    newWord.Enqueue('o'); newWord.Enqueue('n'); newWord.Enqueue('e');
                                    break;

                                case '2':
                                    newWord.Enqueue('t'); newWord.Enqueue('w'); newWord.Enqueue('o');
                                    break;

                                case '3':
                                    newWord.Enqueue('t'); newWord.Enqueue('h'); newWord.Enqueue('r'); newWord.Enqueue('e'); newWord.Enqueue('e');
                                    break;

                                case '4':
                                    newWord.Enqueue('f'); newWord.Enqueue('o'); newWord.Enqueue('u'); newWord.Enqueue('r');
                                    break;

                                case '5':
                                    newWord.Enqueue('f'); newWord.Enqueue('i'); newWord.Enqueue('v'); newWord.Enqueue('e');
                                    break;

                                case '6':
                                    newWord.Enqueue('s'); newWord.Enqueue('i'); newWord.Enqueue('x');
                                    break;

                                case '7':
                                    newWord.Enqueue('s'); newWord.Enqueue('e'); newWord.Enqueue('v'); newWord.Enqueue('e'); newWord.Enqueue('n');
                                    break;

                                case '8':
                                    newWord.Enqueue('e'); newWord.Enqueue('i'); newWord.Enqueue('g'); newWord.Enqueue('h'); newWord.Enqueue('t');
                                    break;

                                case '9':
                                    newWord.Enqueue('n'); newWord.Enqueue('i'); newWord.Enqueue('n'); newWord.Enqueue('e');
                                    break;

                                default:
                                    break;

                            }
                        }
                        else
                        {
                            newWord.Enqueue(word[i]);
                        }
                    }
                    string newString = new string(newWord.ToArray());
                    changeWords.Enqueue(newString);
                }
                else // если цифр не было, добавляем слово в очередь без изменений
                {
                    changeWords.Enqueue(word);
                }
            }
            foreach (string word in changeWords)
            {
                Console.WriteLine(word);
            }
        }

        internal void InterrogativeSentences()
        {
            foreach (string sentence in sentences)
            {
                int index = sentence.Length - 1;
                if (sentence[index] == '?')
                {
                    Console.WriteLine(sentence);
                }
            }
        }

        internal void ExclamatorySentences()
        {
            foreach (string sentence in sentences)
            {
                int index = sentence.Length - 1;
                if (sentence[index] == '!')
                {
                    Console.WriteLine(sentence);
                }
            }
        }

        internal void SuggestionsWithoutCommas()
        {
            foreach (string sentence in sentences)
            {
                bool isCommas = false;
                foreach (char c in sentence)
                {
                    if (c == ',')
                    {
                        isCommas = true;
                    }
                }
                if (isCommas == false)
                {
                    Console.WriteLine(sentence);
                }
            }
        }

        internal void WordsWithTherSameLetters()
        {
            foreach(string word in words)
            {
                int index = word.Length - 1;
                if (word[index] == word[0] && !wordsWithTherSameLetters.Contains(word)) //проверяем совпадают ли первая и последняя буквы, а также проверяем, есть ли это слово в очереди
                {
                    wordsWithTherSameLetters.Enqueue(word);
                }
            }
            foreach (string word in wordsWithTherSameLetters)
            {
                Console.WriteLine(word);
            }
        }
    }
}
