using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            CustomerUI Check = new CustomerUI();
            Check.Show();
        }


        private void ItemButton_Click(object sender, EventArgs e)
        {
            ItemUI Check = new ItemUI();
            Check.Show();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            OrderUI Check = new OrderUI();
            Check.Show();
        }
    }
}
