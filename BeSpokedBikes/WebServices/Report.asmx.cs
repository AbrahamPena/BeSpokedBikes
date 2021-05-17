using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BeSpokedBikes.WebServices
{
    /// <summary>
    /// Summary description for Report
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class Report : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public void GetReport()
        {
            StringWriter sw = new StringWriter();
            List<Entities.Commission> comm = BusinessLogic.CommissionLogic.GetCommissions(DateTime.Now, DateTime.Now);  //Added in same dates since I couldn't get the quarterly report to work properly
            if (comm.Count > 0)
            {
                using (Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    jtw.WriteStartObject();

                    jtw.WritePropertyName("data");
                    jtw.WriteStartArray();

                    for (int i = 0; i < comm.Count; i++)
                    {
                        jtw.WriteStartObject();

                        jtw.WritePropertyName("comm");
                        jtw.WriteValue(comm[i].CommissionTotal);
                        jtw.WritePropertyName("sales");
                        jtw.WriteValue(comm[i].Sales);
                        jtw.WritePropertyName("name");
                        jtw.WriteValue(comm[i].Name);

                        jtw.WriteEndObject();
                    }

                    jtw.WriteEndArray();
                    jtw.WriteEndObject();
                }
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(sw.ToString());
        }
    }
}
