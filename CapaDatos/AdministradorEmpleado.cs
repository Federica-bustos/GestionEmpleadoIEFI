using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Entidades;


namespace CapaDatos
{
    public class AdministradorEmpleado : DatosConexion
    {
        public int abmEmpleado(string accion, Empleado objEmpleado)
        {

            int resultado = -1; // controlo si se realizo la operacion con exito
            string orden = string.Empty; // Se cargan consultas al SQL

            if (accion == "Alta")//Empleado Nuevo

                orden = $"insert into Empleado values " +
                    $"('{objEmpleado.nombre}'," +
                    $"'{objEmpleado.primerapellido}'" +
                    $",'{objEmpleado.segundoapellido}'" +
                    $",'{objEmpleado.departamento}'" +
                    $",'{objEmpleado.correo}'" +
                    $",'{objEmpleado.fechanacimiento}'" +
                    $",'{objEmpleado.dni}')";

            //Set: De que atributo modificar
            //where: lo que no se puede modificar
            if (accion == "Modificar")
                orden = $"update Empleado set NombreApellido = '{objEmpleado.nombre}' " +
                    $"where DNI = {objEmpleado.dni}; update Empleado set Apellido = '{objEmpleado.primerapellido}' " +
                    $"where DNI = {objEmpleado.dni}; update Empleado set Correo = '{ objEmpleado.correo}' " +
                    $"where DNI = {objEmpleado.dni}; update Empleado set Departamento = '{objEmpleado.departamento}' " +
                    $"where DNI = {objEmpleado.dni}; update Empleado set FechaNacimiento = '{objEmpleado.fechanacimiento}'";

            if (accion == "Borrar")
                orden = $"delete from Alumno where DNI = {objEmpleado.dni}";

            OleDbCommand cmd = new OleDbCommand (orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objEmpleado} ", e);
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