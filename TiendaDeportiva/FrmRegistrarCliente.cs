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
            if (!int.TryParse(txtId.Text, out int resultado))
            {
                txtId.Focus();
                return "Debe ingresar un número de identificación válido";
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
                        MostrarMensaje("Se ha ingresado el registro correctamente", Color.Green);
                    }
                    else
                    {
                        MostrarMensaje("No se ha ingresado correctamente", Color.Red);
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
        #endregion
    }
}
