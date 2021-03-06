﻿using WST.BusinessLogic.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class UsunUzytkownika : System.Web.UI.Page
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
                InitUsunUzytkownika();
            }

        }
        #region Methods
        private void InitUsunUzytkownika()
        {
            var uzytkownicy = new WSTApi().GetUzytkownicy();
            gvUzytkownicy.DataSource = uzytkownicy.Data;
            gvUzytkownicy.DataBind();
        }

        protected void lnkDelete(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            var uzytkownicy = new WSTApi().DelUzytkownicy(id);
        }

        protected void lnkShow1(Object sender, CommandEventArgs e)
        {
            Global.Id_wybranego_uzytkownika = e.CommandArgument.ToString();
            Response.Redirect("WypozyczeniaUzytkownika.aspx");
        }

        protected void lnkShow2(Object sender, CommandEventArgs e)
        {
            Global.Id_wybranego_uzytkownika = e.CommandArgument.ToString();
            Response.Redirect("RezerwacjeUzytkownika.aspx");
        }
        #endregion
    }
}