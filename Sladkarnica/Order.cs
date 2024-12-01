using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Order : Form
    {
        private readonly IOrdersService ordersService;
        public Order()
        {
            this.ordersService = new OrderService();
            this.InitializeComponent();
            this.LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            var res = this.ordersService.GetAllOrders();
            this.dataGridView1.DataSource = res;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                DateTime? date = (DateTime)row.Cells[1].Value;
                string assortmentNumber = row.Cells[2].Value.ToString();
                bool isReady = (bool)row.Cells[3].Value;
                int quantity = (int)row.Cells[4].Value;
                //int clientID = (int)row.Cells[5].Value;
                if (date.HasValue)
                {
                    this.dateTimePicker1.Text = date.ToString();
                }
                if (assortmentNumber != null && !string.IsNullOrWhiteSpace(assortmentNumber.ToString()))
                {
                    this.textBox1.Text = assortmentNumber;
                }
                this.checkBox1.Checked = isReady;
                if (quantity != 0 && int.TryParse(quantity.ToString(), out int intValue))
                {
                    int myIntValue = intValue;
                    this.textBox2.Text = myIntValue.ToString("0");
                }

                this.textBox3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = this.dateTimePicker1.Value;
            this.ordersService.AddOrder(dateTime, this.textBox1.Text, this.checkBox1.Checked, Convert.ToInt32(this.textBox2.Text), Convert.ToInt32(this.textBox3.Text));
            this.LoadDataGrid();
            this.dateTimePicker1.Value = DateTime.Today;
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.checkBox1.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            int quantity = Convert.ToInt32(this.textBox2.Text);
            this.ordersService.UpdateOrderByID(orderID, this.dateTimePicker1.Value, this.textBox1.Text, this.checkBox1.Checked, quantity);
            this.LoadDataGrid();

            this.dateTimePicker1.Value = DateTime.Today;
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.checkBox1.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?",
                                                        "Confirm Delete",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int orderID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

                    this.ordersService.DeleteOrderByID(orderID);

                    this.LoadDataGrid();
                    MessageBox.Show("Record deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
