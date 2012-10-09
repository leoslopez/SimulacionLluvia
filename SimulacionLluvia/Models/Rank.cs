using System.Collections.Generic;

public class Rank
{
    public double LowerLimit { get; set; }
    public double UpperLimit { get; set; }

    public IList<double> Values { get; set; }

    public Rank()
    {
        Values = new List<double>();
    }
}