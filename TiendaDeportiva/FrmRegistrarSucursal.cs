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
    public partial class FrmRegistrarSucursal : Form
    {
        #region Constructor
        public FrmRegistrarSucursal()
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
                return "Debe ingresar el ID";
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Focus();
                return "Debe ingresar el nombre";
            }
            if (string.IsNullOrWhiteSpace(cmbAdministrador.Text))
            {
                cmbAdministrador.Focus();
                return "Debe ingresar el administrador";
            }
            if (string.IsNullOrWhiteSpace (txtDireccion.Text))
            {
                txtDireccion.Focus();
                return "Debe ingresar la dirección";
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                txtTelefono.Focus();
                return "Debe ingresar el número de teléfono";
            }
            if (string.IsNullOrWhiteSpace(cmbActivo.Text))
            {
                cmbActivo.Focus();
                return "Debe ingresar si es activo o no";
            }
            return String.Empty;
        }

        private void LimpiarPantalla()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cmbActivo.SelectedIndex = -1;
            cmbAdministrador.SelectedIndex = -1;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeValidacion = ValidaDatos();
                if (string.IsNullOrEmpty(mensajeValidacion))
                {
                    Sucursal sucursal = new Sucursal();

                    SucursalLN sucursalLN = new SucursalLN();
                    bool IngresoCorrecto = sucursalLN.Guardar(sucursal);

                    if (IngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MessageBox.Show("El registro se ha ingresado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha ingresado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show(mensajeValidacion);
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
