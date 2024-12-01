using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class ChartForma : Form
    {
        private readonly IProductGroupService productGroupService;
        public ChartForma()
        {
            this.productGroupService = new ProductGroupService();
            this.InitializeChart();
            this.DrawCharts();
            this.InitializeComponent();

        }
        private void DrawCharts()
        {
            DataTable data = this.productGroupService.GetMonthlyProfitData();

            var groups = data.AsEnumerable()
                             .GroupBy(row => row.Field<string>("Sweets_Group"));

            foreach (var group in groups)
            {
                Series series = new Series(group.Key);
                //series.ChartType = SeriesChartType.Line;
                series.ChartType = SeriesChartType.Bar;
                foreach (var row in group)
                {
                    int year = row.Field<int>("Year");
                    int month = row.Field<int>("Month");
                    decimal profit = row.Field<decimal>("Profit");

                    series.Points.AddXY($"{year}-{month:00}", profit);


                }

                this.chart1.Series.Add(series);
            }

            // Настройки на осите
            this.chart1.ChartAreas[0].AxisX.Title = "Month (Year)";
            this.chart1.ChartAreas[0].AxisX.Interval = 0.5;
            this.chart1.ChartAreas[0].AxisY.Title = "Profit (BGN)";
        }

        private void InitializeChart()
        {
            // Initialize the Chart control
            this.chart1 = new Chart
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(800, 500),
                Name = "chart1",
            };

            // Add a ChartArea to the Chart
            ChartArea chartArea = new ChartArea("Default");
            this.chart1.ChartAreas.Add(chartArea);

            // Add the Chart to the Form's Controls
            this.Controls.Add(this.chart1);
        }

        private void chart1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
