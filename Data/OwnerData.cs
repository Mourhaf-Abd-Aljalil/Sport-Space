using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SportSpaceDataAccessLayer.ClassDTO;

namespace SportSpaceDataAccessLayer.Data
{
    public class OwnerData
    {
        public static OwnerDTO FindOwnerByID(int Owner_ID)
        {
            OwnerDTO owner = new OwnerDTO();
          

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = $"select * from Owner where Owner_ID = @Owner_ID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@Owner_ID", Owner_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    owner.ID = Owner_ID;
                    owner.OwnerName = (string)reader["Name"];
                    owner.Email = (string)reader["Email"];
                    owner.PhoneNumber = (string)reader["Phone_Number"];
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
            return owner;
        }
       /* public static bool FindOwnerByName(ref int ID, string OwnerName, ref string Email, ref string PhoneNumber)
        {
            bool Isfound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select * from Owner where Name = @OwnerName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OwnerName", OwnerName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Isfound = true;
                    ID = (int)reader["Owner_ID"];
                    Email = (string)reader["Email"];
                    PhoneNumber = (string)reader["Phone_Number"];
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
            return Isfound;
        }
       */

        public static bool AddNewOwner(OwnerDTO Owner)
        {

            int result = 0;


            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "INSERT INTO Owner VALUES (@Id, @Name ,@Email , @Phone)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", Owner.ID);
            command.Parameters.AddWithValue("@Name", Owner.OwnerName);
            command.Parameters.AddWithValue("@Email", Owner.Email);
            command.Parameters.AddWithValue("@Phone", Owner.PhoneNumber);

            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return (result > 0);
        }
        public static bool UpdateOwner(OwnerDTO Owner)
        {

            int restut = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "UPDATE Owner SET Name= @Name ,Email = @Email ,Phone_Number = @Phone WHERE Owner_ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", Owner.ID);
            command.Parameters.AddWithValue("@Name", Owner.OwnerName);
            command.Parameters.AddWithValue("@Email", Owner.Email);
            command.Parameters.AddWithValue("@Phone", Owner.PhoneNumber);

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
        public static bool DeleteOwner(int ID)
        {

            int reader = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "DELETE FROM Owner WHERE Owner_ID = @ID";

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
        public static bool IsOwnerExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found=1 FROM Owner WHERE Owner_ID = @ID";

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
        public static DataTable GetAllOwners()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Owner";

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
