using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeSpokedBikes
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"].ToString();
            
            switch (type)
            {
                case "salesperson":
                    phContent.Controls.Add(LoadControl("WebControls/SalespersonEdit.ascx"));
                    break;
                case "product":
                    phContent.Controls.Add(LoadControl("WebControls/ProductEdit.ascx"));
                    break;
                case "customer":
                    phContent.Controls.Add(LoadControl("WebControls/CustomerEdit.ascx"));
                    break;
            }
        }
    }
}