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
    public partial class DodajProduktControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControl();
            }
        }
        #region Properties
        public string Marka => txtMarka.Text;
        public string Model => txtModel.Text;
        public string Opis  => txtOpis.Text;
        public string Ilosc => txtIlosc.Text;
        #endregion

        #region Methods 

        private void InitControl()
		{
        }

        #endregion
        public void ClearControls()
        {
            txtMarka.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtOpis.Text = string.Empty;
            txtIlosc.Text = string.Empty;
        }
    }
}