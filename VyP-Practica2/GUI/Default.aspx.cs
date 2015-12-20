using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace GUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dbpruebas"] == null)
                Session["dbpruebas"] = DBPruebas.getInstance();
            if (Session["nick"] != null)
                Bienvenida.Text = "Hola, " + Session["nick"].ToString();
        }

        protected void Login_Button(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Register_Button(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}