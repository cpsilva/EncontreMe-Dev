using System;
using System.Collections.Generic;

namespace PlataformaEncontreMe.ViewModel
{
    public class DESAPARECIDOViewModel
    {

        public DESAPARECIDOViewModel()
        {
            Localizacao = new List<LOCALIZACAOViewModel>();
        }
        public int COD_DESAPARECIDO { get; set; }
        public string NOME_DESAPARECIDO { get; set; }
        public string RG_DESAPARECIDO { get; set; }
        public string CPF_DESAPARECIDO { get; set; }
        public string BO_DESAPARECIDO { get; set; }
        public Nullable<System.TimeSpan> HORARIO_DESAPARECIDO { get; set; }
        public System.DateTime DATA_DESAPARECIDO { get; set; }
        public string CARACTERISTICAS_DESAPARECIDO { get; set; }
        public string STR_FOTO_DESAPARECIDO { get; set; }
        public Nullable<int> COD_USUARIO { get; set; }


        public List<LOCALIZACAOViewModel> Localizacao { get; set; }

    }
}