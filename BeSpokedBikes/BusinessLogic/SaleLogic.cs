using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.BusinessLogic
{
    public class SaleLogic
    {
        public bool SaleProduct(Entities.Products product, Entities.Sales sales)
        {
            bool canSale = true;
            Entities.Products p = product;
            if (p.QtyAvaiable < 1)
            {
                canSale = false;
            }
            else
            {
                Entities.Sales s = new Entities.Sales();
                s.Product = p.ID;
                s.Salesperson = sales.Salesperson;
                s.Customer = sales.Customer;
                s.SalesDate = sales.SalesDate;

                UpdateProductQTY(p.ID);

                s.InsertSale(s);
            }

            return canSale;
        }

        protected void UpdateProductQTY(int productID)
        {
            string query = string.Format("UPDATE products SET qty_available = qty_available - 1 WHERE id = {0}", productID);
            Utilities.DataAccess.ExecuteNonQuery(query);
        }
    }
}