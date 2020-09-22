using WST.BusinessLogic.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class MojeRezerwacje : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Global.uzytkownicy != null && Global.uzytkownicy[0].Admin.Length > 0)
            {
                if (Global.uzytkownicy[0].Admin.ToUpper() == "TAK")
                {
                    this.Page.MasterPageFile = "~/Admin.master";
                }
                else
                {
                    this.Page.MasterPageFile = "~/User.master";
                }
            }
            else
            {
                this.Page.MasterPageFile = "~/Layout.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitRezerwacje();
            }

        }
        #region Methods
        private void InitRezerwacje()
        {
            var rezerwacje = new WSTApi().GetRezerwacje(Global.uzytkownicy[0].Id);
            gvRezerwacje.DataSource = rezerwacje.Data;
            gvRezerwacje.DataBind();
        }

        protected void lnkDelete(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            var rezerwacje = new WSTApi().DelRezerwacje(id);
            Response.Redirect("MojeRezerwacje.aspx");
        }
        #endregion
    }
}