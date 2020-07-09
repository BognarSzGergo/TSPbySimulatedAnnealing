using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPbySimulatedAnnealing
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test " + (i+1));

                TravellingSalesmanProblem problem = new TravellingSalesmanProblem();
                problem.FilePath = "Cities.txt";
                problem.Anneal();

                string path = "";
                for (int j = 0; j < problem.CitiesOrder.Count - 1; j++)
                {
                    path += problem.CitiesOrder[j] + " -> ";
                }
                path += problem.CitiesOrder[problem.CitiesOrder.Count - 1];

                using (StreamWriter writer = new StreamWriter("log.txt"))
                {
                    for (int j = 0; j < problem.Log.Count; j++)
                    {
                        writer.WriteLine(j + ": " + problem.Log[j]);
                    }
                }

                Console.WriteLine("Shortest Route: " + path);

                Console.WriteLine("The shortest distance is: " + problem.ShortestDistance.ToString());
            }

            Console.ReadLine();
        }
    }
}
