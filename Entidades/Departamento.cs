using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Departamento
    {
        #region Atributos
        public int Id;
        public string NomDepartamento { get; set; }
        #endregion

        #region Propiedades
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string departamento
        {
            get { return NomDepartamento; }
            set { NomDepartamento = value; }
        }

        #endregion

        #region Construccion
        public Departamento(int id, string nomdepartamento)
        {
            Id = id;
            NomDepartamento = departamento;

        }

        #endregion
    }
}
