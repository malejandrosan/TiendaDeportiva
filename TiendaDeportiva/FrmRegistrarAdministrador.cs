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
 * Fecha: 24/09/2024
 */

namespace TiendaDeportiva
{
    public partial class FrmRegistrarAdministrador : Form
    {
        #region Constructor
        public FrmRegistrarAdministrador()
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
                return "Debe ingresar un número de identificación";
            }
            if (!int.TryParse(txtId.Text, out int resultado))
            {
                txtId.Focus();
                return "Debe ingresar una identificación válida";
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

            return string.Empty;
        }

        private void LimpiarPantalla()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            dtpFechaNacimiento.ResetText();
            dtpFechaIngreso.ResetText();
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


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeValidacion = ValidaDatos();

                if (string.IsNullOrEmpty(mensajeValidacion))
                {
                    Administrador administrador = new Administrador();
                    administrador.Id = Convert.ToInt32(txtId.Text);
                    administrador.Nombre = txtNombre.Text;
                    administrador.Apellido1 = txtApellido1.Text;
                    administrador.Apellido2 = txtApellido2.Text;
                    administrador.FechaNacimiento = dtpFechaNacimiento.Value;
                    administrador.FechaIngreso = dtpFechaIngreso.Value;

                    AdministradorLN administradorLN = new AdministradorLN();
                    bool esIngresoCorrecto = administradorLN.Guardar(administrador);

                    if (esIngresoCorrecto)
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
                MessageBox.Show("Un error ha ocurrido. Contacte al administrador del sistema");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
