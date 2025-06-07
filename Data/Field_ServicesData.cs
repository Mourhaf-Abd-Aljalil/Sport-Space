using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Data
{
    public class Field_ServicesData
    {

        public static DataTable GetFieldsByService(string ServiceName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select Field_Services.Field_ID from Field INNER join Field_Services on Field_Services.Field_ID = Field.Field_ID INNER join Services on Services.Service_ID = Field_Services.Service_ID where Services.Service_Name = @ServiceName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ServiceName", ServiceName);


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

        public static DataTable GetAllFieldsWithServices()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_ID,s.Service_Name ,s.Service_Cost from Field f INner join Field_Services fs on f.Field_ID = fs.Field_ID inner join Services s on s.Service_ID = fs.Service_ID";

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

        public static DataTable GetFields_NumbersOfService()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_ID,COUNT(fs.Service_ID)as NumberOfServices from Field f INner join Field_Services fs on f.Field_ID = fs.Field_ID inner join Services s on s.Service_ID = fs.Service_ID group by f.Field_ID";

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

        public static DataTable GetAllFieldsWithServicesLessThan(decimal Cost)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_ID,s.Service_Name , s.Service_Cost from Field f Inner join Field_Services fs on f.Field_ID = fs.Field_ID inner join Services s on s.Service_ID = fs.Service_ID where s.Service_Cost < @Cost order by s.Service_Cost";

            SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Cost", Cost);


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

        public static DataTable GetAllFieldsWithServicesGreaterThan(decimal Cost)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_ID,s.Service_Name , s.Service_Cost from Field f Inner join Field_Services fs on f.Field_ID = fs.Field_ID inner join Services s on s.Service_ID = fs.Service_ID where s.Service_Cost > @Cost order by s.Service_Cost";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Cost", Cost);


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
