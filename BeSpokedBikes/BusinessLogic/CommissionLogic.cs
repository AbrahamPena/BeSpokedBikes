using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.BusinessLogic
{
    public class CommissionLogic
    {
        public static List<Entities.Commission> GetCommissions(DateTime start, DateTime end)
        {
            List<Entities.Commission> c = new List<Entities.Commission>();
            List<Entities.Sales> sale = Entities.Sales.GetSales();
            List<Entities.Products> prod = Entities.Products.GetProducts();
            List<Entities.Salesperson> sp = Entities.Salesperson.GetSalespeople();

            //string query = string.Format("SELECT p.[name], p.purchase_price, p.sale_price, p.commision_percent, s.sales_date, CONCAT(sp.first_name, ' ', sp.last_name) AS sp FROM sales AS s INNER JOIN products AS p ON s.product = p.id " +
            //    "INNER JOIN salesperson AS sp ON s.salesperson = sp.id WHERE s.sales_date BETWEEN '{0}' AND '{1}'", start, end);
            //System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);

            var result = from t1 in sale
                         from t2 in prod.Where(x => t1.Product == x.ID)
                         from t3 in sp.Where(x => t1.Salesperson == x.ID)
                         select new { ID = t1.ID, Name = t2.Name, Purchase = t2.PurchasePrice, Sales = t2.SalePrice, Comm = t2.CommissionPercentage, Month = t1.SalesDate.Month, Day = t1.SalesDate.Day, Year = t1.SalesDate.Year, Salesperson = t3.FirstName + " " + t3.LastName };
            var testList = result.GroupBy(x => x.Salesperson).Select(x => new { Name = x.Key, Sales = x.GroupBy(u => u.ID).Count(), Comm = x.Sum(u => (u.Sales - u.Purchase) * (u.Comm / 100)) });

            Entities.Commission comm = null;
            foreach (var item in testList)
            {
                comm = new Entities.Commission();
                comm.Name = item.Name;
                comm.CommissionTotal = item.Comm;
                comm.Sales = item.Sales;
                c.Add(comm);
            }

            return c;
        }
    }
}