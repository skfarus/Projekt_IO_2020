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
    public partial class DodajRezControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControl();
            }
        }
        #region Properties
        public string Ilosc => txtIlosc.Text;
        public DateTime Data_od => txtData_od.SelectedDate;
        public string Ilosc_dni => txtIlosc_dni.Text;
        #endregion
        #region Methods 


        private void InitControl()
		{
        }

        #endregion
        public void ClearControls()
        {
            txtIlosc.Text = string.Empty;
            txtData_od = null;
            txtIlosc_dni.Text = string.Empty;
        }
    }
}