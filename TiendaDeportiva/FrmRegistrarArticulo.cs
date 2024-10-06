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

namespace TiendaDeportiva
{
    public partial class FrmRegistrarArticulo : Form
    {
        public FrmRegistrarArticulo()
        {
            InitializeComponent();
        }

        // Información sobre try parse tomada de https://josipmisko.com/posts/c-sharp-tryparse
        private string ValidaDatos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    txtId.Focus();
                    return "Debe ingresar un número id";
                }
                if (!int.TryParse(txtId.Text, out int resultado))
                {
                    txtId.Focus();
                    return "Debe ingresar un id válido";
                }
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    txtDescripcion.Focus();
                    return "Debe ingresar una descripción";
                }
                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    txtMarca.Focus();
                    return "Debe ingresar una marca";
                }
                if (string.IsNullOrWhiteSpace(cmbCategoria.Text))
                {
                    cmbCategoria.Focus();
                    return "Debe seleccionar una categoría";
                }
                if (string.IsNullOrWhiteSpace(cmbActivo.Text))
                {
                    cmbActivo.Focus();
                    return "Debe seleccionar si se encuentra activo o no";
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #region Métodos
        private void LimpiarPantalla()
        {
            txtId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtMarca.Text = string.Empty;
            cmbCategoria.SelectedIndex = -1;
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

                if (string.IsNullOrEmpty(mensajeValidacion))
                {
                    CategoriaLN categoriaLN = new CategoriaLN();
                    Categoria categoria = categoriaLN.Consultar(cmbCategoria.Text);

                    Articulo articulo = new Articulo(Convert.ToInt32(txtId.Text), txtDescripcion.Text, categoria, txtMarca.Text, cmbActivo.Text.Equals("Si"));

                    ArticuloLN articuloLN = new ArticuloLN();
                    bool esIngresoCorrecto = articuloLN.Guardar(articulo);


                    if (esIngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MostrarMensaje("El registro se ha agregado correctamente", Color.Green);
                    }
                    else
                    {
                        MostrarMensaje("No se ha podido registrar correctamente", Color.Red);
                    }
                }
                else 
                {
                    MostrarMensaje(mensajeValidacion, Color.Red);
                }
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        // Información tomada de
        // https://stackoverflow.com/questions/18543299/how-can-i-add-array-values-into-a-combobox#:~:text=You%20can%20add%20an%20array%20of%20strings%20using%20method%20AddRange(array[])
        private void FrmRegistrarArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                CategoriaLN categoriaLN = new CategoriaLN();
                Categoria[] arregloCategorias = categoriaLN.Consultar();

                foreach (Categoria categoria in arregloCategorias)
                {
                    if (categoria != null)
                    {
                        cmbCategoria.Items.Add(categoria.Nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
