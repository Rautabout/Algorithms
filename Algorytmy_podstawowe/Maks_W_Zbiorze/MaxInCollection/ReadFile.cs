using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxInCollection
{
    class ReadFile
    {
        public void ReadFromFile()
        {

            try
            {
                using (StreamReader reader = new StreamReader(@"F:\Drive\RMS_INF_ROK2\SEM_4\Algorytmy_i_struktury_danych\Algorytmy\Algorytmy_podstawowe\Maks_W_Zbiorze\MaxInCollection\test.txt"))//Deklaracja sciezki do pliku
                {
                    string line = null;
                    while (null != (line = reader.ReadLine()))
                    {
                        string[] values = line.Split(';');
                        double[] numbers = new double[values.Length];
                        double max = double.Parse(values[0]);
                        for (int i = 0; i < values.Length; i++)
                        {
                            numbers[i] = double.Parse(values[i]);
                            if (max < numbers[i])
                            {
                                max = numbers[i];
                            }
                        }
                        Console.WriteLine(max);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read the file" + e);
            }
        }
    }
}
