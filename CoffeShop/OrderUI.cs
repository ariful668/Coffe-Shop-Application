using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoffeShop.BLL;
using CoffeShop.Model;
namespace CoffeShop
{
    public partial class OrderUI : Form
        
    {
        OrderManager _orderManager = new OrderManager();
        int indexRow;

        public OrderUI()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            //Mandatory
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity can not be Empty!!");
                return;
            }
            order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);
            //order.TotalPrice = Convert.ToDouble(totalTextBox.Text);
            //Add/Insert
            if (_orderManager.Add(order))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            order.Id = Convert.ToInt32(idTextBox.Text);
            //Delete
            if (_orderManager.Delete(order))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _orderManager.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Qty as Mandatory
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity Can not be Empty!!!");
                return;
            }
            order.Id = Convert.ToInt32(idTextBox.Text);
            order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);
            order.TotalPrice = Convert.ToDouble(totalTextBox.Text);
            if (_orderManager.Update(order))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _orderManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Search(customerComboBox.Text);
        }

        private void OrderUI_Load(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _orderManager.itemCombo();
            customerComboBox.DataSource = _orderManager.customerCombo();
        }

        private void ShowDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = showDataGridView.Rows[indexRow];
            idTextBox.Text = row.Cells[0].Value.ToString();
            customerComboBox.Text = row.Cells[1].Value.ToString();
            itemComboBox.Text = row.Cells[2].Value.ToString();
            quantityTextBox.Text = row.Cells[3].Value.ToString();
            totalTextBox.Text = row.Cells[5].Value.ToString();
        }
    }
}
