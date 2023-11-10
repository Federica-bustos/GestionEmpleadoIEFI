using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.OleDb;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosConexion
    {
        protected SqlConnection conexion;
        protected string cadenaConexion = @"Data Source=DESKTOP-KIDBI04\SQLEXPRESS;Initial Catalog=GestionEmpleados;Integrated Security=True";


        //public OleDbConnection conexion;
        //public string cadenaConexion =

        // @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Vs2022\FormularioEmpleados\GestionEmpleo1.accdb";

        //@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Vs2022\FormularioEmpleados\GestionEmpleo1.accdb";

        //@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 
        //C:\Users\Usuario\Desktop\ITSC\2_AÑO\Programacion\GestionEmpleo1.accdb";


        //@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=
        // C:\Users\Usuario\Desktop\ITSC\2 AÑO\Programacion\GestionEmpleo1.accdb";



        public DatosConexion()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void Abrirconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State ==
                ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
        }

        public void Cerrarconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }
    }
}
