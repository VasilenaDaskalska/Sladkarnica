using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class ProductGroup : Form
    {
        private readonly IProductGroupService productGroupService;
        public ProductGroup()
        {
            this.productGroupService = new ProductGroupService();
            this.InitializeComponent();
            this.LoadDataGrid();
            this.dataGridView1.CellClick += this.dataGridView1_CellContentClick;
        }

        private void LoadDataGrid()
        {
            var res = this.productGroupService.GetAllProductGroups();
            this.dataGridView1.DataSource = res;
        }

        private void AddProductGroup_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.productGroupService.AddProductGroup(this.textBox1.Text);
            this.LoadDataGrid();
            this.textBox1.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string oldGroupName = row.Cells[1].Value.ToString();
                if (oldGroupName != null && !string.IsNullOrWhiteSpace(oldGroupName.ToString()))
                {
                    this.textBox1.Text = oldGroupName;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int groupId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            this.productGroupService.UpdateProductGroupByID(groupId, this.textBox1.Text);
            this.LoadDataGrid();
            this.textBox1.Clear();
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
                    int groupId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

                    this.productGroupService.DeleteProductGroupByID(groupId);

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