using Microsoft.Data.SqlClient;
using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Data
{
    public class ServicesData
    {
        public static ServicesModel FindServiceByID(int ID)
        {
            ServicesModel Service = new ServicesModel();


            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = $"select * from Services where Service_ID = @ID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Service.Service_ID = ID;
                    Service.Service_Name = (string)reader["Service_Name"];
                    Service.Service_Cost = (decimal)reader["Service_Cost"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return Service;
        }
        /*public static int AddNewService(ServicesModel Service)
        {

            int Id = -1;


            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Services(Service_Name,Service_Cost)
                            VALUES(@Name , @Cost); select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@Name", Service.Service_Name);
            command.Parameters.AddWithValue("@Cost", Service.Service_Cost);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                Console.WriteLine(result);
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Id = insertedID;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return Id;
        }
        */

        
        public static bool UpdateService(ServicesModel Service)
        {

            int restut = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "UPDATE Services SET Service_Name = @Service_Name ,Service_Cost = @Service_Cost WHERE Service_ID = @Service_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Service_ID", Service.Service_ID);
            command.Parameters.AddWithValue("@Service_Name", Service.Service_Name);
            command.Parameters.AddWithValue("@Service_Cost", Service.Service_Cost);
            

            try
            {
                connection.Open();

                restut = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return (restut > 0);
        }
        public static bool DeleteService(int ID)
        {

            int reader = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "DELETE FROM Services WHERE Service_ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                reader = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return (reader > 0);
        }
        public static bool IsServiceExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found=1 FROM Services WHERE Service_ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAllServices()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Services";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    dt.Load(reader);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }



    }
}
