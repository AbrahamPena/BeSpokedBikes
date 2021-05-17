using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class Discount
    {
        private int _product { get; set; }
        private string _productName { get; set; }
        private DateTime _beginDate { get; set; }
        private DateTime _endDate { get; set; }
        private double _discountPercentage { get; set; }

        public int Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { _beginDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public double DiscountPercentage
        {
            get { return _discountPercentage; }
            set { _discountPercentage = value; }
        }

        public void InsertDiscount(Discount d)
        {
            string query = string.Format("INSERT INTO discount VALUES ({0}, {1}, {2}, {3})", d.Product, d.BeginDate, d.EndDate, d.DiscountPercentage);
        }

        public void UpdateDiscount(Discount d)
        {
            string query = string.Format("UPDATE discount SET begin_date = {0}, end_date = {1}, discount_percentage = {2} WHERE product = {3}", d.BeginDate, d.EndDate, d.DiscountPercentage, d.Product);
        }
    }
}