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

namespace TiendaDeportiva
{
    public partial class FrmRegistrarArticuloXSucursal : Form
    {
        #region Constructor
        public FrmRegistrarArticuloXSucursal()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        private string ValidaDatos()
        {
            if (string.IsNullOrWhiteSpace(cmbSucursal.Text))
            {
                cmbSucursal.Focus();
                return "Debe ingresar la sucursal";
            }
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                txtCantidad.Focus();
                return "Debe ingresar la cantidad";
            }
            return string.Empty;
        }

        private void LimpiarPantalla()
        {
            cmbSucursal.SelectedIndex = -1;
            txtCantidad.Text = string.Empty;
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
                    ArticulosXSucursal articulosXSucursal = new ArticulosXSucursal();


                    ArticuloXSucursalLN articuloXSucursalLN = new ArticuloXSucursalLN();
                    bool IngresoCorrecto = articuloXSucursalLN.Guardar(articulosXSucursal);

                    if (IngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MessageBox.Show("Se ha agregado el registro correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido ingresar correctamente");
                    }
                }
                else
                {
                    MessageBox.Show(mensajeValidacion);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Un error ha ocurrido. Contacte al administrador del sistema");
            }
        }
        #endregion
    }
}
