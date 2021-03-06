using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway430
{
    class Program
    {
        static string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Broadway_43;"
            + "Integrated Security=true";
        static void Main(string[] args)
        {
            var result = "y";
            do
            {
                //Console.WriteLine("Enter the table name:");
                //string tableName = Console.ReadLine();
                Console.WriteLine("Enter the Choice\n1: Display the record\n2: Create the reordd\n3: Update the record\n4: Delete the reccord\n");
                using (SqlConnection connection =
               new SqlConnection(connectionString))
                {
                    connection.Open();
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ReadFromTable(connection);
                            break;
                        case "2":
                            InsertToTable(connection);
                            break;
                        case "3":
                            UpdateToTable(connection);
                            break;
                        case "4":
                            DeleteFromTable(connection);
                            break;
                        default:
                            break;
                    }

                    connection.Close();
                }
                Console.WriteLine("Want to try more (y/n)?");
                result = Console.ReadLine();
            }
            while (result == "y" || result == "Y");

            Console.ReadLine();

        }

        private static void ReadFromTable(SqlConnection connection)
        {

            // Provide the query string with a parameter placeholder.
            string queryString =
                "select * from Student";

            // Create the Command and Parameter objects.//
            SqlCommand command = new SqlCommand(queryString, connection);


            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var readers = new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                    Console.WriteLine(string.Join(",", readers));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        private static void InsertToTable(SqlConnection connection)
        {
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Age");
            var age = Console.ReadLine();

            string queryString =
               $"Insert into Student (Name, Email,Age) values ('{name}','{email}','{age}')";

            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        private static void UpdateToTable(SqlConnection connection)
        {
            Console.WriteLine("Enter the id of the record to update");
            var id = Console.ReadLine();
            Console.WriteLine("Enter name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter email:");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            var Age = Console.ReadLine();


            string queryString = $"update Student set name=('{name}'),email=('{email}'),Age=('{Age}') where id=('{id}') ";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();



        }
        private static void DeleteFromTable(SqlConnection connection)
        {
            Console.WriteLine("Enter the id of the record to be deleted");
            var id = Console.ReadLine();
            string queryString = $"delete from Student where id=('{id}')";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    
    }
}
