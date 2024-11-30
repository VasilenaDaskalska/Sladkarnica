using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Form1 : Form
    {
        private IProductGroupService productGroupService;

        public Form1()
        {
            this.productGroupService = new ProductGroupService();
            this.InitializeComponent();
        }

        //Testing button remove when testing in done
        private void button1_Click(object sender, EventArgs e)
        {
            // helper.AddProductGroup("Test1");
            // helper.AddAssortment("00A", "Test1", 1, "test1", (decimal)0.100, (decimal)1.50);
            //DateTime date = DateTime.Now;
            //helper.AddOrder(date, "00A", false, 3);
            //this.productGroupService.AddProductGroup("Test2");
            //this.productGroupService.UpdateProductGroupByID(1, "Test70");
            // this.productGroupService.UpdateProductGroupByName("Test2", "Test80");
            // this.productGroupService.DeleteProductGroupByID(4);
        }
    }
}
