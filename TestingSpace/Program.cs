using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSpace
{
    class Program
    {
        static void Main(string[] args)
        {



            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                double chance, percent, total = 0.0;
                int numberOfCicles = 0;
                int generationCount = 0;
                List<double> results = new ();

                Console.WriteLine("Задай процент");
                percent = double.Parse(Console.ReadLine());
                double coefficient = Math.Round(100.00 / percent, 2);


                /////////////////////////////////////////
                ///ПЕРЕВЕСТИ НА tryParse, try/cath И ПРОЧИЕ ЗАГОГУЛИНЫ
                /////////////////////////////////////////


                Console.WriteLine("Количество генераций значения");
                generationCount = int.Parse(Console.ReadLine());


                Console.WriteLine("Количество циклов герераций значения");
                numberOfCicles = int.Parse(Console.ReadLine());

                for (int x = 0; x < numberOfCicles; x++)
                {
                    int generations = 0;
                    int trues = 0;
                    int falses = 0;

                    for (int y = 0; y < generationCount; y++)
                    {
                        generations++;

                        if (Math.Round(random.NextDouble() * 100.00, 2) % coefficient <= 1.0)
                        {
                            trues++;
                        }
                        else
                        {
                            falses++;
                        }
                    }

                    chance = Convert.ToDouble(trues) / (Convert.ToDouble(generations) * 0.01);
                    results.Add(chance);


                    Console.WriteLine($"Всего чисел - {generations}");
                    Console.WriteLine($"Всего true - {trues}");
                    Console.WriteLine($"Всего false - {falses}");
                    Console.WriteLine($"Вероятность true в {generationCount} генераций значения - {chance}%\n");
                }


                foreach (var item in results)
                {
                    total = total + item;
                }

                total = total / Math.Round(Convert.ToDouble(results.Count), 2);

                Console.WriteLine($"-----------------------------------------");
                Console.WriteLine($"Целевой процент - {percent}%");
                Console.WriteLine($"Средняя вероятность в {numberOfCicles} циклах генераций значения - {total}%\n");

                double lowestRes = results.Min();
                double highestRes = results.Max();
                double Inaccurancy = (highestRes - lowestRes) / 2;

                Console.WriteLine($"Минимальный процент при {generationCount} генераций значения - {lowestRes}%");
                Console.WriteLine($"Максимальный процент при {generationCount} генераций значения - {highestRes}%");
                Console.WriteLine($"Погрешность на {generationCount} генераций значения - +-{Inaccurancy}%\n\n");



            }
        }
    }
}
