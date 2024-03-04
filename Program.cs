using System;
using System.Linq;
using System.Text;

class DistinctCharacters
{
    public string ReplaceSentence(string sentence)
    {
        StringBuilder changedSentence = new StringBuilder();
        int start = -1;

        // Loop through sentence to parse for words to transform
        for (int i = 0; i <= sentence.Length; i++)
        {
            if (i == sentence.Length || !Char.IsLetter(sentence[i]))
            {
                if (start != -1)
                {
                    string word = sentence.Substring(start, i - start);
                    changedSentence.Append(TransformWord(word));
                    start = -1;
                }

                if (i < sentence.Length) changedSentence.Append(sentence[i]);
            }
            else if (start == -1)
            {
                start = i;
            }
        }

        return changedSentence.ToString();
    }

    // Function to alter the word passed with the number of distinct characters between the first and last characters
    private string TransformWord(string word)
    {
        if (word.Length > 2)
        {
            string middle = word.Substring(1, word.Length - 2);
            int distinctChars = middle.Distinct().Count();
            return $"{word[0]}{distinctChars}{word[word.Length - 1]}";
        }

        return word;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DistinctCharacters transformer = new DistinctCharacters();

        if (args.Length == 0)
        {
            // No arguments provided, run test cases
            RunTestCases(transformer);
        }
        else
        {
            // Arguments provided, concatenates them as a single sentence
            string inputSentence = String.Join(" ", args);
            Console.WriteLine($"Original: {inputSentence}");
            Console.WriteLine($"Transformed: {transformer.ReplaceSentence(inputSentence)}");
        }
    }

    static void RunTestCases(DistinctCharacters transformer)
    {
        // Sample test cases if no arguments are passed through the CLI
        string[] testSentences = {
            "Hello, world!",
            "This is a test.",
            "An example with many words.",
            "I",
            "Abcdefghijklmnopqrstuvwxyz",
            "It was many and many a year ago",
            "Copyright,Microsoft:Corporation"
        };

        foreach (string test in testSentences)
        {
            Console.WriteLine($"Original: {test}");
            Console.WriteLine($"Transformed: {transformer.ReplaceSentence(test)}\n");
        }
    }
}
