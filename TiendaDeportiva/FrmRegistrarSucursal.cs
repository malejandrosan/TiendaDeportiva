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
            else if (string.IsNullOrWhiteSpace(cmbAdministrador.Text))
            {
                cmbAdministrador.Focus();
                return "Debe ingresar el administrador";
            }
            else if (string.IsNullOrWhiteSpace (txtDireccion.Text))
            {
                txtDireccion.Focus();
                return "Debe ingresar la dirección";
            }
            else if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                txtTelefono.Focus();
                return "Debe ingresar el número de teléfono";
            }
            else if (string.IsNullOrWhiteSpace(cmbActivo.Text))
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
                    
                    AdministradorLN administradorLN = new AdministradorLN();
                    Administrador administrador = administradorLN.Consultar(cmbAdministrador.Text);
                    Sucursal sucursal = new Sucursal(Convert.ToInt32(txtId.Text), txtNombre.Text, administrador, txtDireccion.Text, txtTelefono.Text, cmbActivo.Text.Equals("Si"));

                    SucursalLN sucursalLN = new SucursalLN();
                    bool IngresoCorrecto = sucursalLN.Guardar(sucursal);

                    if (IngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MostrarMensaje("El registro se ha ingresado correctamente", Color.Green);
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
        private void FrmRegistrarSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                bool hayAdministradores = false;
                AdministradorLN administradorLN = new AdministradorLN();
                Administrador[] arregloAdministradores = administradorLN.Consultar();

                if (arregloAdministradores != null)
                {
                    foreach (Administrador administrador in arregloAdministradores)
                    {
                        if (administrador != null)
                        {
                            hayAdministradores = true;
                            cmbAdministrador.Items.Add(administrador);
                        }
                    }
                }
                if (!hayAdministradores)
                {
                    this.Close();
                    throw new Exception("Debe registrar un administrador primero");
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
