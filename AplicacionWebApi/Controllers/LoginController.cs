using AplicacionWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace AplicacionWebApi.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Este metodo se encarga de realizar la autorización
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>

        [HttpPost]
        public IHttpActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool credencialesValida = loginDTO.contraseña == "mLemouw30*";
            if(credencialesValida = true)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.Nombre);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }

        }

    }
}
