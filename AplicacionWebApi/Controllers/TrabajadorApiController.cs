using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;


namespace AplicacionWebApi.Controllers
{
    [Authorize]
    public class TrabajadorApiController : ApiController
    {
        #region CRUD API WEB

        #region Cadena de conexión
        /// <summary>
        /// La cadena de conexión es para conectarse a la base de datos Examen3Herramientas3 y acceder a la info de esa base de Datos
        /// </summary>
        #endregion
        public SqlConnection conexion = new SqlConnection("Server = LUIS-DAVID; Database =ProyectMVC; Integrated Security = True;");
        #region Listar tabla Trabajadores
        // GET api/Trabajador
        /// <summary>
        /// Lista la información contenida en la tabla Trabajadores
        /// </summary>
        /// <returns> Devuelve el DataSet con todos los registros de la tabla Trabajadores</returns>
        #endregion
        public DataSet Get()
        {
          
                var consulta = "SELECT * FROM tblTrabajadores";
                var dataAdapter = new SqlDataAdapter(consulta, conexion);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "tblTrabajadores");
                return dataSet;

           
        }
       
        #region Consultar  un trabajador Segun ID
        // GET api/Trabajador
        /// <summary>
        /// Consultar la información de un trabajador segun un campo Id  especifico 
        /// </summary>
        /// <param name="id">Clave primaria de la tabla trabajadores</param>
        /// <returns> Devuelve el DataSet con el  registro de un trabajador</returns>
        #endregion
        public DataSet Get(int id)
        {
            var consulta = "SELECT * FROM tblTrabajadores WHERE TrabajadorId = " + id;
            var dataAdapter = new SqlDataAdapter(consulta, conexion);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "tblTrabajadores");
            return dataSet;
        }
        // POST api/controlador
        #region Agregar un nuevo empleado
        /// <summary>
        /// Crear un nuevo registro a la tabla Trabajador
        /// </summary>
        /// <param name="tipoIdentifiacion"> Tipo de Identificación del nuevo del trabajador</param>
        /// <param name="identificacion"> Número deIdentificación del nuevo del trabajador</param>
        /// <param name="primerNombre">Primer Nombre  del nuevo del trabajador</param>
        /// <param name="segundoNombre">Segundo Nombre del nuevo del trabajadorl</param>
        /// <param name="primerApellido"> Primer Apellido del nuevo del trabajador/param>
        /// <param name="segundoApellido"> Segundo Apellido del nuevo del trabajador/param>
        /// <param name="fechaNacimiento"> Decha de Nacimiento del nuevo del trabajador/param>
        /// <param name="edad"> Edad del nuevo del trabajador/param>
        #endregion
        public void Post( int tipoIdentifiacion, string identificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string fechaNacimiento, int edad)
        {
            var consulta = $"INSERT INTO tblTrabajadores VALUES('{tipoIdentifiacion}','{identificacion}','{primerNombre}','{segundoNombre}','{primerApellido}','{segundoApellido}','{fechaNacimiento}', '{edad}')";
            var comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        // PUT api/controlador/5
        #region Actualizar un equipo de futbol segun un ID
        /// <summary>
        /// Actualiza un registro segun un campo Id creado de la tabla Trabajadores
        /// </summary>
        /// <param name="trabajadorId"> ID del trabajador a actualizar</param>
        /// <param name="tipoIdentifiacion"> Tipo de Identificación del nuevo del trabajador</param>
        /// <param name="identificacion"> Número deIdentificación del nuevo del trabajador</param>
        /// <param name="primerNombre">Primer Nombre  del nuevo del trabajador</param>
        /// <param name="segundoNombre">Segundo Nombre del nuevo del trabajadorl</param>
        /// <param name="primerApellido"> Primer Apellido del nuevo del trabajador/param>
        /// <param name="segundoApellido"> Segundo Apellido del nuevo del trabajador/param>
        /// <param name="fechaNacimiento"> Decha de Nacimiento del nuevo del trabajador/param>
        /// <param name="edad"> Edad del nuevo del trabajador/param>
        /// <returns>Devuelve el registro actualizado. Si retorna "1" es porque se actualizarón los datos, si es "0" no existe el trabajador a actualizar</returns>
        #endregion
        public int Put(int trabajadorId, int tipoIdentifiacion, string identificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string fechaNacimiento, int edad)
        {
            var consulta = $"UPDATE tblTrabajadores SET  TipoIdentificacionId='{tipoIdentifiacion}', " +
               $"Identiificacion='{identificacion}', PrimerNombre='{primerNombre}',SegundoNombre='{segundoNombre}'," +
               $"PrimerApellido= '{primerApellido}', SegundoApellido='{segundoApellido}',FechaNacimiento='{fechaNacimiento}',Edad='{edad}'" + 
               $"WHERE TrabajadorId = {trabajadorId}";
            var comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            var registrosActualizados = comando.ExecuteNonQuery();
            conexion.Close();
            return registrosActualizados;
        }

        // DELETE api/controlador/5
        #region Eliminar un Trabajador segun un ID
        /// <summary>
        /// Eliminar un registros según un campo Id especifico. 
        /// </summary>
        /// <param name="id">Clave primaria del registro que se desea borrar </param>
        /// <returns>Devuelve el registro eliminado. Si retorna "1" es por que se borraron los datos, si es "0" no existe el equipo de futbol a borrar</returns>
        #endregion
        public int Delete(int id)
        {
            var consulta = string.Format("DELETE tblTrabajadores where TrabajadorId = {0}", id);
            var comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            var registrosEliminados = comando.ExecuteNonQuery();
            conexion.Close();
            return registrosEliminados;
        }
        #endregion

    }

}
