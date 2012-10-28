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
        public ActionResult Index()
        {           
            return View();
        }                
    }
    
}
