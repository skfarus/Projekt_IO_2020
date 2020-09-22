using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WST.BusinessLogic.ModelDTO;
using WST.Domain.Domain;

namespace WST
{
    public class Global : System.Web.HttpApplication
    {
        public static List<UzytkownicyDTO> uzytkownicy;
        public static string Id_produktu_rezerwacja;
        protected void Application_Start(object sender, EventArgs e)
        {
        }
    }
}