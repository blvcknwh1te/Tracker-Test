using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tracker_Test.Utility
{
    public class ChartDrawer
    {

        private int[] axisXData = Enumerable.Range(1, 30).ToArray();
        private int[] axisYData = Enumerable.Range(1, 30).ToArray();
        private string seriesName = "MainSeries";
        private string chartAreaName = "DefaultArea";
        private Chart chart = new Chart();


        public ChartDrawer()
        {

        }

        public ChartDrawer(Chart newChart)
        {
            chart = newChart;
            chart.ChartAreas.Add(new ChartArea(chartAreaName));

            chart.Series.Add(new Series(seriesName));
            chart.Series[seriesName].ChartArea = chartAreaName;
            chart.Series[seriesName].ChartType = SeriesChartType.Line;
            chart.Series[seriesName].BorderWidth = 3;
            UpdateData(axisXData, axisYData);

        }


        public void UpdateData(int[] newAxisXData, int[] newAxisYData)
        {
            axisXData = newAxisXData;
            axisYData = newAxisYData;
            chart.Series[seriesName].Points.DataBindXY(axisXData, axisYData);

        }

    }
}
