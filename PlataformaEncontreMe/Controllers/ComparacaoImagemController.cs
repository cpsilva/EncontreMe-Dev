using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using PlataformaEncontreMe.Models;
using PlataformaEncontreMe.ViewModel;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using System.Configuration;


namespace PlataformaEncontreMe.Controllers
{
    public class ComparacaoImagemController : ApiController
    {
        public static string url = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0";
        //public static string url = "https://brazilsouth.api.cognitive.microsoft.com/face/v1.0";
        public static string _key = ConfigurationManager.AppSettings["chaveAzure"];
        public static double toleranciaReconhecimentoImagem = Convert.ToDouble(ConfigurationManager.AppSettings["toleranciaReconhecimentoImagem"]) / 100.00d;


        [Route("desaparecido/compararimagem")]
        public async Task<IHttpActionResult> CompararImagem([FromBody] ComparacaoRequest request)
        {
            var resultado = false;
            using (ENCONTREMEEntities db = new ENCONTREMEEntities())
            {
                var desaperacido = db.DESAPARECIDO.Find(request.Id);
                resultado = await DetectarFace(request, desaperacido);
            }
            return Ok(new { resultado = resultado });
        }

        private async static Task<bool> DetectarFace(ComparacaoRequest request, DESAPARECIDO desaperacido)
        {
            IFaceServiceClient faceClient = new FaceServiceClient(_key, url);
            Face[] faces = null;
            Face[] faces2 = null;

            if (desaperacido != null)
            {
                var imgBytes1 = Convert.FromBase64String(desaperacido.FOTO_DESAPARECIDO.Split(',')[1]);
                var imgBytes2 = Convert.FromBase64String(request.ImgBody.Split(',')[1]);

                using (Stream stream = new MemoryStream(imgBytes1, 0, imgBytes1.Length))
                {
                    faces = await faceClient.DetectAsync(stream);
                }
                using (Stream stream2 = new MemoryStream(imgBytes2, 0, imgBytes2.Length))
                {
                    faces2 = await faceClient.DetectAsync(stream2);
                }
                if (faces != null && faces.Length > 0 && faces2 != null && faces2.Length > 0)
                {
                    var retorno = await faceClient.VerifyAsync(faces[0].FaceId, faces2[0].FaceId);
                    if (retorno.IsIdentical || retorno.Confidence >= toleranciaReconhecimentoImagem)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
