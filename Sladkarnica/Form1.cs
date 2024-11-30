using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Form1 : Form
    {
        private readonly IProductGroupService productGroupService;
        private readonly IAssortmentService assortmentService;
        private readonly IOrdersService ordersService;
        private readonly IClientService clientService;

        public Form1()
        {
            this.productGroupService = new ProductGroupService();
            this.assortmentService = new AssortmentService();
            this.ordersService = new OrderService();
            this.clientService = new ClientService();
            this.InitializeChart();
            this.DrawCharts();
            this.InitializeComponent();
        }

        //Testing button remove when testing in done
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            //this.productGroupService.AddProductGroup("Test2");
            //this.productGroupService.UpdateProductGroupByID(1, "Test70");
            // this.productGroupService.UpdateProductGroupByName("Test2", "Test80");
            // this.productGroupService.DeleteProductGroupByID(4);

            // this.assortmentService.AddAssortment("00B", "Test2", 2, "test2", (decimal)0.400, (decimal)3.50);
            // this.assortmentService.UpdateAssortmentByID("00B", "Test2", 2, "test2", (decimal)0.400, (decimal)2.50);
            //var res = this.assortmentService.DeleteAssortmentByID("00B");
            // Console.WriteLine(res);

            //this.ordersService.AddOrder(date, "00A", false, 2);
            //this.ordersService.AddOrder(date.AddDays(1), "00A", false, 1000, 2);
            //this.ordersService.AddOrder(date, "00A", false, 6);
            //this.ordersService.UpdateOrderByID(1, date, "00A", false, 8);
            //this.ordersService.DeleteOrderByID(3);

            //DataTable res = this.ordersService.GetRevenueByPeriod(date, date.AddDays(1));
            //this.dataGridView1.DataSource = res;

            //this.clientService.AddClient("Vasi", "jsdhjks", "32323");
            //this.clientService.AddClient("miro", "jsdhjgggks", "32323");
            //this.clientService.AddClient("ivan", "jsde3234hjks", "323hhhdd23");
            //this.clientService.UpdateClientByID(1, "pesho", "sds", "323223");

            //this.clientService.DeleteClientByID(1);
            //var res = this.clientService.GetCustomersWithRevenueAbove1000("Test1");
            //this.dataGridView1.DataSource = res;

            //var res = this.ordersService.GetAllOrders();
            //this.dataGridView1.DataSource = res;

            var res = this.productGroupService.GetMonthlyProfitData();
            this.dataGridView1.DataSource = res;

        }

        private void DrawCharts()
        {
            DataTable data = this.productGroupService.GetMonthlyProfitData();

            var groups = data.AsEnumerable()
                             .GroupBy(row => row.Field<string>("Sweets_Group"));

            foreach (var group in groups)
            {
                Series series = new Series(group.Key);
                series.ChartType = SeriesChartType.Line;

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
            this.chart1.ChartAreas[0].AxisX.Interval = 1;
            this.chart1.ChartAreas[0].AxisY.Title = "Profit (BGN)";
        }

        private void InitializeChart()
        {
            // Initialize the Chart control
            this.chart1 = new Chart
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(800, 400),
                Name = "chart1"
            };

            // Add a ChartArea to the Chart
            ChartArea chartArea = new ChartArea("Default");
            this.chart1.ChartAreas.Add(chartArea);

            // Add the Chart to the Form's Controls
            this.Controls.Add(this.chart1);
        }
    }
}
