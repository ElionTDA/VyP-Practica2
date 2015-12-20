using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace GUI
{
    public partial class Register : System.Web.UI.Page
    {
        private static DBPruebas dbpruebas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dbpruebas"] == null)
                Session["dbpruebas"] = DBPruebas.getInstance();
            dbpruebas = (DBPruebas)Session["dbpruebas"];
        }

        protected void RegisteringButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NicknameTB.Text) || string.IsNullOrWhiteSpace(ContraseñaTB.Text)
                || string.IsNullOrWhiteSpace(NombreTB.Text) || string.IsNullOrWhiteSpace(Apellido1TB.Text)
                || string.IsNullOrWhiteSpace(Apellido2TB.Text) || string.IsNullOrWhiteSpace(DiaTB.Text)
                || string.IsNullOrWhiteSpace(MesTB.Text) || string.IsNullOrWhiteSpace(AñoTB.Text))
            {
                Label1.Text = "Rellene todos los campos, por favor.";
                return;
            }

            DateTime fechaNacimiento = new DateTime(Int16.Parse(AñoTB.Text), Int16.Parse(MesTB.Text), Int16.Parse(DiaTB.Text));
            String contraseñaHasheada = Utilidad.cifrar(ContraseñaTB.Text);
            Logica.Usuario usuario = null;
            try
            {
                usuario = new Logica.Usuario(NicknameTB.Text, contraseñaHasheada, NombreTB.Text, Apellido1TB.Text, Apellido2TB.Text, fechaNacimiento);
            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
                return;
            }
            //Establecemos el nick del usuario
            Session["nick"] = usuario.Nick;
            Response.Redirect("Usuario.aspx");
        }
    }
}