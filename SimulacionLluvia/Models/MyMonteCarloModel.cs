using System.Collections.Generic;
using React.Distribution;
using System;

namespace MonteCarloSimulation
{
    /// <summary>
    /// Monte Carlo Simulation
    /// </summary>
    public class MyMonteCarloModel
    {                        
        public Distribution MyDistribution { get; set; }
        public List<double> ValuesInOrderOfAppearance = new List<double>();        

        public MyMonteCarloModel(int rankCount, Rank[] ranks)
        {
            MyDistribution = new Distribution();
            MyDistribution.RankCount = rankCount;
            MyDistribution.Ranks = ranks;
            Run();
        }        

        /// <summary>
        /// Runs the Monte Carlo Simulation
        /// </summary>
        private void Run()
        {            
            int i = 0;
            Random random = new Random();
            double calculatedValue;
            while (i < 10000)
            {                
                double nextValue = random.NextDouble();
                
                i++;
                
                calculatedValue = MyDistribution.PutValueInRankUsingFrequency(nextValue);
                ValuesInOrderOfAppearance.Add(calculatedValue);
            }

            var avg = MyDistribution.Average;
        }
    }    
}