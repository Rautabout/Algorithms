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
        public String ToInfix(String expression)
        {
            var tokens = RPNNotation.Split(' ');
            Stack<string> s = new Stack<string>();
            List<string> infixNotation = new List<string>();

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
                        String p1 = (String)s.Peek();
                        s.Pop();
                        String p2 = (String)s.Peek();
                        s.Pop();
                        s.Push("(" + p2 + g + p1 + ")");

                    }
                }

            }
            return (String)s.Peek();
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
