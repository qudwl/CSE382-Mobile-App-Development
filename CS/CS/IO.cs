using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

/*
 There are 0 words with 1 letters.
There are 96 words with 2 letters.
There are 972 words with 3 letters.
There are 3903 words with 4 letters.
There are 8636 words with 5 letters.
There are 15232 words with 6 letters.
There are 23109 words with 7 letters.
There are 28419 words with 8 letters.
There are 24792 words with 9 letters.
There are 20194 words with 10 letters.
There are 15407 words with 11 letters.
There are 11273 words with 12 letters.
There are 7781 words with 13 letters.
There are 5100 words with 14 letters.
There are 3178 words with 15 letters.
There are 0 words with 16 letters.
There are 0 words with 17 letters.
There are 0 words with 18 letters.
There are 0 words with 19 letters.
There are 0 words with 20 letters.
The median word is LUMBERS
 */

namespace CS;

public class IO {
    public static void IOMain() {
        int cnt = 0;
        // The using statement ensure the StreamReader
        // is correctly disposed.
        using (StreamReader input = new StreamReader("words.txt")) {
            while (!input.EndOfStream) {
                string line = input.ReadLine();
                cnt++;
            }
        }
        Console.WriteLine(cnt);

        List<string> strings = ReadWordsList("words.txt");
        Console.WriteLine(strings.Count);
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine("There are " + NumWordsWithSpecificLength(strings, i) + " words with " + i + " letters.");
        }
        Console.WriteLine("The median word is " + MedianWord(strings));
    }

    /**
     * This is a method to read all words in a file and 
     */
    public static List<string> ReadWordsList(string filename)
    {
        List<string> result = new List<string>();

        using (StreamReader input = new StreamReader(filename))
        {
            while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                result.Add(line);
            }
        }

        return result;
    }

    public static int NumWordsWithSpecificLength(List<string> words, int length)
    {
        int cnt = 0;

        foreach (string word in words)
        {
            if (word.Length == length) cnt++;
        }

        return cnt;
    }

    public static string MedianWord(List<string> words)
    {
        words.Sort();
        return words.ElementAt(words.Count / 2);
    }
}