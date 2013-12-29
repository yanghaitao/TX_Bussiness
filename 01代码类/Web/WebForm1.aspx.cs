using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using LitJson;

namespace TX_Bussiness.Web
{
    public partial class WebForm1 : Comm.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string list = new Select().From(Role.Schema).ExecuteXML("rolelist","role");
           Role role =Role.FetchByID(1);
          
           //string str= LitJson.JsonMapper.ToJson(list[0]);
          // Response.Write(str);
        }
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}