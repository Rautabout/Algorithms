using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    class Program
    {
        static int stringSize = 80;
        static int patternSize = 4;
        static void Main(string[] args)
        {
            string stringChain = "", pattern = "";
            int i, j = 0;
            int[] prefixSufixArray = new int[patternSize];
            Random random = new Random();

            for (i = 0; i < stringSize; i++)
            {
                stringChain += char.ConvertFromUtf32(65 + random.Next(0, 3));

            }
            for (i = 0; i < patternSize; i++)
            {
                pattern += char.ConvertFromUtf32(65 + random.Next(0, 3));
            }



            Console.WriteLine(stringChain);
            Console.WriteLine(pattern);
            PrefixSufixArr(pattern, prefixSufixArray);

            i = 0;
            bool isTherePattern = false;
            try
            {
                while (i < stringSize)
                {
                    if (pattern[j] == stringChain[i])
                    {
                        i++;
                        j++;
                    }
                    if (j == patternSize)
                    {
                        Console.WriteLine("pattern at: " + (i - j));
                        isTherePattern = true;
                        j = prefixSufixArray[j - 1];
                    }
                    else if (i < stringSize && pattern[j] != stringChain[i])
                    {
                        if (j != 0)
                        {
                            j = prefixSufixArray[j - 1];
                        }
                        else
                        {
                            i = i + 1;
                        }
                    }
                }
                if (isTherePattern == false)
                {
                    Console.WriteLine("No pattern");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No pattern");
            }
            Console.ReadKey();
        }


        static void PrefixSufixArr(string pattern, int[] prefixSufixArr)
        {
            int length = 0;
            prefixSufixArr[0] = 0;
            int i = 1;
            while (i < patternSize-1)
            {
                if (pattern[i] == pattern[length])
                {
                    ++length;
                    prefixSufixArr[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = prefixSufixArr[length] - 1;
                    }
                    else
                    {
                        prefixSufixArr[i] = 0;
                        i++;
                    }
                }
            }
        }

    }

}
