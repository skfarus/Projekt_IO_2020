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
    public partial class DodajProdukt : System.Web.UI.Page
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
        private ProduktyDTO GetProduktDTO()
        {
            return new ProduktyDTO()
            {
                Marka = crtlDodajProdukt.Marka,
                Model = crtlDodajProdukt.Model,
                Opis = crtlDodajProdukt.Opis,
                Ilosc = crtlDodajProdukt.Model
            };
        }
        #endregion

        #region Events
        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            var api = new WSTApi();
            var result = api.AddProdukt(GetProduktDTO());

            if(!result.Success)
            {
                Trace.Warn(result.Errors);
                lblInfo.Text = "Błąd";
                panelInfo.CssClass = "alert alert-danger";
            }
            else
            {
                crtlDodajProdukt.ClearControls();
                lblInfo.Text = "Sukces";
                panelInfo.CssClass = "alert alert-success";
            }
        }
        #endregion
    }
}