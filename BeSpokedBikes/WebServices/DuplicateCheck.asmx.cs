using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BeSpokedBikes.WebServices
{
    /// <summary>
    /// Summary description for DuplicateCheck
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DuplicateCheck : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public string DuplicateProduct(string name)
        {
            string query = string.Format("SELECT [name] FROM products WHERE [name] = '{0}'", name);
            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);
            StringWriter sw = new StringWriter();

            if (ds.Tables[0].Rows.Count > 0)
            {
                using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    jtw.WriteStartArray();
                    jtw.WriteStartObject();
                    jtw.WritePropertyName("duplicate");
                    jtw.WriteValue(true);
                    jtw.WriteEndObject();
                    jtw.WriteEndArray();
                }
            }
            else
            {
                using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    jtw.WriteStartArray();
                    jtw.WriteStartObject();
                    jtw.WritePropertyName("duplicate");
                    jtw.WriteValue(false);
                    jtw.WriteEndObject();
                    jtw.WriteEndArray();
                }
            }

            return sw.ToString();
        }

        [WebMethod(true)]
        public string DuplicateSalesperson(string fname, string lname)
        {
            string query = string.Format("SELECT [id] FROM salesperson WHERE first_name = '{0}' AND last_name = '{1}'", fname, lname);
            System.Data.DataSet ds = Utilities.DataAccess.GetDataSet(query);
            StringWriter sw = new StringWriter();

            if (ds.Tables[0].Rows.Count > 0)
            {
                using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    jtw.WriteStartArray();
                    jtw.WriteStartObject();
                    jtw.WritePropertyName("duplicate");
                    jtw.WriteValue(true);
                    jtw.WriteEndObject();
                    jtw.WriteEndArray();
                }
            }
            else
            {
                using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    jtw.WriteStartArray();
                    jtw.WriteStartObject();
                    jtw.WritePropertyName("duplicate");
                    jtw.WriteValue(false);
                    jtw.WriteEndObject();
                    jtw.WriteEndArray();
                }
            }

            return sw.ToString();
        }
    }
}
