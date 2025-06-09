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
    public class OffersData
    {
        public static OffersModel FindOffersByID(int Offer_ID)
        {
            OffersModel Offer = new OffersModel();


            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = $"select * from Offers where Offer_ID = @Offer_ID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@Offer_ID", Offer_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Offer.Offers_ID = Offer_ID;
                    Offer.Field_ID = (int)reader["Field_ID"];
                    Offer.Description = (string)reader["Descripyion"];
                    Offer.DiscountPercenttag= (decimal)reader["DiscountPercenttag"];
                    Offer.Start_Date = (DateTime)reader["Start_Date"];
                    Offer.End_Date = (DateTime)reader["End_Date"];
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
            return Offer;
        }
        public static int AddNewOffer(OffersModel Offer)
        {
            int Id = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Offers
                            VALUES(@Field_ID,@Descripyion,@DiscountPercenttag,@Start_Date,@End_Date);
	                        select SCOPE_IDENTITY();
";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Field_ID", Offer.Field_ID);
            command.Parameters.AddWithValue("@Descripyion", Offer.Description);
            command.Parameters.AddWithValue("@DiscountPercenttag", Offer.DiscountPercenttag);
            command.Parameters.AddWithValue("@Start_Date", Offer.Start_Date);
            command.Parameters.AddWithValue("@End_Date", Offer.End_Date);

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
        public static bool UpdateOffer(OffersModel Offer)
        {

            int restut = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "UPDATE Offers SET Field_ID = @Field_ID, Descripyion = @Descripyion, DiscountPercenttag = @DiscountPercenttag," +
                " Start_Date = @Start_Date, End_Date = @End_Date WHERE Offer_ID = @Offer_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Field_ID", Offer.Field_ID);
            command.Parameters.AddWithValue("@Descripyion", Offer.Description);
            command.Parameters.AddWithValue("@DiscountPercenttag", Offer.DiscountPercenttag);
            command.Parameters.AddWithValue("@Start_Date", Offer.Start_Date);
            command.Parameters.AddWithValue("@End_Date", Offer.End_Date);
            command.Parameters.AddWithValue("@Offer_ID", Offer.Offers_ID);


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
        public static bool DeleteOffer(int ID)
        {

            int reader = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "DELETE FROM Offers WHERE Offer_ID = @ID";

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
        public static bool IsOfferExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found=1 FROM Offers WHERE Offer_ID = @ID";

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
        public static DataTable GetAllOffers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Offers";

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
