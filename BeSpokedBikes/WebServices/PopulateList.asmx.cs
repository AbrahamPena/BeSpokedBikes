using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using BeSpokedBikes.Entities;

namespace BeSpokedBikes.WebServices
{
    /// <summary>
    /// Summary description for PopulateList
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class PopulateList : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public void GetSalespersonList()
        {
            StringWriter sw = new StringWriter();

            List<Salesperson> list = Salesperson.GetSalespeople();
            using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                jtw.WriteStartObject();

                jtw.WritePropertyName("data");
                jtw.WriteStartArray();

                for (int i = 0; i < list.Count; i++)
                {
                    jtw.WriteStartObject();

                    jtw.WritePropertyName("id");
                    jtw.WriteValue(list[i].ID);
                    jtw.WritePropertyName("name");
                    jtw.WriteValue(list[i].FirstName + " " + list[i].LastName);
                    jtw.WritePropertyName("address");
                    jtw.WriteValue(list[i].Address);
                    jtw.WritePropertyName("phone");
                    jtw.WriteValue(list[i].Phone);
                    jtw.WritePropertyName("start_date");
                    jtw.WriteValue(list[i].StartDate.ToShortDateString());
                    jtw.WritePropertyName("termination_date");
                    jtw.WriteValue(list[i].TerminationDate.ToShortDateString());
                    jtw.WritePropertyName("manager");
                    jtw.WriteValue(list[i].Manager);

                    jtw.WriteEndObject();
                }

                jtw.WriteEndArray();
                jtw.WriteEndObject();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(sw.ToString());
        }

        [WebMethod(true)]
        public void GetProductList()
        {
            StringWriter sw = new StringWriter();

            List<Entities.Products> list = Entities.Products.GetProducts();
            using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                jtw.WriteStartObject();

                jtw.WritePropertyName("data");
                jtw.WriteStartArray();

                for (int i = 0; i < list.Count; i++)
                {
                    jtw.WriteStartObject();

                    jtw.WritePropertyName("id");
                    jtw.WriteValue(list[i].ID);
                    jtw.WritePropertyName("name");
                    jtw.WriteValue(list[i].Name);
                    jtw.WritePropertyName("manufacturer");
                    jtw.WriteValue(list[i].ManufacturerName);
                    jtw.WritePropertyName("style");
                    jtw.WriteValue(list[i].StyleName);
                    jtw.WritePropertyName("price");
                    jtw.WriteValue(list[i].SalePrice);
                    jtw.WritePropertyName("qty");
                    jtw.WriteValue(list[i].QtyAvaiable);

                    jtw.WriteEndObject();
                }

                jtw.WriteEndArray();
                jtw.WriteEndObject();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(sw.ToString());
        }

        [WebMethod(true)]
        public void GetCustomerList()
        {
            StringWriter sw = new StringWriter();

            List<Entities.Customer> list = Entities.Customer.GetCustomers();
            using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                jtw.WriteStartObject();

                jtw.WritePropertyName("data");
                jtw.WriteStartArray();

                for (int i = 0; i < list.Count; i++)
                {
                    jtw.WriteStartObject();

                    jtw.WritePropertyName("id");
                    jtw.WriteValue(list[i].ID);
                    jtw.WritePropertyName("fname");
                    jtw.WriteValue(list[i].FirstName);
                    jtw.WritePropertyName("lname");
                    jtw.WriteValue(list[i].LastName);
                    jtw.WritePropertyName("address");
                    jtw.WriteValue(list[i].Address);
                    jtw.WritePropertyName("phone");
                    jtw.WriteValue(list[i].Phone);
                    jtw.WritePropertyName("start");
                    jtw.WriteValue(list[i].StartDate.ToShortDateString());

                    jtw.WriteEndObject();
                }

                jtw.WriteEndArray();
                jtw.WriteEndObject();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(sw.ToString());
        }

        [WebMethod(true)]
        public void GetSaleList()
        {
            StringWriter sw = new StringWriter();

            List<Entities.Sales> list = Entities.Sales.GetSales();
            using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                jtw.WriteStartObject();

                jtw.WritePropertyName("data");
                jtw.WriteStartArray();

                for (int i = 0; i < list.Count; i++)
                {
                    jtw.WriteStartObject();

                    jtw.WritePropertyName("id");
                    jtw.WriteValue(list[i].ID);
                    jtw.WritePropertyName("product_id");
                    jtw.WriteValue(list[i].Product);
                    jtw.WritePropertyName("product");
                    jtw.WriteValue(list[i].ProductName);
                    jtw.WritePropertyName("sp_id");
                    jtw.WriteValue(list[i].Salesperson);
                    jtw.WritePropertyName("sp_name");
                    jtw.WriteValue(list[i].SalespersonName);
                    jtw.WritePropertyName("customer_id");
                    jtw.WriteValue(list[i].Customer);
                    jtw.WritePropertyName("customer");
                    jtw.WriteValue(list[i].CustomerName);
                    jtw.WritePropertyName("sales_date");
                    jtw.WriteValue(list[i].SalesDate.ToShortDateString());
                    jtw.WritePropertyName("price");
                    jtw.WriteValue(list[i].SalesPrice);
                    jtw.WritePropertyName("commission");
                    jtw.WriteValue(list[i].Commission);

                    jtw.WriteEndObject();
                }

                jtw.WriteEndArray();
                jtw.WriteEndObject();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(sw.ToString());
        }
    }
}
