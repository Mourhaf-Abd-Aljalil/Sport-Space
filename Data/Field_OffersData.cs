using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Data
{
    public class Field_OffersData
    {
        public static DataTable GetFieldAndItsOffers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_Name , O.Descripyion , O.DiscountPercenttag From Field f right Join Offers o ON O.Field_ID = f.Field_ID order by f.Field_Name";

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

        public static DataTable GetFieldAndItsOffersGreaterThan(decimal DiscountPercenttag)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_Name , O.Descripyion , O.DiscountPercenttag From Field f " +
                "right Join Offers o ON O.Field_ID = f.Field_ID where o.DiscountPercenttag > @DiscountPercenttag " +
                "order by f.Field_Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DiscountPercenttag", DiscountPercenttag);

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

        public static DataTable GetFieldAndItsOffersLessThan(decimal DiscountPercenttag)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_Name , O.Descripyion , O.DiscountPercenttag From Field f " +
                "right Join Offers o ON O.Field_ID = f.Field_ID where o.DiscountPercenttag < @DiscountPercenttag " +
                "order by f.Field_Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DiscountPercenttag", DiscountPercenttag);

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

        public static DataTable GetFieldsLeastTwoOffers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_Name,fo.Descripyion,fo.DiscountPercenttag from Offers fo inner join Field f on f.Field_ID = fo.Field_ID where fo.Field_ID IN" +
                "( select f.Field_ID from Field f inner join Offers fo on f.Field_ID = fo.Field_ID group by f.Field_ID having COUNT(fo.Offer_ID) > 2)" +
                "order by  f.Field_Name";

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
        public static DataTable GetFieldsAndNumberOfferrs()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "select f.Field_ID,f.Field_Name , COUNT(f.Field_Name) as NumberOfOffersForEachField " +
                "From Field f Join Offers o ON O.Field_ID = f.Field_ID Group by f.Field_ID,f.Field_Name" +
                " Order by NumberOfOffersForEachField";

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
