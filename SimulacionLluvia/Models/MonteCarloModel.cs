using System.Collections.Generic;
using React.Distribution;

namespace MonteCarloSimulation
{
    /// <summary>
    /// Monte Carlo Simulation
    /// </summary>
    public class MonteCarloModel
    {                           
        public Distribution MyDistribution { get; set; }
        public List<double> ValuesInOrderOfAppearance = new List<double>();

        private double _mean = 0.0;
        private double _std_dev = 0.0;

        public MonteCarloModel(int rankCount, Rank[] ranks, double mean, double std_dev)
        {
            _mean = mean;
            _std_dev = std_dev;
            MyDistribution = new Distribution();
            MyDistribution.RankCount = rankCount;
            MyDistribution.Ranks = ranks;
            Run();
        }

        public MonteCarloModel(int rankCount, Rank[] ranks)
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
            var distributionType = new Normal(_mean, _std_dev);

            int i = 0;            
            while(i < 10000)
            {                
                double nextValue = distributionType.NextDouble();                
                // TODO: it should not generate values lower than 0.
                if (nextValue >= 0)
                {
                    i++;
                    ValuesInOrderOfAppearance.Add(nextValue);
                    MyDistribution.PutValueInRank(nextValue);
                }
            }            

            var avg = MyDistribution.Average;            
        }
    }    
}