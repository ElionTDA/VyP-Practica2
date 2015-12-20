using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace GUI
{
    public partial class Login : System.Web.UI.Page
    {
        private static DBPruebas dbpruebas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dbpruebas"] == null)
                Session["dbpruebas"] = DBPruebas.getInstance();
            dbpruebas = (DBPruebas)Session["dbpruebas"];
        }

        protected void Logging_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NickTb.Text) || string.IsNullOrWhiteSpace(PassTb.Text))
            {
                Label1.Text = "Introduzca apodo y contraseña";
                return;
            }
            Logica.Usuario usuario = dbpruebas.loginUsuario(NickTb.Text, Utilidad.cifrar(PassTb.Text));
            if (usuario != null)
            {
                //Establecemos el nick del usuario
                Session["nick"] = usuario.Nick;
                Response.Redirect("Usuario.aspx");
                return;
            }
            Label1.Text = "Login no exitoso! ¿Pueden el nombre y/o contraseña ser erróneos?";
        }
    }
}