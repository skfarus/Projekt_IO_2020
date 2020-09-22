using WST.BusinessLogic.Api;
using WST.BusinessLogic.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WST.Controls
{
    public partial class RejestracjaControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //InitControl();
            }
        }
        #region Properties
        public string Email => txtEmail.Text;
        public string Haslo => txtHaslo.Text;
        public string Imie => txtImie.Text;
        public string Nazwisko => txtNazwisko.Text;
        public string Adres => txtAdres.Text;
        public string Telefon => txtTelefon.Text;
        #endregion
        #region Methods 

        #endregion
        public void ClearControls()
        {
            txtEmail.Text = string.Empty;
            txtHaslo.Text = string.Empty;
            txtImie.Text = string.Empty;
            txtNazwisko.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtTelefon.Text = string.Empty;
        }
    }
}