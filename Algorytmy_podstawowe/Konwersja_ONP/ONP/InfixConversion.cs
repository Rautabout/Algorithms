using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class InfixConversion
    {
        public string RPNNotation = null;
        public string ToInfix(string expression)
        {
            var tokens = RPNNotation.Split(' ');
            Stack<string> s = new Stack<string>();

            foreach (var c in tokens)
            {
                if (char.TryParse(c.ToString(), out char g))
                {
                    if (IsOperand(g))
                    {
                        s.Push(g + "");
                    }
                    else
                    {
                        string p1 = (string)s.Peek();
                        s.Pop();
                        string p2 = (string)s.Peek();
                        s.Pop();
                        s.Push("(" + p2 + g + p1 + ")");

                    }
                }

            }
            return (string)s.Peek();
        }
        private bool IsOperand(char Operator)
        {
            if (Operator >= 'a' && Operator <= 'z' || Operator >= 'A' && Operator <= 'Z')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
