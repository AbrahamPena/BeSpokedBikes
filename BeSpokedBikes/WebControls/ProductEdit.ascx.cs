using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes.WebControls
{
    public partial class ProductEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idGet = Convert.ToInt32(Request.QueryString["id"].ToString());
            Entities.Products prod = new Entities.Products();
            prod = Entities.Products.GetProduct(idGet);

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

            txtName.Text = prod.Name;
            txtQty.Text = prod.QtyAvaiable.ToString();
            txtPurchasePrice.Text = prod.PurchasePrice.ToString();
            txtSalePrice.Text = prod.SalePrice.ToString();
            txtCommission.Text = prod.CommissionPercentage.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Entities.Products prod = new Entities.Products();
            int idGet = Convert.ToInt32(Request.QueryString["id"].ToString());
            prod.ID = idGet;
            prod.Name = txtName.Text;
            prod.Manufacturer = int.Parse(ddlMFG.SelectedValue);
            prod.ManufacturerName = ddlMFG.Text;
            prod.Style = int.Parse(ddlBS.SelectedValue);
            prod.StyleName = ddlBS.Text;
            prod.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
            prod.SalePrice = Convert.ToDecimal(txtSalePrice.Text);
            prod.QtyAvaiable = int.Parse(txtQty.Text);
            prod.CommissionPercentage = Convert.ToDecimal(txtCommission.Text);

            prod.UpdateProduct(prod);

            Response.Redirect("Products.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}