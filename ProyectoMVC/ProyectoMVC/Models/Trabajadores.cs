using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMVC.Models
{
    [Table("tblTrabajadores")]
    public class Trabajadores
    {
        [Key]
        public int TrabajadorId { get; set; }
        //Clave foranea 
        public int TipoIdentificacionId { get; set; }
        //propiedad de navegacion 
        public virtual TiposDeDocumentos TipoIdentificacion { get; set; }
        [Display(Name = "Identiificación"  )]
        public int Identiificacion { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Required]
        [StringLength(25)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required]
        [StringLength(25)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Required]
        [StringLength(25)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "La fecha es Obligatoria")]
        public DateTime FechaNacimiento { get; set; }
       [Display(Name = "Edad")]
        public int? Edad { get; set; }
    }
}