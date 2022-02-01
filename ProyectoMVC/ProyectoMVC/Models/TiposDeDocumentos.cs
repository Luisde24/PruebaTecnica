using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMVC.Models
{
    [Table("tblTiposDeDocumentos")]
    public class TiposDeDocumentos
    {
        [Key]
        public int TipoIdentificacionId { get; set; }
        [Required]
        [StringLength(40)]
        [Index("IX_Descripcion", IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }
}