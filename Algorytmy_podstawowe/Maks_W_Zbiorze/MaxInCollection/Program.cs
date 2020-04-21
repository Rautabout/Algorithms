using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxInCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile readFromFile = new ReadFile();
            readFromFile.ReadFromFile();
            Console.ReadKey();
        }
    }
}
