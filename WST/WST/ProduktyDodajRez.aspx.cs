using WST.BusinessLogic.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class ProduktyDodajRez : System.Web.UI.Page
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
                InitUsunProdukt();
            }

        }
        #region Methods
        private void InitUsunProdukt()
        {
            var produkty = new WSTApi().GetProdukty();
            gvProdukty.DataSource = produkty.Data;
            gvProdukty.DataBind();
        }

        protected void lnkRez(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Global.Id_produktu_rezerwacja = id.ToString();
            Response.Redirect("DodajRez.aspx");
        }
        #endregion
    }
}