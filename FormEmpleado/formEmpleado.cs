using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace FormEmpleado
{
    public partial class formEmpleado : Form
    {
        Empleado NuevoEmpleado;
        NegEmpleado objNegEmpleado = new NegEmpleado();
        bool nuevo = true;
        int fila;

        public formEmpleado()
        {
            InitializeComponent();
            //tabla empleado
            dgvEmpleado.ColumnCount = 7;
            dgvEmpleado.Columns[0].HeaderText = "Nombre";
            dgvEmpleado.Columns[1].HeaderText = "Primer Apellido";
            dgvEmpleado.Columns[2].HeaderText = "Segundo Apellido";
            dgvEmpleado.Columns[3].HeaderText = "DNI";
            dgvEmpleado.Columns[4].HeaderText = "Email";
            dgvEmpleado.Columns[5].HeaderText = "Departamento";
            dgvEmpleado.Columns[6].HeaderText = "Fecha Nacimiento";

            //tabla departamento
            dgvDepa.ColumnCount = 2;
            dgvDepa.Columns[0].HeaderText = "Id";
            dgvDepa.Columns[1].HeaderText = "Nombre Departamento";

            //Cargar datos a las tablas

            //LlenarDGVEmpleado();
            LlenarDGVDepartamento();

        }

        //private void LlenarDGVEmpleado()
        //{
        //    dgvEmpleado.Rows.Clear();

        //    DataSet ds = new DataSet();
        //    ds = objNegEmpleado.listaEmpleado("Todos");

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            dgvEmpleado.Rows.Add(dr[0].ToString(), dr[1], dr[2].ToString(), dr[3], dr[4].ToString(),
        //                dr[5].ToString(), dr[6].ToString());
        //        }
        //    }

        //    else
        //        MessageBox.Show("No hay empleados cargado en el sistema");
        //}

        private void LlenarDGVDepartamento()
        {
            dgvEmpleado.Rows.Clear();

            DataSet ds = new DataSet();
            ds = objNegEmpleado.listaEmpleado("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvEmpleado.Rows.Add(dr[0].ToString(), dr[1], dr[2].ToString(), dr[3], dr[4].ToString(),
                        dr[5].ToString(), dr[6].ToString());
                }
            }

            else
                MessageBox.Show("No hay empleados cargado en el sistema");
        }
        

    }
}

