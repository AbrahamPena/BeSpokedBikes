using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes.WebControls
{
    public partial class CustomerEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idGet = int.Parse(Request.QueryString["id"].ToString());
            Entities.Customer c = new Entities.Customer();
            c = Entities.Customer.GetCustomer(idGet);

            txtFirst.Text = c.FirstName;
            txtLast.Text = c.LastName;
            txtAddress.Text = c.Address;
            txtPhone.Text = c.Address;
            txtStart.Text = c.StartDate.ToShortDateString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int idGet = int.Parse(Request.QueryString["id"].ToString());
            Entities.Customer c = new Entities.Customer();
            c.FirstName = txtFirst.Text;
            c.LastName = txtLast.Text;
            c.Address = txtAddress.Text;
            c.Phone = txtPhone.Text;
            c.StartDate = Convert.ToDateTime(txtStart.Text);

            c.UpdateCustomer(c);

            Response.Redirect("Customer.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
    }
}