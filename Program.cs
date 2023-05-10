using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {       
        string text = File.ReadAllText(@"D:\c#-projects\FileAnalysis\FileAnalysis\KobzarKateryna.txt");

        text = Regex.Replace(text, @"[\p{P}\p{S}]", " ");
        text = Regex.Replace(text, @"\s+", " ");
        
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (string word in text.Split(' '))
        {
            if (word.Length >= 3 && word.Length <= 20)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }
        }
        
        var sortedWords = wordCount.OrderByDescending(kv => kv.Value);
        
        Console.WriteLine("+----+------------+-----------------+");
        Console.WriteLine("| №  |   слово    | встречается раз |");
        Console.WriteLine("+----+------------+-----------------+");
        int num = 1;
        int step = 3;
        foreach (var kv in sortedWords.Take(50))
        {
            Console.SetCursorPosition(0, step);
            Console.Write($"|{num++}");
            Console.SetCursorPosition(5, step);
            Console.Write($"| {kv.Key}");
            Console.SetCursorPosition(18, step);
            Console.Write($"|\t   {kv.Value}");
            Console.SetCursorPosition(36, step);
            Console.Write("|");
            step++;
        }
        Console.WriteLine();
        Console.WriteLine("+----+------------+-----------------+");
    }
}
