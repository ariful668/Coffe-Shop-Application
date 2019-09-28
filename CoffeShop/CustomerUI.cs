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

namespace CoffeShop
{
    public partial class CustomerUI : Form
    {
        public CustomerUI()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            update();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        public void add()
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; DataBase=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command

                string commandString = @"INSERT INTO  Customers (Name, Address, Contact) Values ('" + nameTextBox.Text + "', '" + addressTextBox.Text + "','" + contactTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (commandString.Contains(nameTextBox.Text))
                {
                    MessageBox.Show("Customer Name must be unique");
                    return;
                }
                //Open
                sqlConnection.Open();

                //Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }

                //Close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }
        
        public void show()
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; DataBase=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command
                //SELECT * FROM Customers
                string commandString = @"SELECT * FROM Customers";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    showDataGridView.DataSource = null;
                    MessageBox.Show("No Data Found");
                }


                //Close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        public void delete()
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; DataBase=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command

                string commandString = @"delete from Customers where ID=" + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }

                //Close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        public void update()
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; DataBase=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command

                string commandString = @"update Customers set Name ='" + nameTextBox.Text + "',Address='" + addressTextBox.Text + "',Contact='" + contactTextBox.Text + "'Where ID=" + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }

                //Close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        public void search()
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; DataBase=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command
                //SELECT * FROM Customers
                string commandString = @"SELECT * FROM Customers where ID=" + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    showDataGridView.DataSource = null;
                    MessageBox.Show("No Data Found");
                }


                //Close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }
    }
}
