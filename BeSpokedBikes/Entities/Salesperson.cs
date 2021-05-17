using System;
using System.Collections.Generic;

namespace BeSpokedBikes.Entities
{
    public class Salesperson
    {
        private int _id { get; set; }
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _address { get; set; }
        private string _phone { get; set; }
        private DateTime _startDate { get; set; }
        private DateTime _terminationDate { get; set; }
        private string _manager { get; set; }

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

        public DateTime TerminationDate
        {
            get { return _terminationDate; }
            set { _terminationDate = value; }
        }

        public string Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        public static List<Salesperson> GetSalespeople() 
        {
            List<Salesperson> list = new List<Salesperson>();

            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet("SELECT * from salesperson");
            Salesperson sp = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sp = new Salesperson();
                sp.ID = (int)ds.Tables[0].Rows[i]["id"];
                sp.FirstName = ds.Tables[0].Rows[i]["first_name"].ToString();
                sp.LastName = ds.Tables[0].Rows[i]["last_name"].ToString();
                sp.Address = ds.Tables[0].Rows[i]["address"].ToString();
                sp.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                sp.StartDate = (DateTime)ds.Tables[0].Rows[i]["start_date"];
                sp.TerminationDate = ds.Tables[0].Rows[i]["termination_date"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[i]["termination_date"]) : DateTime.MinValue;
                sp.Manager = ds.Tables[0].Rows[i]["manager"].ToString();
                list.Add(sp);
            }

            return list;
        }

        public static Salesperson GetSalesperson(int id)
        {
            string query = string.Format("SELECT * FROM salesperson WHERE id = {0}", id);
            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);

            Salesperson sp = new Salesperson();
            sp.ID = (int)ds.Tables[0].Rows[0]["id"];
            sp.FirstName = ds.Tables[0].Rows[0]["first_name"].ToString();
            sp.LastName = ds.Tables[0].Rows[0]["last_name"].ToString();
            sp.Address = ds.Tables[0].Rows[0]["address"].ToString();
            sp.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
            sp.StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"];
            sp.TerminationDate = (DateTime)ds.Tables[0].Rows[0]["termination_date"];
            sp.Manager = ds.Tables[0].Rows[0]["manager"].ToString();

            return sp;
        }

        public void InsertSalesperson(Salesperson sp)
        {
            string query = string.Format("INSERT INTO salesperson VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", sp.FirstName, sp.LastName, sp.Address, sp.Phone, sp.StartDate, sp.TerminationDate, sp.Manager);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }

        public void UpdateSalesperson(Salesperson sp)
        {
            string query = string.Format("UPDATE salesperson SET first_name = '{0}', last_name = '{1}', address = '{2}', phone = '{3}', start_date = '{4}', termination_date = '{5}', manager = '{6}' WHERE id = {7}", sp.FirstName, sp.LastName, sp.Address, sp.Phone, sp.StartDate,
                sp.TerminationDate, sp.Manager, sp.ID);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }
    }
}