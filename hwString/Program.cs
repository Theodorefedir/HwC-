using System.Text;

namespace hwString
{
    internal class Program
    {
        static string InsertString(string original, string toInsert, int position)
        {
            return original.Insert(position, toInsert);
        }

        static bool IsPalindrome(string text)
        {
            string newText = text.ToLower();
            for (int i = 0; i < newText.Length / 2; i++)
            {
                if (newText[i] != newText[newText.Length - 1 - i])
                    return false;
            }
            return true;
        }

        static void AnalyzeCase(string text)
        {
            int upperCount = 0;
            int lowerCount = 0;
            int totalLetters = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    totalLetters++;
                    if (char.IsUpper(c))
                        upperCount++;
                    else if (char.IsLower(c))
                        lowerCount++;
                }
            }

            if (totalLetters > 0)
            {
                double upperPercent = (upperCount * 100.0) / totalLetters;
                double lowerPercent = (lowerCount * 100.0) / totalLetters;
                Console.WriteLine($"Uppercase: {upperPercent:F2}%");
                Console.WriteLine($"Lowercase: {lowerPercent:F2}%");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static void ReplaceLastThreeChars(string[] words, int targetLength)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == targetLength && words[i].Length >= 3)
                {
                    words[i] = words[i].Substring(0, words[i].Length - 3) + "$$$";
                }
            }
        }

        static string GetFirstLetter(string text, int wordNumber)
        {
            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (wordNumber > 0 && wordNumber <= words.Length)
            {
                return words[wordNumber - 1][0].ToString();
            }
            return "Word not found";
        }

        static string FormatWithStars(string text)
        {
            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("*", words);
        }

        static void ReadWordsUntilDot()
        {
            StringBuilder sb = new StringBuilder();
            string input;
            bool firstWord = true;

            Console.WriteLine("Enter words (enter a word ending with dot to finish):");

            while (true)
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) {
                    continue;
                }                    
                sb.Append(input);
                if (input.EndsWith("."))
                {
                    break;
                }                    
                else 
                {
                    sb.Append(", ");
                }
            }
            Console.WriteLine("\nResult:");
            Console.WriteLine(sb.ToString());
        }
        static void Main(string[] args)
        {
            string result1 = InsertString("Hello World", "Beautiful ", 6);
            Console.WriteLine(result1);

            Console.WriteLine(IsPalindrome("radar"));
            Console.WriteLine(IsPalindrome("hello"));

            AnalyzeCase("Hello World! 123 ABC def");

            string[] words = { "head", "lelele", "cat", "thry", "orejpgkfdjg" };
            ReplaceLastThreeChars(words, 5);
            Console.WriteLine(string.Join(", ", words));

            Console.WriteLine(GetFirstLetter("This is a simple text", 3));

            Console.WriteLine(FormatWithStars("  dfgfdg cbgf hgf hgf h f  "));

            ReadWordsUntilDot();


        }
    }
}
