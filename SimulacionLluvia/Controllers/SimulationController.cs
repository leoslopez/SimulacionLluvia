using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonteCarloSimulation;
using SimulacionLluvia.Models;
using System.Windows.Forms.DataVisualization.Charting;
using SimulacionLluvias.Models;
using System.IO;

namespace SimulacionLluvia.Controllers
{
    public class SimulationController : Controller
    {
        private readonly int AMOUNT_OF_RAINS = 40;
        private readonly MVCCharts _myCharts = new MVCCharts();
        public static List<double> values;

        //
        // GET: /MeanDesv/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MeanDesvSimulation(double mean, double std_dev, int numberOfEvents)
        {
            // TODO: Replace harcoded values by import values of excel.
            // We need a file with the ranks and cumulative frequency 
            var rankCount = 12;
            //double[] limits = new double[rankCount];
            Rank[] ranks = new Rank[rankCount];

            for (int i = 0; i < rankCount; i++)
            {
                //limits[i] = i * 10;
                ranks[i] = new Rank(i * 10, i * 10 + 10);
            }

            // Obtain Model
            var myModel = new MonteCarloModel(rankCount, ranks, mean, std_dev);

            ViewBag.ValuesInOrder = myModel.ValuesInOrderOfAppearance.Take(numberOfEvents).ToList();
            values = myModel.ValuesInOrderOfAppearance;

            return View(myModel.MyDistribution);
        }

        public ActionResult InputFileSimulation(int numberOfEvents)
        {
            // TODO: Replace harcoded values by import values of excel.
            // We need a file with the ranks and cumulative frequency 
            var rankCount = 12;
            //double[] limits = new double[rankCount];
            Rank[] ranks = new Rank[rankCount];

            for (int i = 0; i < rankCount; i++)
            {
                //limits[i] = i * 10;
                ranks[i] = new Rank(i * 10, i * 10 + 10);
            }

            // cumulative frequency harcoded
            ranks[0].CumFrequency = 0.097;
            ranks[1].CumFrequency = 0.323;
            ranks[2].CumFrequency = 0.581;
            ranks[3].CumFrequency = 0.742;
            ranks[4].CumFrequency = 0.871;
            ranks[5].CumFrequency = 0.935;
            ranks[6].CumFrequency = 0.935;
            ranks[7].CumFrequency = 1;
            ranks[8].CumFrequency = 1;
            ranks[9].CumFrequency = 1;
            ranks[10].CumFrequency = 1;
            ranks[11].CumFrequency = 1;


            // Obtain Model            
            var myModel = new MyMonteCarloModel(rankCount, ranks);

            ViewBag.ValuesInOrder = myModel.ValuesInOrderOfAppearance.Take(numberOfEvents).ToList();
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
    }
}
