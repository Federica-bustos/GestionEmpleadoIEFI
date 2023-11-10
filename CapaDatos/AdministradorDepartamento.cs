using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.OleDb;
using Entidades;
using System.Data.SqlClient;
using System.Data;

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

            if (accion == "Modificar")
                orden = $"update Departamento set NombreApellido = '{objDepartamento.NomDepartamento}' ";

            if (accion == "Borrar")
                orden = $"delete from Departamento where idDepartamento = {objDepartamento.id}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
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

        public DataSet listaDepartamento(string id) // para uno o todos los datos segun el codigo
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from Departamento where ID = {int.Parse(id)};";
            else
                orden = "select * from Departamento;";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                  
                
            }
            catch (Exception e)
            {
                
                throw new Exception("Error al listar Departamento", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }
    }
}