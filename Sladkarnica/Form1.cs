using System;
using System.Windows.Forms;

namespace Sladkarnica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent1();
            this.InitializeComponent();
        }

        private void InitializeComponent1()
        {
            MenuStrip menuStrip = new MenuStrip();

            // Create menu items
            ToolStripMenuItem productGroupMenuItem = new ToolStripMenuItem("Product Group");
            ToolStripMenuItem assortmentMenuItem = new ToolStripMenuItem("Assortment");
            ToolStripMenuItem clientMenuItem = new ToolStripMenuItem("Client");
            ToolStripMenuItem orderMenuItem = new ToolStripMenuItem("Order");
            ToolStripMenuItem infoMenuItem = new ToolStripMenuItem("Info");
            ToolStripMenuItem chartMenuItem = new ToolStripMenuItem("Chart");

            // Add Click events
            productGroupMenuItem.Click += this.button2_Click;
            assortmentMenuItem.Click += this.button4_Click;
            clientMenuItem.Click += this.button3_Click;
            orderMenuItem.Click += this.button5_Click;
            infoMenuItem.Click += this.button6_Click;
            chartMenuItem.Click += this.button7_Click;

            // Add items to the menu strip
            menuStrip.Items.Add(productGroupMenuItem);
            menuStrip.Items.Add(assortmentMenuItem);
            menuStrip.Items.Add(clientMenuItem);
            menuStrip.Items.Add(orderMenuItem);
            menuStrip.Items.Add(infoMenuItem);
            menuStrip.Items.Add(chartMenuItem);

            // Add the MenuStrip to the Form
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
            this.Text = "Menu Example";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ProductGroup product = new ProductGroup();
            product.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assortment assortment = new Assortment();
            assortment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChartForma chartForm = new ChartForma();
            chartForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
