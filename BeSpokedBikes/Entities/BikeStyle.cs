using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class BikeStyle
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

        public void InsertBikeStyle(BikeStyle bs)
        {
            string query = string.Format("INSERT INTO bike_style ('{0}')", bs.Name);
        }

        public void UpdateBikeStyle(BikeStyle bs)
        {
            string query = string.Format("UPDATE bike_style SET name = '{0}' WHERE id = {1}", bs.Name, bs.ID);
        }
    }  
}