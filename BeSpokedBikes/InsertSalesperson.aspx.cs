using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes
{
    public partial class InsertSalesperson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Entities.Salesperson sp = new Entities.Salesperson();
            sp.FirstName = txtFirst.Text;
            sp.LastName = txtSecond.Text;
            sp.Address = txtAddress.Text;
            sp.Phone = txtPhone.Text;
            sp.StartDate = Convert.ToDateTime(txtStart.Text);
            sp.TerminationDate = Convert.ToDateTime(txtEnd.Text);
            sp.Manager = txtManager.Text;

            sp.InsertSalesperson(sp);

            Response.Redirect("Salespeople.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salespeople.aspx");
        }
    }
}