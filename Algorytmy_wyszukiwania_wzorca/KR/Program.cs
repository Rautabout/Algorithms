using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Program
    {
        readonly static int nOfChars = 256;

        static void Main()
        {
            Random random = new Random();
            string txt = "";
            string pat = "";
            int stringChainLength = 80, patternLength = 4;
            for (int i = 0; i < stringChainLength; i++)
            {
                txt += char.ConvertFromUtf32(65 + random.Next(0, 3));

            }
            for (int i = 0; i < patternLength; i++)
            {
                pat += char.ConvertFromUtf32(65 + random.Next(0, 3));
            }
            Console.WriteLine(pat);
            Console.WriteLine(txt);
            Algorithm(pat, txt);
            Console.ReadKey();
        }
        static void Algorithm(string pattern, string text)
        {
            int primeNumber = 101;
            int patternLength = pattern.Length;
            int textLength = text.Length;

            int patternHash = 0;
            int textHash = 0;
            int h = 1;

            for (int i = 0; i < patternLength - 1; i++)
            {
                h = (h * nOfChars) % primeNumber;
            }

            for (int i = 0; i < patternLength; i++)
            {
                patternHash = (nOfChars * patternHash + pattern[i]) % primeNumber;
                textHash = (nOfChars * textHash + text[i]) % primeNumber;
            }
            int j;
            for (int i = 0; i <= textLength - patternLength; i++)
            {
                if (patternHash == textHash)
                {
                    for (j = 0; j < patternLength; j++)
                    {
                        if (text[i + j] != pattern[j])
                        {
                            break;
                        }
                    }
                    if (j == patternLength)
                    {
                        Console.WriteLine("Pattern at " + i);
                    }
                }

                if (i < textLength - patternLength)
                {
                    textHash = (nOfChars * (textHash - text[i] * h) + text[i + patternLength]) % primeNumber;
                    if (textHash < 0)
                    {
                        textHash = (textHash + primeNumber);
                    }
                }
            }
        }
    }
}
