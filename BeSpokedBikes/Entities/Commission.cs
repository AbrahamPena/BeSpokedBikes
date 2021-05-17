using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class Commission
    {
        private string _name { get; set; }
        private int _sales { get; set; }
        private decimal _commissionTotal { get; set; }
        private DateTime _saleDate { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Sales
        {
            get { return _sales; }
            set { _sales = value; }
        }

        public decimal CommissionTotal
        {
            get { return _commissionTotal; }
            set { _commissionTotal = value; }
        }

        public DateTime SaleDate
        {
            get { return _saleDate; }
            set { _saleDate = value; }
        }
    }
}