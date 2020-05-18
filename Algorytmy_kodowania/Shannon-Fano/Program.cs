using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shannon_Fano
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            BitArray encode = new Tree(text).Encode(text);
            Console.WriteLine("Result: ");
            for (int i = 0; i < encode.Count; i++)
            {
                Console.Write(Convert.ToInt32((encode[i])));
            }
            Console.ReadKey();
        }
        public class Node
        {
            public char Symbol { get; set; }
            public int Frequency { get; set; }
            public Node NeighbourRight { get; set; }
            public Node NeighbourLeft { get; set; }

            public List<bool> Traverse(char symbol, List<bool> data)
            {

                if (NeighbourRight == null && NeighbourLeft == null)
                {
                    if (symbol.Equals(Symbol))
                    {
                        return data;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    List<bool> left = null;
                    List<bool> right = null;

                    if (NeighbourLeft != null)
                    {
                        List<bool> leftpath = new List<bool>();
                        leftpath.AddRange(data);
                        leftpath.Add(false);

                        left = NeighbourLeft.Traverse(symbol, leftpath);
                    }

                    if (NeighbourRight != null)
                    {
                        List<bool> rightPath = new List<bool>();
                        rightPath.AddRange(data);
                        rightPath.Add(true);
                        right = NeighbourRight.Traverse(symbol, rightPath);
                    }

                    if (left != null)
                    {
                        return left;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
        }
        public class Tree
        {
            private List<Node> nodes = new List<Node>();
            public Node First { get; set; }
            public Dictionary<char, int> CharFrequency = new Dictionary<char, int>();

            public Tree(string source)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    if (!CharFrequency.ContainsKey(source[i]))
                    {
                        CharFrequency.Add(source[i], 0);
                    }
                    CharFrequency[source[i]]++;
                }
                int valueofALL = 0;
                foreach (KeyValuePair<char, int> symbol in CharFrequency)
                {

                    nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
                    valueofALL += symbol.Value;
                }

                List<Node> orderedNodes = nodes.OrderByDescending(node => node.Frequency).ToList();
                First = new Node()
                {
                    Symbol = '*',
                    Frequency = valueofALL,
                    NeighbourLeft = orderedNodes[0],
                };
                orderedNodes.RemoveAt(0);
                SFCons(orderedNodes, valueofALL - First.NeighbourLeft.Frequency, First);
            }

            private void SFCons(List<Node> orderedNodes, int value, Node node)
            {
                if (orderedNodes.Count() > 0)
                {
                    node.NeighbourRight = new Node()
                    {
                        Symbol = '*',
                        Frequency = value,
                        NeighbourLeft = orderedNodes[0],
                    };
                    orderedNodes.RemoveAt(0);
                    SFCons(orderedNodes, value - node.NeighbourLeft.Frequency, node.NeighbourRight);
                }
            }

            public BitArray Encode(string source)
            {
                List<bool> encodedSource = new List<bool>();

                for (int i = 0; i < source.Length; i++)
                {
                    List<bool> encodedSymbol = First.Traverse(source[i], new List<bool>());

                    encodedSource.AddRange(encodedSymbol);

                }

                BitArray bits = new BitArray(encodedSource.ToArray());
                return bits;
            }
        }
    }
}
