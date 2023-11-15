using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        #region Atributos
        public int Id;
        public string Nombre;
        public string PrimerApellido;
        public string SegundoApellido;
        public string Departamento;
        public string Correo;
        public DateTime Fechanacimiento;
        //public byte[] FotoEmpleado;
        public int DNI;
        #endregion

        #region Propiedades
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string primerapellido
        {
            get { return PrimerApellido; }
            set { PrimerApellido = value; }
        }

        public string segundoapellido
        {
            get { return SegundoApellido; }
            set { SegundoApellido = value; }
        }

        public string departamento
        {
            get { return Departamento; }
            set { Departamento = value; }
        }

        public string correo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        public DateTime fechanacimiento

        {
            get { return Fechanacimiento; }
            set { fechanacimiento = value; }
        }

        public int dni
        {
            get { return DNI; }
            set { DNI = value; }
        }

        #endregion

        #region Constructor
        public Empleado()
        { }
        public Empleado(int id, string nombreempleado, string primerapellido, string segundoapellido, string departamento, string correo, DateTime fechanacimiento, int dni)
        {
            Nombre = nombreempleado;
            PrimerApellido = primerapellido;
            SegundoApellido = segundoapellido;
            Departamento = departamento;
            Correo = correo;
            Fechanacimiento = fechanacimiento;
            DNI = dni;


        }
        #endregion
    }
}
