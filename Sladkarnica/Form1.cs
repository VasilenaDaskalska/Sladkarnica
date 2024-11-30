using System;
using System.Windows.Forms;

namespace Sladkarnica
{
    public partial class Form1 : Form
    {
        private SqlCommandsHelper helper = new SqlCommandsHelper();

        public Form1()
        {
            this.InitializeComponent();
        }

        //Testing button remove when testing in done
        private void button1_Click(object sender, EventArgs e)
        {
            // helper.AddProductGroup("Test1");
            // helper.AddAssortment("00A", "Test1", 1, "test1", (decimal)0.100, (decimal)1.50);
            //DateTime date = DateTime.Now;
            //helper.AddOrder(date, "00A", false, 3);
        }
    }
}
