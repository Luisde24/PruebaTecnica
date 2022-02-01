using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebApi.Models
{
    public class LoginDTO
    {
        [Required]
        public string Nombre  { get; set; }
        [Required]
        public string contraseña { get; set; }
    }
}