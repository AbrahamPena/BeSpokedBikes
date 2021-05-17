using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Entities
{
    public class Products
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private int _manufacturer { get; set; }
        private string _manufacturerName { get; set; }
        private int _style { get; set; }
        private string _styleName { get; set; }
        private decimal _purchasePrice { get; set; }
        private decimal _salePrice { get; set; }
        private int _qtyAvaiable { get; set; }
        private decimal _commissionPercentage { get; set; }

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

        public int Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }

        public string ManufacturerName
        {
            get { return _manufacturerName; }
            set { _manufacturerName = value; }
        }

        public int Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public string StyleName
        {
            get { return _styleName; }
            set { _styleName = value; }
        }

        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set { _purchasePrice = value; }
        }

        public decimal SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = value; }
        }

        public int QtyAvaiable 
        {
            get { return _qtyAvaiable; }
            set { _qtyAvaiable = value; }
        }

        public decimal CommissionPercentage
        {
            get { return _commissionPercentage; }
            set { _commissionPercentage = value; }
        }

        public static List<Products> GetProducts()
        {
            List<Products> list = new List<Products>();

            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet("SELECT p.*, m.[name] AS mname, bs.[name] AS bike FROM products AS p LEFT OUTER JOIN manufacturer AS m ON p.manufacturer = m.id LEFT OUTER JOIN bike_style AS bs ON p.style = bs.id");
            Products product = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                product = new Products();
                product.ID = (int)ds.Tables[0].Rows[i]["id"];
                product.Name = ds.Tables[0].Rows[i]["name"].ToString();
                product.Manufacturer = (int)ds.Tables[0].Rows[i]["manufacturer"];
                product.ManufacturerName = ds.Tables[0].Rows[i]["mname"].ToString();
                product.Style = (int)ds.Tables[0].Rows[i]["style"];
                product.StyleName = ds.Tables[0].Rows[i]["bike"].ToString();
                product.PurchasePrice = (decimal)ds.Tables[0].Rows[i]["purchase_price"];
                product.SalePrice = (decimal)ds.Tables[0].Rows[i]["sale_price"];
                product.QtyAvaiable = (int)ds.Tables[0].Rows[i]["qty_available"];
                product.CommissionPercentage = (decimal)ds.Tables[0].Rows[i]["commision_percent"];
                list.Add(product);
            }

            return list;
        }

        public static Products GetProduct(int id)
        {
            string query = string.Format("SELECT p.*, m.[name] AS mname, bs.[name] AS bike FROM products AS p LEFT OUTER JOIN manufacturer AS m ON p.manufacturer = m.id LEFT OUTER JOIN bike_style AS bs ON p.style = bs.id WHERE p.id = {0}", id);
            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);

            Products product = new Products();
            product.ID = (int)ds.Tables[0].Rows[0]["id"];
            product.Name = ds.Tables[0].Rows[0]["name"].ToString();
            product.Manufacturer = (int)ds.Tables[0].Rows[0]["manufacturer"];
            product.ManufacturerName = ds.Tables[0].Rows[0]["mname"].ToString();
            product.Style = (int)ds.Tables[0].Rows[0]["style"];
            product.StyleName = ds.Tables[0].Rows[0]["bike"].ToString();
            product.PurchasePrice = (decimal)ds.Tables[0].Rows[0]["purchase_price"];
            product.SalePrice = (decimal)ds.Tables[0].Rows[0]["sale_price"];
            product.QtyAvaiable = (int)ds.Tables[0].Rows[0]["qty_available"];
            product.CommissionPercentage = (decimal)ds.Tables[0].Rows[0]["commision_percent"];

            return product;
        }

        public void InsertProduct(Products p)
        {
            string query = string.Format("INSERT INTO products VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6})", p.Name, p.Manufacturer, p.Style, p.PurchasePrice, p.SalePrice, p.QtyAvaiable, p.CommissionPercentage);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }

        public void UpdateProduct(Products p)
        {
            string query = string.Format("UPDATE products SET name = '{0}', manufacturer = {1}, style = {2}, purchase_price = {3}, sale_price = {4}, qty_available = {5}, commision_percent = {6} WHERE id = {7}", p.Name, p.Manufacturer, p.Style, p.PurchasePrice, p.SalePrice,
                p.QtyAvaiable, p.CommissionPercentage, p.ID);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }
    }
}