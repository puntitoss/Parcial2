using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial2
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                // Obtener los valores de los campos (y eliminar espacio en caso de que contenga)
                string username = this.txtUsername.Text.Trim();
                string password = this.txtPassword.Text.Trim();

                // Guardar el nombre de usuario en una variable de sesión
                this.Session["Username"] = username;

                // Crear una cookie de sesión para la contraseña
                HttpCookie passwordCookie = new HttpCookie("Password", password);
                this.Response.Cookies.Add(passwordCookie);

                // Redirigir a la página de Gestión de Archivos
                this.Response.Redirect("GestionArchivos.aspx");
            }
        }

    }
}