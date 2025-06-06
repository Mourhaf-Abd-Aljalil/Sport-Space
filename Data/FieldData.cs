using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using SportSpaceDataAccessLayer.ClassDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SportSpaceDataAccessLayer.Data
{
    public class FieldData
    {

        public static FieldDTO FindFieldByID(int FieldID)
        {
            FieldDTO Field = new FieldDTO();


            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = $"select * from Field where Field_ID = @Field_ID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@Field_ID", FieldID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Field.FieldID = FieldID;
                    Field.FieldName = (string)reader["Field_Name"];
                    Field.OwnerID = (int)reader["Owner_ID"];
                    Field.Location = (string)reader["Location"];
                    Field.Capacity = (int)reader["Capacity"];
                    Field.FieldType = (string)reader["Field_Type"];
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
            return Field;
        }
        /* public static bool FindFieldByName(ref int ID, string FieldName, ref string Email, ref string PhoneNumber)
         {
             bool Isfound = false;
             SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

             string query = "select * from Field where Name = @FieldName";

             SqlCommand command = new SqlCommand(query, connection);

             command.Parameters.AddWithValue("@FieldName", FieldName);

             try
             {
                 connection.Open();

                 SqlDataReader reader = command.ExecuteReader();
                 if (reader.Read())
                 {
                     Isfound = true;
                     ID = (int)reader["Field_ID"];
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

        public static int AddNewField(FieldDTO Field)
        {
            int Id = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Field
             VALUES
           (@Owner_ID
           ,@Name
           ,@Location
           ,@FieldType
           ,@Capacity
		   );"
                + "select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Owner_ID", Field.OwnerID);
            command.Parameters.AddWithValue("@Name", Field.FieldName);
            command.Parameters.AddWithValue("@Location", Field.Location);
            command.Parameters.AddWithValue("@FieldType", Field.FieldType);
            command.Parameters.AddWithValue("@Capacity", Field.Capacity);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inserted))
                {
                    Id = inserted;
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
        public static bool UpdateField(FieldDTO Field)
        {

            int restut = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "UPDATE Field SET Owner_ID = @Owner_ID, Field_Name = @Name, Location = @Location,Field_Type = @FieldType,Capacity = @Capacity " +
                "WHERE Field_ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Owner_ID", Field.OwnerID);
            command.Parameters.AddWithValue("@Name", Field.FieldName);
            command.Parameters.AddWithValue("@Location", Field.Location);
            command.Parameters.AddWithValue("@FieldType", Field.FieldType);
            command.Parameters.AddWithValue("@Capacity", Field.Capacity);
            command.Parameters.AddWithValue("@ID", Field.FieldID);


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
        public static bool DeleteField(int ID)
        {

            int reader = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "DELETE FROM Field WHERE Field_ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", ID);

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
        public static bool IsFieldExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found=1 FROM Field WHERE Field_ID = @ID";

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
        public static DataTable GetAllFields()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Field";

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

        public static DataTable GetAllFieldsByTypeORType(string Type1 , string Type2)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Field_ID ,Field_Name FROM Field where Field_Type in(@T1 , @T2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@T1", Type1);
            command.Parameters.AddWithValue("@T2", Type2);

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

        public static DataTable GetAllFieldsByCapacity(int Capacity)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Field_ID ,Field_Name FROM Field where Capacity = @Capacity";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Capacity", Capacity);
            

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
