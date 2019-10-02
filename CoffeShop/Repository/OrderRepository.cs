using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CoffeShop.Model;

namespace CoffeShop.Repository
{
    public class OrderRepository
    {
        public bool Add(Order order)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"INSERT INTO Orders (CustomerId, ItemId, Quantity) Values (" + order.CustomerId + ", " + order.ItemId + ", " + order.Quantity + " )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {

            }

            return isAdded;
        
}

        public bool Update(Order order)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"UPDATE Orders SET CustomerId =  " + order.CustomerId + " , ItemId = " + order.ItemId + ", Quantity = " + order.Quantity + ", TotalPrice = " + order.TotalPrice + " WHERE Id = " + order.Id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
            }
            return false;
        }

        public DataTable Display()
        {
           
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"SELECT o.Id, c.Name AS 'Customer',i.Name AS 'Item', Quantity,Price, TotalPrice FROM Orders AS o
                LEFT JOIN Customers AS c ON c.Id = o.CustomerId
                LEFT JOIN Items AS i ON i.Id = o.ItemId  ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                //Close
                sqlConnection.Close();

               return dataTable;
            
        }

        public bool Delete(Order order)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"DELETE FROM Orders WHERE ID = " + order.Id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
            }

            return false;
        }

        public DataTable Search(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"SELECT * FROM Orders WHERE Name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
               
            }

            return dataTable;
        }
        public DataTable itemCombo()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            string commandString = @"SELECT Id, Name FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;

        }
        public DataTable customerCombo()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-8RCCAHG; Database=CoffeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            string commandString = @"SELECT Id, Name FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;

        }
    }
}
