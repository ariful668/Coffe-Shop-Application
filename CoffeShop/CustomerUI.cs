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
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            //Mandatory
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact can not be Empty!!");
                return;
            }

            customer.Address = addressTextBox.Text;
            customer.Contact = contactTextBox.Text;

            customer.Name = nameTextBox.Text;
            //Unique
            if (_customerManager.IsNameExist(customer))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exist!!");
                return;
            }

            //Add/Insert
            if (_customerManager.Add(customer))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            customer.Id = Convert.ToInt32(idTextBox.Text);

            //Delete
            if (_customerManager.Delete(customer))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _customerManager.Display();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Address as Mandatory
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact can not be Empty!!");
                return;
            }

            customer.Id = Convert.ToInt32(idTextBox.Text);
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.Contact = contactTextBox.Text;

            if (_customerManager.Update(customer))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Search(nameTextBox.Text);
        } 
    }
}
