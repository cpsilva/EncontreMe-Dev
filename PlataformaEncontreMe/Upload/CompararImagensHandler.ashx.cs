using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Newtonsoft.Json;
using PlataformaEncontreMe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlataformaEncontreMe.Upload
{
    /// <summary>
    /// Summary description for CompararImagensHandler
    /// </summary>
    public class CompararImagensHandler : HttpTaskAsyncHandler
    {

        public static string url = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0";
        public static string _key = "65da489cd25d450daea1f72019cc4bdb";
        //04fc6526c17b45699cda164a35c9c91e

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    var id = Convert.ToInt32(context.Request.QueryString["id"]);

                    HttpFileCollection files = context.Request.Files;
                    HttpPostedFile file = files[0];
                    var result = await DetectarFace(file, id);
                    context.Response.ContentType = "application/json";
                    context.Response.Write(JsonConvert.SerializeObject(new { resultado = result }));
                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = "Erro ao comparar imagens.";
            }
        }


        private async Task<bool> DetectarFace(HttpPostedFile file, int id)
        {
            IFaceServiceClient faceClient = new FaceServiceClient(_key, url);
            Face[] faces = null;
            Face[] faces2 = null;

            using (ENCONTREMEEntities db = new ENCONTREMEEntities())
            {

                var desaperacido = db.DESAPARECIDO.Find(id);

                if (desaperacido != null)
                {
                    using (Stream stream = new MemoryStream(Convert.FromBase64String(desaperacido.FOTO_DESAPARECIDO.Split(',')[1])))
                    {
                        faces = await faceClient.DetectAsync(stream);
                    }
                    using (Stream stream2 = file.InputStream)
                    {
                        faces2 = await faceClient.DetectAsync(stream2);
                    }
                    if (faces != null && faces.Length > 0 && faces2 != null && faces2.Length > 0)
                    {
                        var retorno = await faceClient.VerifyAsync(faces[0].FaceId, faces2[0].FaceId);
                        if (retorno.IsIdentical)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}