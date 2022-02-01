using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AplicacionWebApi.Controllers
{
    [Authorize]
    public class ContratoApiController : ApiController
    {
        #region Cadena de conexión
        /// <summary>
        /// La cadena de conexión es para conectarse a la base de datos Examen3Herramientas3 y acceder a la info de esa base de Datos
        /// </summary>
        #endregion
        public SqlConnection conexion = new SqlConnection("Server = LUIS-DAVID; Database =ProyectMVC; Integrated Security = True;");


        #region Listar tabla contratos
        //   GET: api/Contrato
        /// <summary>
        /// Lista la información contenida en la tabla que hace referencia a los Contratos
        /// </summary>
        /// <returns> Devuelve el DataSet con todos los registros de la tabla Contratos</returns>
        #endregion
        public DataSet Get()
        {
            var consulta = "SELECT * FROM tblContrato";
            var dataAdapter = new SqlDataAdapter(consulta, conexion);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "tblContrato");
            return dataSet;
        }

        #region Consultar  un contrato Segun ID
        // GET api/Contrato
        /// <summary>
        /// Consultar la información de un contrato segun un campo Id  especifico 
        /// </summary>
        /// <param name="id">Clave primaria de la tabla contratos</param>
        /// <returns> Devuelve el DataSet con el  registro de un contrato</returns>
        #endregion
        public DataSet Get(int id)
        {
            var consulta = "SELECT * FROM tblContrato WHERE ContratoId = " + id;
            var dataAdapter = new SqlDataAdapter(consulta, conexion);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "tblContrato");
            return dataSet;
        }

        // POST: api/Contrato
        #region Agregar un nuevo contrato
        /// <summary>
        /// Crear un nuevo registro a la tabla contratos
        /// </summary>
        /// <param name="NombreEntidad"> Nombre de la empresa del nuevo contrato</param>
        /// <param name="TrabajadorVinculado"> Nombre del empleado del nuevo contrato</param>
        /// <param name="FechaInicio">Fecha de inicio del nuevo contrato</param>
        /// <param name="FechaFin">Fecha de terminacion del nuevo contrato</param>
        /// <param name="TrabajadorId">ID del Trabajador que var ser uso del nuevo contrato/param>

        #endregion
        public void Post(string NombreEntidad, int NumeroContrato, string TrabajadorVinculado, string FechaInicio, string FechaFin, int TrabajadorId)
        {
            var consulta = $"INSERT INTO tblContrato VALUES('{NombreEntidad}','{NumeroContrato}', '{TrabajadorVinculado}','{FechaInicio}','{FechaFin}','{TrabajadorId}')";
            var comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        // PUT: api/Contrato/5
        #region Actualizar un contrato segun un ID
        /// <summary>
        /// Actualiza un registro segun un campo Id creado de la tabla de contratos
        /// </summary>
        ///  <param name="ContratoId"> ID del contrato a actualizar </param>
        /// <param name="NombreEntidad"> Nombre de la empresa del nuevo contrato</param>
        /// <param name="TrabajadorVinculado"> Nombre del empleado del nuevo contrato</param>
        /// <param name="FechaInicio">Fecha de inicio del nuevo contrato</param>
        /// <param name="FechaFin">Fecha de terminacion del nuevo contrato</param>
        /// <param name="TrabajadorId">ID del Trabajador que var ser uso del nuevo contrato/param>
        /// <returns>Devuelve el registro actualizado. Si retorna "1" es porque se actualizarón los datos, si es "0" no existe el trabajador a actualizar</returns>
        #endregion
        public int Put(int ContratoId, string NombreEntidad, int NumeroContrato , string TrabajadorVinculado, string FechaInicio, string FechaFin, int TrabajadorId)
        {
            var consulta = $"UPDATE tblContrato SET  NombreEntidad='{NombreEntidad}',  NumeroContrato ='{NumeroContrato}',"+
            $"TrabajadorVinculado='{TrabajadorVinculado}', FechaInicio='{FechaInicio}',FechaFin='{FechaFin}'," +
                       $"TrabajadorId= '{TrabajadorId}'" +
                       $"WHERE ContratoId = {ContratoId}";
            var comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            var registrosActualizados = comando.ExecuteNonQuery();
            conexion.Close();
            return registrosActualizados;
        }

        // DELETE: api/Contrato/5
        #region Eliminar un contrato segun un ID
        /// <summary>
        /// Eliminar un registros según un campo Id especifico. 
        /// </summary>
        /// <param name="id">Clave primaria del registro que se desea borrar </param>
        /// <returns>Devuelve el registro eliminado. Si retorna "1" es por que se borraron los datos, si es "0" no existe el equipo de futbol a borrar</returns>
        #endregion
        public int Delete(int id)
        {
            var consulta = string.Format("DELETE tblContrato where ContratoId = {0}", id);
            var comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            var registrosEliminados = comando.ExecuteNonQuery();
            conexion.Close();
            return registrosEliminados;

        }
    }
}
