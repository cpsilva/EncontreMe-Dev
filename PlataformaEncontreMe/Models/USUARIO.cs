//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlataformaEncontreMe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.DESAPARECIDO = new HashSet<DESAPARECIDO>();
        }
    
        public int COD_USUARIO { get; set; }
        public string NOME_USUARIO { get; set; }
        public string CPF_USUARIO { get; set; }
        public string CEP_USUARIO { get; set; }
        public string ENDERECO_USUARIO { get; set; }
        public string CIDADE_USUARIO { get; set; }
        public string ESTADO_USUARIO { get; set; }
        public byte[] FOTO_USUARIO { get; set; }
        public string PARENTESCO_USUARIO { get; set; }
        public string EMAIL_USUARIO { get; set; }
        public string SENHA_USUARIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DESAPARECIDO> DESAPARECIDO { get; set; }
    }
}