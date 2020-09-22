using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Events
        protected void btnLogout_Click(object sender, System.EventArgs e)
        {
            Global.uzytkownicy = null;
            Response.Redirect("Logowanie.aspx");
        }
        #endregion
    }
}