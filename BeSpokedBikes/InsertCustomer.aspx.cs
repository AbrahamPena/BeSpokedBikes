using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes
{
    public partial class InsertCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Entities.Customer c = new Entities.Customer();
            c.FirstName = txtFirst.Text;
            c.LastName = txtLast.Text;
            c.Address = txtAddress.Text;
            c.Phone = txtPhone.Text;
            c.StartDate = Convert.ToDateTime(txtStart.Text);

            c.InsertCustomer(c);

            Response.Redirect("Customer.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
    }
}