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
            if (!IsPostBack)
            {
                string username = Session["Username"] as string;
                if (username != null)
                {
                    CargarArchivos(username);
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploader.HasFile)
            {
                string username = Session["Username"] as string;
                if (!string.IsNullOrEmpty(username))
                {
                    string folderPath = Server.MapPath($"~/Archivos/{username}");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string filePath = Path.Combine(folderPath, fileUploader.FileName);
                    fileUploader.SaveAs(filePath);
                    CargarArchivos(username);
                }
            }
        }

        private void CargarArchivos(string username)
        {
            string folderPath = Server.MapPath($"~/Archivos/{username}");
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath).Select(f => new
                {
                    Name = Path.GetFileName(f),
                    Path = f
                }).ToList();

                gvArchivos.DataSource = files;
                gvArchivos.DataBind();
            }
        }

        protected void lnkDownload_Command(object sender, CommandEventArgs e)
        {
            string filePath = e.CommandArgument.ToString();
            string fileName = Path.GetFileName(filePath);
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName}");
            Response.TransmitFile(filePath);
            Response.End();
        }

    }
}