using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using CapaDatos;
using System.Data;
using System.Data.OleDb;


namespace CapaNegocio
{
    public class NegEmpleado
    {
        AdministradorEmpleado DatosObjEmpleado = new AdministradorEmpleado();
        //comunica la capa de presentacion con la capa de datps

        public int abmEmpleado(string accion,Empleado objEmpleado)
        {
            return DatosObjEmpleado.abmEmpleado(accion, objEmpleado);
        }

        public DataSet listaEmpleado(string cual) //(cual)
        {
            return DatosObjEmpleado.listaEmpleado (cual);
        }
    }
}
