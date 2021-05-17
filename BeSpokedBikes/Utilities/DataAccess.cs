using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BeSpokedBikes.Utilities
{
    public class DataAccess
    {
        public static void ExecuteNonQuery(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BeSpoked"].ConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                string message = "Error running query " + ex.ToString();
            }
        }

        public static DataSet GetDataSet(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BeSpoked"].ConnectionString);
            DataSet ds = null;

            try
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                adapter.Fill(ds);

                conn.Close();
            }
            catch (Exception ex)
            {
                string message = "Error getting dataset " + ex.ToString();
            }

            return ds;
        }
    }
}