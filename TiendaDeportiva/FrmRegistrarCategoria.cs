using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaLogicaNegocio;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permite la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 04/10/2024
 */

namespace TiendaDeportiva
{
    public partial class FrmRegistrarCategoria : Form
    {
        #region Constructor
        public FrmRegistrarCategoria()
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
                return "Debe ingresar el id";
            }
            else if (!int.TryParse(txtId.Text, out int resultado))
            {
                txtId.Focus();
                return "Debe ingresar un id válido";
            }
            else if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Focus();
                return "Debe ingresar el nombre";
            }
            else if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                txtNombre.Focus();
                return "Debe ingresar la descripción";
            }
            return string.Empty;
        }

        private void LimpiarPantalla()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
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

                if (string.IsNullOrWhiteSpace(mensajeValidacion))
                {
                    Categoria categoria = new Categoria(Convert.ToInt32(txtId.Text), txtNombre.Text, txtDescripcion.Text);

                    CategoriaLN categoriaLN = new CategoriaLN();
                    bool IngresoCorrecto = categoriaLN.Guardar(categoria);

                    if (IngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MostrarMensaje("El registro se ha ingresado correctamente", Color.Green);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
