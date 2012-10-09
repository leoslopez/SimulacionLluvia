using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
public class Distribution
{
    public int RankCount { get; set; }
    public Rank[] Ranks { get; set; }
    public FileContentResult Stream { get; set; }
    
    public double Average 
    {
        get 
        {            
            int elementsCount = 0;
            double summary = 0;
            for (int i = 0; i < RankCount; i++)
            {
                foreach (double value in Ranks[i].Values)
                {
                    summary = summary + value;
                    elementsCount++;
                }
            }

            return summary / elementsCount;
        }
    }

    public int GetRank(double value)
    {
        for(int i = 0; i < RankCount; i++)
        {
            if (value <= Ranks[i].UpperLimit)
                return i;
        }

        return RankCount - 1;
    }

    public bool PutValueInRank(double value)
    {
        for(int i = 0; i < RankCount; i++)
        {
            if (value <= Ranks[i].UpperLimit)
            {
                Ranks[i].Values.Add(value);
                return true;
            }
        }

        return false;
    }
}