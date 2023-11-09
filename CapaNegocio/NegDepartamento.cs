using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegDepartamento
    {
        AdministradorDepartamento DatosObjDepartamento = new AdministradorDepartamento();

        public int abmDepartamento(string accion, Departamento objDepartamento)
        {
            return DatosObjDepartamento.abmDepartamento(accion, objDepartamento);
        }

        public DataSet listaDepartamento(string cual)
        {
            return DatosObjDepartamento.listaDepartamento(cual);
        }
    }
}
