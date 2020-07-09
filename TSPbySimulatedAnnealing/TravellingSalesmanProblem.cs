using System;
using System.Collections.Generic;
using System.IO;

namespace TSPbySimulatedAnnealing
{
    class TravellingSalesmanProblem
    {
        private string filePath;
        private List<int> currentOrder = new List<int>();
        private List<int> nextOrder = new List<int>();
        private double[,] distances;
        private Random random = new Random();
        private double shortestDistance = 0;
        private List<string> log = new List<string>();

        public List<string> Log
        {
            get { return log; }
        }

        public double ShortestDistance
        {
            get
            {
                return shortestDistance;
            }
            set
            {
                shortestDistance = value;
            }
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
            }
        }

        public List<int> CitiesOrder
        {
            get
            {
                return currentOrder;
            }
            set
            {
                currentOrder = value;
            }
        }

        private void LoadCities()
        {
            StreamReader reader = new StreamReader(filePath);

            string cities = reader.ReadToEnd();

            reader.Close();

            string[] rows = cities.Split('\n');

            distances = new double[rows.Length, rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] distance = rows[i].Split(' ');
                for (int j = 0; j < distance.Length; j++)
                {
                    distances[i, j] = double.Parse(distance[j]);
                }

                currentOrder.Add(i);
            }

            if (currentOrder.Count < 1)
                throw new Exception("No cities to order.");
        }
        
        private double GetTotalDistance(List<int> order)
        {
            double distance = 0;

            for (int i = 0; i < order.Count - 1; i++)
            {
                distance += distances[order[i], order[i + 1]];
            }

            if (order.Count > 0)
            {
                distance += distances[order[order.Count - 1], 0];
            }

            return distance;
        }
        
        private List<int> GetNextArrangement(List<int> order)
        {
            List<int> newOrder = new List<int>();

            for (int i = 0; i < order.Count; i++)
                newOrder.Add(order[i]);

            int firstRandomCityIndex = random.Next(1, newOrder.Count);
            int secondRandomCityIndex = random.Next(1, newOrder.Count);

            int dummy = newOrder[firstRandomCityIndex];
            newOrder[firstRandomCityIndex] = newOrder[secondRandomCityIndex];
            newOrder[secondRandomCityIndex] = dummy;

            return newOrder;
        }
        
        public void Anneal()
        {
            int iteration = -1;

            double temperature = 10000.0;
            double deltaDistance = 0;
            double coolingRate = 0.9999;
            double absoluteTemperature = 0.00001;

            LoadCities();

            double distance = GetTotalDistance(currentOrder);

            while (temperature > absoluteTemperature)
            {
                AddToLog(currentOrder);

                nextOrder = GetNextArrangement(currentOrder);

                deltaDistance = GetTotalDistance(nextOrder) - distance;
                
                if ((deltaDistance < 0) || (distance > 0 && Math.Exp(-deltaDistance / temperature) > random.NextDouble()))
                {
                    for (int i = 0; i < nextOrder.Count; i++)
                        currentOrder[i] = nextOrder[i];

                    distance = deltaDistance + distance;
                }
                
                temperature *= coolingRate;

                iteration++;
            }
            shortestDistance = distance;
        }

        private void AddToLog(List<int> order)
        {
            string path = "";
            for (int i = 0; i < order.Count - 2; i++)
            {
                path += order[i] + " -> ";
            }
            path += order[order.Count - 1];
            log.Add(path);
        }
    }
}
