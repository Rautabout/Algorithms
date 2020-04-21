using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class Program
    {
        static void Main(string[] args)
        {
            
                WriteLine("RPN or classic Infix notation? (RPN/Infix)");
                string whichNotation = ReadLine();
                if (whichNotation.ToUpper() == "RPN")
                {
                    RPNConversion toRPN = new RPNConversion();
                    toRPN.InfixNotation = "11.56 + 23 * 5 / ( 7 - 8 ) ^ 6";
                    toRPN.ToRPN();
                }
                else if (whichNotation.ToUpper() == "INFIX")
                {
                    InfixConversion toInfix = new InfixConversion();
                    toInfix.RPNNotation = "a b c * d e - f ^ / +";
                    WriteLine(toInfix.ToInfix(toInfix.RPNNotation));

                }
                else
                {
                    WriteLine("Wrong input");
                }
                ReadKey();
            
        }
    }
}
