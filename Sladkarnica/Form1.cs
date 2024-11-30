using System;
using System.Windows.Forms;
using Sladkarnica.Services;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica
{
    public partial class Form1 : Form
    {
        private readonly IProductGroupService productGroupService;
        private readonly IAssortmentService assortmentService;
        private readonly IOrdersService ordersService;

        public Form1()
        {
            this.productGroupService = new ProductGroupService();
            this.assortmentService = new AssortmentService();
            this.ordersService = new OrderService();
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

            //this.ordersService.UpdateOrderByID(1, date, "00A", false, 8);
            //this.ordersService.DeleteOrderByID(3);
        }
    }
}
