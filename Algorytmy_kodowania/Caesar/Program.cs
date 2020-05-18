using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            int shift;
            do
            {
                shift = Convert.ToInt32(Console.ReadLine());
            } while (shift > 26 ||shift<-26);
            Console.WriteLine(Algorithm(text, shift));
            Console.ReadKey();
        
        }
        public static string Algorithm(string text, int shift)
        {
            char[] textBuffer = text.ToCharArray();
            for(int i = 0; i < textBuffer.Length; i++)
            {
                char token = textBuffer[i];
                if ((token >= 65) && (token <= 90))
                {
                    token = (char)(token+shift);
                    if (token > 90)
                    {
                        token = (char)(token-26);
                    }
                    else if(token < 65){
                        token = (char)(token + 26);
                    }
                }
                else if ((token >= 97) && (token <=122))
                {
                    token = (char)(token + shift);
                    if (token > 122)
                    {
                        token = (char)(token - 26);
                    }
                    else if (token < 97)
                    {
                        token = (char)(token + 26);
                    }
                }
                else if ((token >= 48) && (token <= 57))
                {
                    token = (char)(token + shift);
                    if (token > 57)
                    {
                        
                        token = (char)(token - 10);
                    }
                    else if (token < 48)
                    {
                        token = (char)(token + 10);
                    }
                }
                textBuffer[i] = token;

            }
            return new string(textBuffer);
        }
    }
}
