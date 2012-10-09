using System.Collections.Generic;
using React.Distribution;

namespace MonteCarloSimulation
{
    /// <summary>
    /// Monte Carlo Simulation
    /// </summary>
    public class MonteCarloModel
    {        
        private readonly int _rankCount;
        private readonly double[] _limits;
        private readonly Rank[] _ranks;

        public Distribution MyDistribution { get; set; }
        public List<double> ValuesInOrderOfAppearance = new List<double>();

        private const double MEAN = 30.24;
        private const double STD_DEV = 17.77;


        public MonteCarloModel(int rankCount, double[] limits)
        {
            _rankCount = rankCount;
            _limits = limits;
            Run();
        }

        public MonteCarloModel(int rankCount, Rank[] ranks, double[] limits)
        {

            _rankCount = rankCount;
            _ranks = ranks;
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
            var distributionType = new Normal(MEAN, STD_DEV);

            int i = 0;            
            while(i < 40)
            {                
                double nextValue = distributionType.NextDouble();
                ValuesInOrderOfAppearance.Add(nextValue);
                // TODO: it should not generate values lower than 0.
                if (nextValue >= 0)
                {
                    i++;                    
                    MyDistribution.PutValueInRank(nextValue);
                }
            }            

            var avg = MyDistribution.Average;            
        }
    }    
}