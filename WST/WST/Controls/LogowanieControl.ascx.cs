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
    public partial class LogowanieControl : System.Web.UI.UserControl
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
        #endregion
        #region Methods 

        #endregion
        public void ClearControls()
        {
            txtEmail.Text = string.Empty;
            txtHaslo.Text = string.Empty;
        }
    }
}