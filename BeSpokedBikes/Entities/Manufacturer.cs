using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class Manufacturer
    {
        private int _id { get; set; }
        private string _name { get; set; }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void InsertManufacturer(Manufacturer m)
        {
            string query = string.Format("INSERT INTO manufacturer VALUES ('{0}')", m.Name);
        }

        public void UpdateManufacturer(Manufacturer m)
        {
            string query = string.Format("UPDATE manufacturer SET name = '{0}' WHERE id = {1}", m.Name, m.ID);
        }
    }
}