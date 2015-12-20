using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nick"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            UsuarioID.Text = "Hola, " + Session["nick"].ToString();
        }

        protected void LogoutBTN_Click(object sender, EventArgs e)
        {
            Session["nick"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}