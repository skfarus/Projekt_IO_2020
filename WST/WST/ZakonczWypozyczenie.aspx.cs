using WST.BusinessLogic.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class ZakonczWypozyczenie : System.Web.UI.Page
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
                InitZakonczWypozyczenie();
            }

        }
        #region Methods
        private void InitZakonczWypozyczenie()
        {
            var Wypozyczenia = new WSTApi().GetWypozyczenia();
            gvWypozyczenia.DataSource = Wypozyczenia.Data;
            gvWypozyczenia.DataBind();
        }

        protected void lnkZakoncz(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            var Wypozyczenia = new WSTApi().ZakWypozyczenie(id);
            Response.Redirect("ZakonczWypozyczenie.aspx");
        }
        #endregion
    }
}