using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;

namespace SimulacionLluvia.Models
{
    public class MVCCharts
    {
        #region Charts

        /// <summary>
        /// Creates the standard chart.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public Chart CreateStandardChart(int width, int height, string title)
        {
            // Inital Setup
            var chart1 = new Chart
                             {
                                 Width = width,
                                 Height = height,
                                 Palette = ChartColorPalette.Chocolate,                                 
                                 BackColor = Color.SeaGreen,
                                 BackGradientStyle = GradientStyle.DiagonalLeft                                 
                             };                 

            // Add title
            var t = new Title(title, Docking.Top, new Font("Trebuchet MS", 10, FontStyle.Bold), Color.Black);
            chart1.Titles.Add(t);

            // Add Chart Area
            chart1.ChartAreas.Add("Area1");

            chart1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle1;
            chart1.BorderColor = Color.Black;
            chart1.BorderWidth = 2;

            // Add Legends
            Legend legend1 = new Legend("Legend1");
            legend1.Alignment = StringAlignment.Near;
            legend1.Docking = Docking.Bottom;
            chart1.Legends.Add(legend1);
            
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;            

            return chart1;
        }

        #endregion
    }
}