using System.Collections.Generic;
using static System.Console;


namespace ONP
{
    class RPNConversion
    {
        public string InfixNotation = null;
        public void ToRPN()
        {
            var tokens = InfixNotation.Split(' ');
            Stack<string> s = new Stack<string>();
            List<string> RPNNotation = new List<string>();
            foreach (var c in tokens)
            {

                if (double.TryParse(c.ToString(), out double gg))
                {
                    RPNNotation.Add(c);

                }
                if (char.TryParse(c.ToString(), out char g))
                {

                    if (IsOperator(g) == true)
                    {
                        while (s.Count != 0 && Priority(s.Peek()) >= Priority(c))
                        {
                            RPNNotation.Add(s.Pop());
                        }
                        s.Push(c);
                    }
                    if (g == '(')
                    {
                        s.Push(c);
                    }
                    if (g == ')')
                    {
                        while (s.Count != 0 && s.Peek() != "(")
                        {
                            RPNNotation.Add(s.Pop());
                        }
                        s.Pop();
                    }

                }
            }
            while (s.Count != 0)
            {
                RPNNotation.Add(s.Pop());
            }
            foreach (var i in RPNNotation)
            {
                Write(i + " ");
            }

        }

        private int Priority(string c)
        {
            if (c == "^")
            {
                return 3;
            }
            else if (c == "*" || c == "/")
            {
                return 2;
            }
            else if (c == "+" || c == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private bool IsOperator(char Operator)
        {
            if (Operator == '+' || Operator == '-' || Operator == '*' || Operator == '/' || Operator == '^')
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
