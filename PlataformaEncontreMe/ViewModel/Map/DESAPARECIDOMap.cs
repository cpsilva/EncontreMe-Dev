using PlataformaEncontreMe.Models;
using System.Linq;

namespace PlataformaEncontreMe.ViewModel.Map
{
    public static class DESAPARECIDOMap
    {
        public static DESAPARECIDO Map(this DESAPARECIDOViewModel model)
        {
            var desaparecido = new DESAPARECIDO
            {
                CARACTERISTICAS_DESAPARECIDO = model.CARACTERISTICAS_DESAPARECIDO,
                COD_USUARIO = model.COD_USUARIO,
                CPF_DESAPARECIDO = model.CPF_DESAPARECIDO,
                DATA_DESAPARECIDO = model.DATA_DESAPARECIDO,
                HORARIO_DESAPARECIDO = model.HORARIO_DESAPARECIDO,
                NOME_DESAPARECIDO = model.NOME_DESAPARECIDO,
                RG_DESAPARECIDO = model.RG_DESAPARECIDO,
                FOTO_DESAPARECIDO = model.STR_FOTO_DESAPARECIDO,
                BO_DESAPARECIDO = model.BO_DESAPARECIDO
            };

            //TODO: fazer diff da localização
            foreach (var local in model.Localizacao)
            {
                desaparecido.LOCALIZACAO.Add(new LOCALIZACAO() { LATITUDE_LOCALIZACAO = local.LATITUDE_LOCALIZACAO, LONGITUDE_LOCALIZACAO = local.LONGITUDE_LOCALIZACAO, DESAPARECIDO = desaparecido, COD_LOCALIZACAO = local.COD_LOCALIZACAO });
            }

            return desaparecido;
        }

        public static void MaptoDb(this DESAPARECIDOViewModel model, DESAPARECIDO dESAPARECIDO)
        {

            dESAPARECIDO.CARACTERISTICAS_DESAPARECIDO = model.CARACTERISTICAS_DESAPARECIDO;
            dESAPARECIDO.COD_USUARIO = model.COD_USUARIO;
            dESAPARECIDO.CPF_DESAPARECIDO = model.CPF_DESAPARECIDO;
            dESAPARECIDO.DATA_DESAPARECIDO = model.DATA_DESAPARECIDO;
            dESAPARECIDO.HORARIO_DESAPARECIDO = model.HORARIO_DESAPARECIDO;
            dESAPARECIDO.NOME_DESAPARECIDO = model.NOME_DESAPARECIDO;
            dESAPARECIDO.RG_DESAPARECIDO = model.RG_DESAPARECIDO;
            dESAPARECIDO.FOTO_DESAPARECIDO = model.STR_FOTO_DESAPARECIDO;
            dESAPARECIDO.BO_DESAPARECIDO = model.BO_DESAPARECIDO;

            //TODO: fazer diff da localização
            foreach (var local in model.Localizacao.Where(x => x.COD_LOCALIZACAO == 0))
            {
                dESAPARECIDO.LOCALIZACAO.Add(new LOCALIZACAO() { LATITUDE_LOCALIZACAO = local.LATITUDE_LOCALIZACAO, LONGITUDE_LOCALIZACAO = local.LONGITUDE_LOCALIZACAO, DESAPARECIDO = dESAPARECIDO, COD_LOCALIZACAO = local.COD_LOCALIZACAO });
            }
        }


        public static DESAPARECIDOViewModel MapFromDb(this DESAPARECIDO model)
        {
            var desaparecido = new DESAPARECIDOViewModel
            {
                CARACTERISTICAS_DESAPARECIDO = model.CARACTERISTICAS_DESAPARECIDO,
                COD_USUARIO = model.COD_USUARIO,
                CPF_DESAPARECIDO = model.CPF_DESAPARECIDO,
                DATA_DESAPARECIDO = model.DATA_DESAPARECIDO,
                HORARIO_DESAPARECIDO = model.HORARIO_DESAPARECIDO,
                NOME_DESAPARECIDO = model.NOME_DESAPARECIDO,
                RG_DESAPARECIDO = model.RG_DESAPARECIDO,
                STR_FOTO_DESAPARECIDO = model.FOTO_DESAPARECIDO,
                BO_DESAPARECIDO = model.BO_DESAPARECIDO,
                COD_DESAPARECIDO = model.COD_DESAPARECIDO

            };

            desaparecido.Localizacao.AddRange(model.LOCALIZACAO.Select(local => new LOCALIZACAOViewModel() { LATITUDE_LOCALIZACAO = local.LATITUDE_LOCALIZACAO, LONGITUDE_LOCALIZACAO = local.LONGITUDE_LOCALIZACAO, COD_LOCALIZACAO = local.COD_LOCALIZACAO }));

            return desaparecido;
        }
    }
}