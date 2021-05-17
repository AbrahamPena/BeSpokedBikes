using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class Sales
    {
        private int _id { get; set; }
        private int _product { get; set; }
        private string _productName { get; set; }
        private int _salesperson { get; set; }
        private string _salespersonName { get; set; }
        private int _customer { get; set; }
        private string _customerName { get; set; }
        private DateTime _salesDate { get; set; }
        private decimal _salesPrice { get; set; }
        private decimal _commission { get; set; }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

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

        public int Salesperson
        {
            get { return _salesperson; }
            set { _salesperson = value; }
        }

        public string SalespersonName
        {
            get { return _salespersonName; }
            set { _salespersonName = value; }
        }

        public int Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        public decimal SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        public decimal Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }

        public static List<Sales> GetSales()
        {
            List<Sales> list = new List<Sales>();

            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet("SELECT s.*, p.[name] AS pname, p.sale_price, p.commision_percent, sp.[first_name] AS fname, sp.[last_name] AS lname, c.[first_name] AS cfname, c.[last_name] AS clname FROM sales AS s INNER JOIN products AS p ON s.product = p.id INNER JOIN salesperson AS sp ON s.salesperson = sp.id INNER JOIN customer AS c on s.customer = c.id");
            Sales sale = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sale = new Sales();
                sale.ID = (int)ds.Tables[0].Rows[i]["id"];
                sale.Product = (int)ds.Tables[0].Rows[i]["product"];
                sale.ProductName = ds.Tables[0].Rows[i]["pname"].ToString();
                sale.Salesperson = (int)ds.Tables[0].Rows[i]["salesperson"];
                sale.SalespersonName = ds.Tables[0].Rows[i]["fname"].ToString() + " " + ds.Tables[0].Rows[i]["lname"].ToString();
                sale.Customer = (int)ds.Tables[0].Rows[i]["customer"];
                sale.CustomerName = ds.Tables[0].Rows[i]["cfname"].ToString() + " " + ds.Tables[0].Rows[i]["clname"].ToString();
                sale.SalesDate = (DateTime)ds.Tables[0].Rows[i]["sales_date"];
                sale.SalesPrice = (decimal)ds.Tables[0].Rows[i]["sale_price"];
                sale.Commission = (decimal)ds.Tables[0].Rows[i]["commision_percent"];
                list.Add(sale);
            }

            return list;
        }

        public static Sales GetSale(int id)
        {
            List<Sales> list = new List<Sales>();

            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet("SELECT s.*, p.[name] AS pname, p.sale_price, p.commision_percent, sp.[first_name] AS fname, sp.[last_name] AS lname, c.[first_name] AS cfname, c.[last_name] AS clname FROM sales AS s INNER JOIN products AS p ON s.product = p.id INNER JOIN salesperson AS sp ON s.salesperson = sp.id INNER JOIN customer AS c on s.customer = c.id WHERE s.id = " + id);
            Sales sale = null;
            sale = new Sales();
            sale.ID = (int)ds.Tables[0].Rows[0]["id"];
            sale.Product = (int)ds.Tables[0].Rows[0]["product"];
            sale.ProductName = ds.Tables[0].Rows[0]["pname"].ToString();
            sale.Salesperson = (int)ds.Tables[0].Rows[0]["salesperson"];
            sale.SalespersonName = ds.Tables[0].Rows[0]["fname"].ToString() + " " + ds.Tables[0].Rows[0]["lname"].ToString();
            sale.Customer = (int)ds.Tables[0].Rows[0]["customer"];
            sale.CustomerName = ds.Tables[0].Rows[0]["cfname"].ToString() + " " + ds.Tables[0].Rows[0]["clname"].ToString();
            sale.SalesDate = (DateTime)ds.Tables[0].Rows[0]["sales_date"];
            sale.SalesPrice = (decimal)ds.Tables[0].Rows[0]["sale_price"];
            sale.Commission = (decimal)ds.Tables[0].Rows[0]["commision_percent"];
            list.Add(sale);

            return sale;
        }

        public void InsertSale(Sales s)
        {
            string query = string.Format("INSERT INTO sales VALUES ({0}, {1}, {2}, '{3}')", s.Product, s.Salesperson, s.Customer, s.SalesDate);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }

        public void UpdateSale(Sales s)
        {
            string query = string.Format("UPDATE sales SET product = {0}, salesperson = {1}, customer = {2}, sales_date = '{3}' WHERE id = {4}", s.Product, s.Salesperson, s.Customer, s.SalesDate, s.ID);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }
    }
}