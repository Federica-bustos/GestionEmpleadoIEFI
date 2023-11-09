using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Entidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AdministradorDepartamento : DatosConexion
    {
        public int abmDepartamento(string accion, Departamento objDepartamento)
        {

            int resultado = -1; // controlo si se realizo la operacion con exito
            string orden = string.Empty; // Se cargan consultas al SQL

            if (accion == "Alta")//Departamento Nuevo

                orden = $"insert into Departamento values " +
                    $"('{objDepartamento.id}'," +
                    $"'{objDepartamento.NomDepartamento}')";


            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objDepartamento} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
    }

}