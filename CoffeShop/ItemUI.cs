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
    public partial class ItemUI : Form
    {
        ItemManager _itemManager = new ItemManager();
        int indexRow;
        public ItemUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            
            //Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price can not be Empty!!");
                return;
            }
            item.Price = Convert.ToDouble(priceTextBox.Text);
            item.Name = nameTextBox.Text;
            //Unique
            if (_itemManager.IsNameExist(item))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exist!!");
                return;
            }

            //Add/Insert
            if (_itemManager.Add(item))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _itemManager.Display();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _itemManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            item.Id = Convert.ToInt32(idTextBox.Text);
             
            //Delete
            if (_itemManager.Delete(item))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _itemManager.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            item.Id = Convert.ToInt32(idTextBox.Text);
            item.Name = nameTextBox.Text;
            item.Price = Convert.ToDouble(priceTextBox.Text); 
            if (_itemManager.Update(item))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _itemManager.Search(nameTextBox.Text);
        }

        private void ShowDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = showDataGridView.Rows[indexRow];
            idTextBox.Text = row.Cells[0].Value.ToString();
            nameTextBox.Text = row.Cells[1].Value.ToString();
            priceTextBox.Text = row.Cells[2].Value.ToString();
        }
    }
}
