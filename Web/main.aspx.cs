using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TX_Bussiness.Web
{
    public partial class main : Comm.BasePage
    {
        protected Yannis.DAO.User model;
        protected void Page_Load(object sender, EventArgs e)
        {
            model= GetUserInfo();
        }
    }
}