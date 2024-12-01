using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Client : Form
    {
        private readonly IClientService clientService;
        public Client()
        {
            this.clientService = new ClientService();
            this.InitializeComponent();
            this.LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            var res = this.clientService.GetAllClients();
            this.dataGridView1.DataSource = res;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string clientName = row.Cells[1].Value.ToString();
                string address = row.Cells[2].Value.ToString();
                string phoneNumber = row.Cells[3].Value.ToString();
                if (clientName != null && !string.IsNullOrWhiteSpace(clientName.ToString()))
                {
                    this.textBox1.Text = clientName;
                }
                if (address != null && !string.IsNullOrWhiteSpace(address.ToString()))
                {
                    this.textBox2.Text = address;
                }
                if (phoneNumber != null && !string.IsNullOrWhiteSpace(phoneNumber.ToString()))
                {
                    this.textBox3.Text = phoneNumber;
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.clientService.AddClient(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
            this.LoadDataGrid();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            this.clientService.UpdateClientByID(clientId, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);

            this.LoadDataGrid();

            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
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
                    int clientId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

                    this.clientService.DeleteClientByID(clientId);

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
