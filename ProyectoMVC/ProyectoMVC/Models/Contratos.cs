using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoMVC.Models
{
    [Table("tblContrato")]
    public class Contratos
    {
        [Key]
        public int ContratoId { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Nombre de la empresa")]
        public string NombreEntidad { get; set; }
        [Display(Name = "Numero de Contrato")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite un número")]
        [StringLength(50)]
        public string NumeroContrato { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Nombre del trabajador")]
        public string TrabajadorVinculado { get; set; }
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date, ErrorMessage = "La fecha Inicial es Obligatoria")]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha de Final")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public int TrabajadorId { get; set; }
        public virtual Trabajadores Trabajador { get; set; }
    }
}