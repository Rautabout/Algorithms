using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
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
			public Dictionary<char, int> CharFreq = new Dictionary<char, int>();

			public Tree(string source)
			{
				for (int i = 0; i < source.Length; i++)
				{
					if (!CharFreq.ContainsKey(source[i]))
					{
						CharFreq.Add(source[i], 0);
					}
					CharFreq[source[i]]++;
				}

				foreach (KeyValuePair<char, int> symbol in CharFreq)
				{
					nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
				}

				while (nodes.Count >= 2)
				{

					List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList();

					if (orderedNodes.Count >= 2)
					{
						List<Node> taken = orderedNodes.Take(2).ToList();
						Node parent = new Node()
						{
							Symbol = '*',
							Frequency = taken[0].Frequency + taken[1].Frequency,
                            NeighbourLeft = taken[0],
                            NeighbourRight = taken[1]
						};

						nodes.Remove(taken[0]);
						nodes.Remove(taken[1]);
						nodes.Add(parent);
					}

					First = nodes.FirstOrDefault();
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
