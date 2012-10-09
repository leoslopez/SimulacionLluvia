using System.Collections.Generic;
using System.Drawing;
using Dundas.Charting.Utilities;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulacionLluvias.Models
{
    public class MonteCarloChart
    {
        public void GetMonteCarloChart(Chart chart1, List<double> values)
        {
            // Add series and set chart type
            chart1.Series.Add("RawData");
            chart1.Series.Add("Histogram");
            chart1.Series.Add("DataDistribution");

            chart1.ChartAreas.Add("HistogramArea");

            chart1.Series["RawData"].XValueType = ChartValueType.Double;            
            chart1.Series["RawData"].ChartType = SeriesChartType.Point;
            chart1.Series["RawData"].Enabled = true;            

            chart1.Series["DataDistribution"].XValueType = ChartValueType.Double;            
            chart1.Series["DataDistribution"].ChartType = SeriesChartType.Point;            

            chart1.Series["Histogram"].YValueType = ChartValueType.Double;            
            chart1.Series["Histogram"].ChartType = SeriesChartType.Column;
            chart1.Series["Histogram"].BorderWidth = 1;
            chart1.Series["Histogram"].ChartArea = "HistogramArea";
            chart1.Series["Histogram"].Color = Color.YellowGreen;
            chart1.Series["Histogram"].BorderColor = Color.Black;
            chart1.Series["Histogram"].BackGradientStyle = GradientStyle.DiagonalLeft;
            chart1.ChartAreas["HistogramArea"].AxisX.LabelStyle.Format = "#,###";

            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Y = 0;
            chart1.ChartAreas[0].Position.Width = 0;
            chart1.ChartAreas[0].Position.Height = 0;
            chart1.ChartAreas[0].Visible = true;            

            List<double> myValues = values;

            foreach (double value in myValues)
            {
                chart1.Series["RawData"].Points.AddY(value);
            }


            foreach (DataPoint dataPoint in chart1.Series["RawData"].Points)
            {
                chart1.Series["DataDistribution"].Points.AddXY(dataPoint.YValues[0], 1);
            }

            // Create a histogram series
            var histogramHelper = new HistogramChartHelper
                                      {
                                          ShowPercentOnSecondaryYAxis = true,
                                          SegmentIntervalNumber = 12
                                      };
            histogramHelper.CreateHistogram(chart1, "RawData", "Histogram");

            // Set same X axis scale and interval in the single axis data distribution 
            // chart area as in the histogram chart area.
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.ChartAreas["HistogramArea"].AxisX2.MinorTickMark.Enabled = true;
            chart1.ChartAreas[0].Visible = true;
            chart1.ChartAreas["HistogramArea"].AxisX.LabelStyle.Enabled = true;           
            chart1.Series["Histogram"].SmartLabelStyle.Enabled = true;
            chart1.Legends[0].Enabled = true;
        }
    }
}