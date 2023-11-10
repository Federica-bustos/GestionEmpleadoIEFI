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
        Empleado EmpleadoExistente;
        NegEmpleado objNegEmpleado = new NegEmpleado();
        NegDepartamento objNegDepartamento = new NegDepartamento();
        bool nuevo = true;
        int fila;

        public Departamento objEntDepartamento ;

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

            LlenarDGVEmpleado();
            LlenarDGVDepartamento();

        }

        public Empleado objEntEmpleado = new Empleado();

        #region Llenar DGV

        private void LlenarDGVEmpleado()
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
                MessageBox.Show("No hay departamentos cargado en el sistema");
        }

        private void LimpiarEmpleado()
        {
            txtNom.Text = string.Empty;
            txtAp.Text = string.Empty;
            txt2ap.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtCor.Text = string.Empty;
            FechaNacEmpleado.Value = DateTime.Now;
            
            

        }

        private void LimpiarDepartamento()
        {
            txtId.Text = string.Empty;
            txtNombreDepartamento.Text = string.Empty;
            

        }
        //falta el limpiar

        #endregion

        #region Boton agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposEmpleado();
            int nGrabados = -1;
            string dni = txtDni.Text;

            DataSet ds = objNegEmpleado.listaEmpleado(dni);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Ya existe un empleado con ese DNI");
            }
            else
            {
                if (validar == true)
                {
                    Txt_a_ObjAlumno();
                    nGrabados = objNegEmpleado.abmEmpleado("Alta", objEntEmpleado);
                    if (nGrabados == -1)
                    {
                        MessageBox.Show("error al agregar nuevo empleado");
                    }
                    else
                    {
                        MessageBox.Show("se agrego correctamente al empleado ");
                        LlenarDGVEmpleado();
                        //falta limpiar
                        //falta llenar combos
                        //tabControl1.SelectTab(tabControl1);
                    }
                }
            }

            
        }

        private void button4_Click(object sender, EventArgs e) //boton agregar departamento
        {
            bool validar = ValidacionCamposDepartamento();
            int nGrabados = -1;
            string cod = txtNombreDepartamento.Text;

            DataSet ds = objNegDepartamento.listaDepartamento(cod);

            if (ds.Tables[0].Rows.Count > 0)
            {

                MessageBox.Show("Ya existe un departamento con este Nombre.");
            }
            else
            {
                if (validar == true)
                {
                    Txt_a_ObjDepartamento();
                    nGrabados = objNegDepartamento.abmDepartamento("Alta", objEntDepartamento);
                    if (nGrabados == -1)
                    {
                        MessageBox.Show("No se logró agregar el departamento al sistema");
                    }
                    else
                    {
                        MessageBox.Show("Se logró agregar el departamento con éxito");
                        //LlenarDGVMateria();
                        //LimpiarMateria();
                        //LlenarCombos2();
                        //tabControl1.SelectTab(tabMateria);
                    }
                }
            }

        }
        #endregion

        #region Validacion

        public bool ValidacionCamposEmpleado()
        {
            //DNI

            if(txtDni.Text == string.Empty)
            {
                MessageBox.Show("ingresar Dni", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDni.Text.Length > 8 || txtDni.Text.Length < 7)
            {
                MessageBox.Show("Solo se permiten DNI entre 7 y 8 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Nombre

            if (txtNom.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un nombre del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNom.Text.Length > 50 || txtNom.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres de 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Apellido

            if (txtAp.Text == string.Empty)
            {
                MessageBox.Show("Ingrese apellido del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtAp.Text.Length > 50 || txtNom.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres de 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Segundo Apellido

            //if (txt2ap.Text == string.Empty)
            //{
            //    MessageBox.Show("Ingrese segundo apellido del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            //else if (txt2ap.Text.Length > 50 || txtNom.Text.Length < 2)
            //{
            //    MessageBox.Show("Solo se permiten apellido de 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //Correo

            if (txtCor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese apellido del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCor.Text.Length > 50 || txtNom.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten correo de 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;


            

            


        }

        public bool ValidacionCamposDepartamento()
        {
            if (txtNombreDepartamento.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un nombre valido para el departamento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreDepartamento.Text.Length > 50 || txtNombreDepartamento.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres entre 10 y 15 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        #endregion

        #region metodos texto a objeto
        private void Txt_a_ObjEmpleado()
        {
            objEntEmpleado.dni = int.Parse(txtDni.Text);
        }

        private void Txt_a_ObjDepartamento()
        {
            objEntDepartamento.NomDepartamento = txtNombreDepartamento.Text;
            objEntDepartamento.id = int.Parse(txtId.Text);
        }

        #endregion

        #region Modificar
        private void btnModEmp_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposEmpleado();
            int nResultado = -1;
            if (validar == true)
            {
                Txt_a_ObjEmpleado();
                nResultado = objNegEmpleado.abmEmpleado("Modificar", objEntEmpleado);
                if (nResultado != -1)
                {
                    MessageBox.Show("el empleado fue modificado con éxito");
                    LimpiarEmpleado();
                    LlenarDGVEmpleado();
                    //LlenarCombos();

                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar al empleado");
                }
            }
        }

       

        private void btnModDep_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposDepartamento();
            int nResultado = -1;
            if (validar == true)
            {
                Txt_a_ObjDepartamento();
                nResultado = objNegDepartamento.abmDepartamento("Modificar", objEntDepartamento);
                if (nResultado != -1)
                {
                    MessageBox.Show("el Departamento fue modificado con éxito");
                    LimpiarEmpleado();
                    LlenarDGVEmpleado();
                    //LlenarCombos();

                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar el departamento");
                }
            }
        }
        #endregion
    }



}

