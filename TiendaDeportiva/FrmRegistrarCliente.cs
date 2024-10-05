using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permite la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 26/09/2024
 */

namespace TiendaDeportiva
{
    public partial class FrmRegistrarCliente : Form
    {
        #region Constructor
        public FrmRegistrarCliente()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        private string ValidaDatos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                txtId.Focus();
                return "Debe ingresar el número identificación";
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Focus();
                return "Debe ingresar el nombre";
            }
            if (string.IsNullOrWhiteSpace(txtApellido1.Text))
            {
                txtApellido1.Focus();
                return "Debe ingresar el primer apellido";
            }
            if (string.IsNullOrWhiteSpace(txtApellido2.Text))
            {
                txtApellido2.Focus();
                return "Debe ingresar el segundo apellido";
            }
            if (string.IsNullOrWhiteSpace(dtpFechaNacimiento.ToString()))
            {
                dtpFechaNacimiento.Focus();
                return "Debe ingresar la fecha de nacimiento";
            }
            if (string.IsNullOrWhiteSpace(cmbActivo.Text))
            {
                cmbActivo.Focus();
                return "Debe ingresar si es activo o no";
            }
            return string.Empty;
        }

        private void LimpiarPantalla()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            dtpFechaNacimiento.ResetText();
            cmbActivo.SelectedIndex = -1;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string valida = ValidaDatos();

                if (string.IsNullOrWhiteSpace(valida))
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = Convert.ToInt32(txtId.Text);
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido1 = txtApellido1.Text;
                    cliente.Apellido2 = txtApellido2.Text;
                    cliente.FechaNacimiento = dtpFechaNacimiento.Value;
                    cliente.Activo = cmbActivo.Equals("Si");

                    ClienteLN clienteLN = new ClienteLN();

                    bool IngresoCorrecto = clienteLN.Guardar(cliente);
                    if (IngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MessageBox.Show("Se ha ingresado el registro correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha ingresado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show(valida);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Un error ha ocurrido. Contacte al administrador del sistema");
            }
        }
        #endregion
    }
}
