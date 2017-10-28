using System;
using System.IO;
using System.Web;

namespace PlataformaEncontreMe.Upload
{
    /// <summary>
    /// Descrição resumida de UploadPDF
    /// </summary>
    public class UploadPDF : IHttpHandler
    {
        /// <summary>
        /// Pega arquivo do HttpContext e salva na pasta RNC
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {

                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;

                    //Uppar arquivo
                    for (int i = 0; i < files.Count; i++)
                    {
                        if (!Directory.Exists(context.Server.MapPath("/Upload/PDF")))
                        {
                            Directory.CreateDirectory(context.Server.MapPath("/Upload/PDF"));
                        }

                        HttpPostedFile file = files[i];
                        string fname = context.Server.MapPath("/Upload/PDF/" + file.FileName);
                        file.SaveAs(fname);
                    }

                    //Retorno
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("");

                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = "Erro ao Gerar PDF.";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}