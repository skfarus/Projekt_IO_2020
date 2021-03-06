﻿using WST.BusinessLogic.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class WypozyczeniaUzytkownika : System.Web.UI.Page
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
                InitWypozyczeniaUzytkownika();
            }

        }
        #region Methods
        private void InitWypozyczeniaUzytkownika()
        {
            var wypozyczenia = new WSTApi().GetWypozyczeniaUzytkownika(Global.Id_wybranego_uzytkownika);
            gvWypozyczenia.DataSource = wypozyczenia.Data;
            gvWypozyczenia.DataBind();
        }
        #endregion
    }
}