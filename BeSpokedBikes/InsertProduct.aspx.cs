using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string query = "SELECT * FROM manufacturer";
                System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);

                ddlMFG.DataSource = ds.Tables[0];
                ddlMFG.DataTextField = "name";
                ddlMFG.DataValueField = "id";
                ddlMFG.DataBind();

                query = "SELECT * FROM bike_style";
                ds = Utilities.DataAccess.GetDataSet(query);

                ddlBS.DataSource = ds.Tables[0];
                ddlBS.DataTextField = "name";
                ddlBS.DataValueField = "id";
                ddlBS.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Entities.Products p = new Entities.Products();
            p.Name = txtName.Text;
            p.Manufacturer = int.Parse(ddlMFG.SelectedValue);
            p.ManufacturerName = ddlMFG.Text;
            p.Style = int.Parse(ddlBS.SelectedValue);
            p.StyleName = ddlBS.Text;
            p.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
            p.SalePrice = Convert.ToDecimal(txtSalePrice.Text);
            p.QtyAvaiable = int.Parse(txtQty.Text);
            p.CommissionPercentage = Convert.ToDecimal(txtCommission.Text);

            p.InsertProduct(p);

            Response.Redirect("Products.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}