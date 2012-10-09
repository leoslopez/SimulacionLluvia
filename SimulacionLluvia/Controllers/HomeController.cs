using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonteCarloSimulation;

namespace SimulacionLluvia.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var rankCount = 12;
            double[] limits = new double[rankCount];
            Rank[] ranks = new Rank[rankCount];

            for (int i = 0; i < rankCount; i++)
            {
                limits[i] = i * 10;
                ranks[i] = new Rank() { LowerLimit = i * 10, UpperLimit = i * 10 + 10 };
            }

            var myModel = new MonteCarloModel(rankCount, ranks, limits);

            ViewBag.ValuesInOrder = myModel.ValuesInOrderOfAppearance;
                        
            return View(myModel.MyDistribution);            
        }

        public string GetDouble(double value)
        {
            return string.Format("{#:##}", value);
        }
    }
}
