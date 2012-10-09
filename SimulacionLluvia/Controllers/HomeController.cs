using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonteCarloSimulation;
using System.Windows.Forms.DataVisualization.Charting;
using SimulacionLluvias.Models;
using SimulacionLluvia.Models;
using System.IO;
using System.Reflection;

namespace SimulacionLluvia.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCCharts _myCharts = new MVCCharts();
        public static List<double> values;

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

            // Obtain Model
            var myModel = new MonteCarloModel(rankCount, ranks, limits);            

            ViewBag.ValuesInOrder = myModel.ValuesInOrderOfAppearance;
            values = myModel.ValuesInOrderOfAppearance;
                        
            return View(myModel.MyDistribution);            
        }
        
        // TODO: change static property "values" and id parameter by parameter received here
        public FileResult GetChart(string id)
        {
            // Create Chart
            Chart chart1 = _myCharts.CreateStandardChart(577, 360, "Monte Carlo Simulation");

            // Get Chart
            var myChart = new MonteCarloChart();
            myChart.GetMonteCarloChart(chart1, values);

            // Return File
            var myRand = new Random();
            var imageStream = new MemoryStream();            
            chart1.SaveImage(imageStream, ChartImageFormat.Png);
            FileContentResult file = File(imageStream.ToArray(), "image/png", myRand.Next() + ".png");            
            return file;
        }

        public string GetDouble(double value)
        {
            return string.Format("{#:##}", value);
        }
    }
    
}
