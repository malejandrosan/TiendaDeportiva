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
 * Fecha: 06/09/2024
 */

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
            else if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                txtCantidad.Focus();
                return "Debe ingresar la cantidad";
            }
            else if (!int.TryParse(txtCantidad.Text, out int resultado))
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
            // utilizando un método anónimo
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
                    // Recorre cada fila seleccionada
                    foreach (DataGridViewRow row in dgvArticulos.SelectedRows)
                    {
                        // Obtiene el objeto Articulo mediante el id
                        ArticuloLN articuloLN = new ArticuloLN();
                        Articulo articulo = articuloLN.Consultar(Convert.ToInt32(row.Cells[0].Value));
                        
                        // Obtiene el objeto Sucursal mediante el nombre
                        SucursalLN sucursalLN = new SucursalLN();
                        Sucursal sucursal = sucursalLN.Consultar(cmbSucursal.Text);

                        // Crea instancia y almacena cada fila seleccionada
                        ArticulosXSucursal articulosXSucursal = new ArticulosXSucursal(sucursal, articulo, Convert.ToInt32(txtCantidad.Text));
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

        private void FrmRegistrarArticuloXSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                // Reset y obtiene arreglo de los articulos activos
                dgvArticulos.Rows.Clear();
                ArticuloLN articuloLN = new ArticuloLN();
                Articulo[] arregloArticulosActivos = articuloLN.ConsultarActivos();
                int cantidadArticulosActivos = articuloLN.ContarArticulosActivos();

                if (cantidadArticulosActivos <= 0)
                {
                    this.Close();
                    throw new Exception("Debe registrar un artículo activo");
                }

                // Carga articulos activos al datagridview
                dgvArticulos.DataSource = arregloArticulosActivos;

                // Obtiene arreglo de sucursales
                bool haySucursales = false;
                SucursalLN sucursalLN = new SucursalLN();
                Sucursal[] arregloSucursales = sucursalLN.Consultar();

                // Carga las sucursales activas al combobox
                foreach (Sucursal sucursal in arregloSucursales)
                {
                    if (sucursal != null && sucursal.Activo)
                    {
                        haySucursales = true;
                        cmbSucursal.Items.Add(sucursal.Nombre);
                    }
                }
                if (!haySucursales)
                {
                    this.Close();
                    throw new Exception("Debe registrar una sucursal activa");
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
