using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM
{
    class Program
    {


        static void Main(string[] args)
        {
            Random random = new Random();
            
            string stringChain = "", pattern = "";
            int stringChainLength = 80, patternLength = 4;

            for (int i = 0; i < stringChainLength; i++)
            {
                stringChain += char.ConvertFromUtf32(65 + random.Next(0, 3));

            }
            for (int i = 0; i < patternLength; i++)
            {
                pattern += char.ConvertFromUtf32(65 + random.Next(0, 3));
            }

            Console.WriteLine(stringChain);
            Console.WriteLine(pattern);
     
            Algorithm(stringChain, pattern);
            Console.ReadKey();


        }
        static void PreprocessStrongSuffix(int[] shift, int[] borderPosition, char[] pattern, int patternLength)
        {
            int i = patternLength, j = patternLength + 1;
            borderPosition[i] = j;
            while (i > 0)
            {
                while (j <= patternLength && pattern[i - 1] != pattern[j - 1])
                {
                    if (shift[j] == 0)
                    {
                        shift[j] = j - 1;
                    }
                    j = borderPosition[j];
                }
                i--;
                j--;
                borderPosition[i] = j;
            }
        }
        static void PreprocessOtherSuffix(int[] shift, int[] borderPosition, char[] pattern, int patternLength)
        {
            int  j;
            j = borderPosition[0];
            for(int i = 0; i <= patternLength; i++)
            {
                if (shift[i] == 0)
                {
                    shift[i] = j;
                }
                if (i == j)
                {
                    j = borderPosition[j];
                }
            }
        }

        static void Algorithm(string stringText, string stringPattern)
        {
            int shiftPos = 0, j;
            char[] pattern = stringPattern.ToCharArray();
            char[] text = stringText.ToCharArray();
            int patternLength = pattern.Length;
            int textLength = text.Length;

            int[] borderPosition = new int[patternLength + 1];
            int[] shift = new int[patternLength + 1];

            for (int i = 0; i < patternLength + 1; i++)
            {
                shift[i] = 0;
            }
            PreprocessStrongSuffix(shift, borderPosition, pattern, patternLength);
            PreprocessOtherSuffix(shift, borderPosition, pattern, patternLength);

            while (shiftPos <= textLength - patternLength)
            {
                j = patternLength - 1;
                while (j >= 0 && pattern[j] == text[shiftPos + j])
                {
                    j--;
                }
                if (j < 0)
                {
                    Console.WriteLine("pattern beggins at "+shiftPos);
                    shiftPos += shift[0];
                }
                else
                {
                    shiftPos += shift[j + 1];
                }
            }
        }

    }
}
