using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes.WebControls
{
    public partial class SalespersonEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idGet = Convert.ToInt32(Request.QueryString["id"].ToString());
            Entities.Salesperson sp = new Entities.Salesperson();
            sp = Entities.Salesperson.GetSalesperson(idGet);

            txtFirstName.Text = sp.FirstName;
            txtLastName.Text = sp.LastName;
            txtAddress.Text = sp.Address;
            txtPhone.Text = sp.Phone;
            txtStart.Text = sp.StartDate.ToShortDateString();
            txtEnd.Text = sp.TerminationDate.ToShortDateString();
            txtManager.Text = sp.Manager;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int idGet = Convert.ToInt32(Request.QueryString["id"].ToString());
            Entities.Salesperson sp = new Entities.Salesperson();
            sp.ID = idGet;
            sp.FirstName = txtFirstName.Text;
            sp.LastName = txtLastName.Text;
            sp.Address = txtAddress.Text;
            sp.Phone = txtPhone.Text;
            sp.StartDate = Convert.ToDateTime(txtStart.Text);
            sp.TerminationDate = Convert.ToDateTime(txtEnd.Text);
            sp.Manager = txtManager.Text;

            sp.UpdateSalesperson(sp);
            Response.Redirect("Salespeople.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salespeople.aspx");
        }
    }
}