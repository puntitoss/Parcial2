using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial2
{
    public partial class GestionArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string username = this.Session["Username"] as string;
                if (username != null)
                {
                    this.CargarArchivos(username);
                }
                else
                {
                    this.Response.Redirect("Registro.aspx");
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.fileUploader.HasFile)
            {
                string username = this.Session["Username"] as string;
                if (!string.IsNullOrEmpty(username))
                {
                    string folderPath = this.Server.MapPath($"~/Archivos/{username}");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string filePath = Path.Combine(folderPath, this.fileUploader.FileName);
                    this.fileUploader.SaveAs(filePath);
                    this.CargarArchivos(username);
                }
            }
        }

        private void CargarArchivos(string username)
        {
            string folderPath = this.Server.MapPath($"~/Archivos/{username}");
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath).Select(f => new
                {
                    Name = Path.GetFileName(f),
                    Path = f
                }).ToList();

                this.gvArchivos.DataSource = files;
                this.gvArchivos.DataBind();
            }
        }

        protected void lnkDownload_Command(object sender, CommandEventArgs e)
        {
            string filePath = e.CommandArgument.ToString();
            string fileName = Path.GetFileName(filePath);
            this.Response.ContentType = "application/octet-stream";
            this.Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName}");
            this.Response.TransmitFile(filePath);
            this.Response.End();
        }
    }
}