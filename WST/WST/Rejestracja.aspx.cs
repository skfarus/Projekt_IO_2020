using WST.BusinessLogic.Api;
using WST.BusinessLogic.Api.Interface;
using WST.BusinessLogic.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST
{
    public partial class Rejestracja : System.Web.UI.Page
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

        }
        #region Methods
        private UzytkownicyDTO GetUzytkownikDTO()
        {
            return new UzytkownicyDTO()
            {
                Email = crtlRejestracja.Email,
                Haslo = crtlRejestracja.Haslo,
                Imie = crtlRejestracja.Imie,
                Nazwisko = crtlRejestracja.Nazwisko,
                Adres = crtlRejestracja.Adres,
                Telefon = crtlRejestracja.Telefon,
            };
        }
        #endregion

        #region Events
        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            var api = new WSTApi();
            var result = api.Rejestracja(GetUzytkownikDTO());

            if(!result.Success)
            {
                Trace.Warn(result.Errors);
                lblInfo.Text = "Błąd.";
                panelInfo.CssClass = "alert alert-danger";
            }
            else
            {
                crtlRejestracja.ClearControls();
                lblInfo.Text = "Witaj " + Global.uzytkownicy[0].Imie +" "+ Global.uzytkownicy[0].Nazwisko;
                panelInfo.CssClass = "alert alert-success";
                Global.uzytkownicy = result.Data;
                Response.Redirect("Default.aspx");
            }
        }
        #endregion
    }
}