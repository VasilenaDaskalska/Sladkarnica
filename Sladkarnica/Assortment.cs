using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Assortment : Form
    {
        private readonly IAssortmentService assortmentService;
        public Assortment()
        {
            this.assortmentService = new AssortmentService();
            this.InitializeComponent();
            this.LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            var res = this.assortmentService.GetAllAssortments();
            this.dataGridView1.DataSource = res;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string assortmentName = row.Cells[1].Value.ToString();
                int groupID = (int)row.Cells[2].Value;
                string recipe = row.Cells[3].Value.ToString();
                object weight = row.Cells[4].Value;
                object price = row.Cells[5].Value;
                string assortmentNumber = row.Cells[0].Value.ToString();
                if (assortmentName != null && !string.IsNullOrWhiteSpace(assortmentName.ToString()))
                {
                    this.textBox1.Text = assortmentName;
                }

                if (groupID != 0 && int.TryParse(groupID.ToString(), out int intValue))
                {
                    int myIntValue = intValue;
                    this.textBox5.Text = myIntValue.ToString("0");
                }
                if (recipe != null && !string.IsNullOrWhiteSpace(recipe.ToString()))
                {
                    this.textBox2.Text = recipe;
                }
                if (weight != null && decimal.TryParse(weight.ToString(), out decimal decimalValue))
                {
                    decimal myDecimalValue = decimalValue;
                    this.textBox3.Text = myDecimalValue.ToString("0.00");
                }
                if (price != null && decimal.TryParse(price.ToString(), out decimal decimalValue2))
                {
                    decimal myDecimalValue = decimalValue2;
                    this.textBox4.Text = myDecimalValue.ToString("0.00");
                }
                if (assortmentNumber != null && !string.IsNullOrWhiteSpace(assortmentNumber.ToString()))
                {
                    this.textBox6.Text = assortmentNumber;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.assortmentService.AddAssortment(this.textBox6.Text, this.textBox1.Text, Convert.ToInt32(this.textBox5.Text), this.textBox2.Text, Convert.ToDecimal(this.textBox3.Text), Convert.ToDecimal(this.textBox4.Text));
            this.LoadDataGrid();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int groupId = Convert.ToInt32(this.textBox5.Text);
            decimal weight = Convert.ToDecimal(this.textBox3.Text);
            decimal price = Convert.ToDecimal(this.textBox4.Text);

            this.assortmentService.UpdateAssortmentByID(this.textBox6.Text, this.textBox1.Text, groupId, this.textBox2.Text, weight, price);
            this.LoadDataGrid();

            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
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
                    string assortmentNumber = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    this.assortmentService.DeleteAssortmentByID(assortmentNumber);

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
