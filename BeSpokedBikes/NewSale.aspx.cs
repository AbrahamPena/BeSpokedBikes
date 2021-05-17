using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes
{
    public partial class NewSale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string query = "SELECT * FROM products";
                System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);

                ddlProduct.DataSource = ds.Tables[0];
                ddlProduct.DataTextField = "name";
                ddlProduct.DataValueField = "id";
                ddlProduct.DataBind();

                query = "SELECT id, CONCAT(first_name, ' ', last_name) AS [name] FROM salesperson";
                ds = Utilities.DataAccess.GetDataSet(query);

                ddlSalesperson.DataSource = ds.Tables[0];
                ddlSalesperson.DataTextField = "name";
                ddlSalesperson.DataValueField = "id";
                ddlSalesperson.DataBind();

                query = "SELECT id, CONCAT(first_name, ' ', last_name) AS [name] FROM customer";
                ds = Utilities.DataAccess.GetDataSet(query);

                ddlCustomer.DataSource = ds.Tables[0];
                ddlCustomer.DataTextField = "name";
                ddlCustomer.DataValueField = "id";
                ddlCustomer.DataBind();
            }

            if (Request.QueryString["type"] != null)
            {
                spnError.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Entities.Products p = Entities.Products.GetProduct(int.Parse(ddlProduct.SelectedValue));
            Entities.Sales s = new Entities.Sales();

            s.Product = p.ID;
            s.Salesperson = int.Parse(ddlSalesperson.SelectedValue);
            s.Customer = int.Parse(ddlCustomer.SelectedValue);
            s.SalesDate = Convert.ToDateTime(txtSales.Text);

            BusinessLogic.SaleLogic sl = new BusinessLogic.SaleLogic();
            bool saleMade = sl.SaleProduct(p, s);

            if (saleMade)
            {
                Response.Redirect("Sales.aspx");
            }
            else
            {
                Response.Redirect("NewSale.aspx?type=error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sales.aspx");
        }
    }
}