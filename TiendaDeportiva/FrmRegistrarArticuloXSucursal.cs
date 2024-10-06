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
            if (!int.TryParse(txtCantidad.Text, out int resultado))
            {
                txtCantidad.Focus();
                return "Debe ingresar una cantidad válida";
            }
            return string.Empty;
        }

        private void LimpiarPantalla()
        {
            cmbSucursal.SelectedIndex = -1;
            txtCantidad.Text = string.Empty;
        }

        // Información tomada de: 
        // https://stackoverflow.com/questions/15951689/show-label-text-as-warning-message-and-hide-it-after-a-few-seconds
        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
            lblMensaje.Visible = true;

            // Temporizador para mostrar mensaje del label por 3 segundos y desaparecerlo
            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, e) =>
            {
                lblMensaje.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
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
                        MostrarMensaje("Se ha agregado el registro correctamente", Color.Green);
                    }
                    else
                    {
                        MostrarMensaje("No se ha podido ingresar correctamente", Color.Red);
                    }
                }
                else
                {
                    MostrarMensaje(mensajeValidacion, Color.Red);
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
