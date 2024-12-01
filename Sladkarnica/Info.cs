using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Info : Form
    {
        private readonly IAssortmentService assortmentService;
        private readonly IOrdersService orderService;
        private readonly IClientService clientService;

        public Info()
        {
            this.assortmentService = new AssortmentService();
            this.orderService = new OrderService();
            this.clientService = new ClientService();
            this.InitializeComponent();
            this.LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            var res = this.orderService.GetAllOrders();
            this.dataGridView1.DataSource = res;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.clientService.GetCustomersWithRevenueAbove1000(this.textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.orderService.GetOrdersByDate(this.dateTimePicker1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.orderService.GetRevenueByPeriod(this.dateTimePicker2.Value, this.dateTimePicker3.Value);
        }
    }
}
