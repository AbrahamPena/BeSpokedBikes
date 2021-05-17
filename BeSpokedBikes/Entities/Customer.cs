using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class Customer
    {
        private int _id { get; set; }
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _address { get; set; }
        private string _phone { get; set; }
        private DateTime _startDate { get; set; }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet("SELECT * FROM customer");
            Customer customer = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                customer = new Customer();
                customer.ID = (int)ds.Tables[0].Rows[i]["id"];
                customer.FirstName = ds.Tables[0].Rows[i]["first_name"].ToString();
                customer.LastName = ds.Tables[0].Rows[i]["last_name"].ToString();
                customer.Address = ds.Tables[0].Rows[i]["address"].ToString();
                customer.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                customer.StartDate = (DateTime)ds.Tables[0].Rows[i]["start_date"];
                list.Add(customer);
            }

            return list;
        }

        public static Customer GetCustomer(int id)
        {
            string query = string.Format("SELECT * FROM customer WHERE id = {0}", id);
            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);

            Customer c = new Customer();
            c.ID = (int)ds.Tables[0].Rows[0]["id"];
            c.FirstName = ds.Tables[0].Rows[0]["first_name"].ToString();
            c.LastName = ds.Tables[0].Rows[0]["last_name"].ToString();
            c.Address = ds.Tables[0].Rows[0]["address"].ToString();
            c.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
            c.StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"];

            return c;
        }

        public void InsertCustomer(Customer c)
        {
            string query = string.Format("INSERT INTO customer VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", c.FirstName, c.LastName, c.Address, c.Phone, c.StartDate);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }

        public void UpdateCustomer(Customer c)
        {
            string query = string.Format("UPDATE customer SET first_name = '{0}', last_name = '{1}', address = '{2}', phone = '{3}', start_date = '{4}' WHERE id = {5}", c.FirstName, c.LastName, c.Address, c.Phone, c.StartDate, c.ID);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }
    }
}