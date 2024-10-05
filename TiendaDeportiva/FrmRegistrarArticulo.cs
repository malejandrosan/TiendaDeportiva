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
        private string ValidaDatos()
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    txtId.Focus();
                    return "Debe ingresar un número id";
                }
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    txtDescripcion.Focus();
                    return "Debe ingresar una descripción";
                }
                if (string.IsNullOrEmpty(txtMarca.Text))
                {
                    txtMarca.Focus();
                    return "Debe ingresar una marca";
                }
                if (string.IsNullOrEmpty(cmbCategoria.Text))
                {
                    cmbCategoria.Focus();
                    return "Debe seleccionar una categoría";
                }
                if (string.IsNullOrEmpty(cmbActivo.Text))
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

                    Articulo articulo = new Articulo();


                    ArticuloLN articuloLN = new ArticuloLN();
                    bool esIngresoCorrecto = articuloLN.Guardar(articulo);

                    //CategoriaLN categoriaLN = new CategoriaLN();
                    //Categoria categoria = categoriaLN.Consulta();


                    if (esIngresoCorrecto)
                    {
                        LimpiarPantalla();
                        MessageBox.Show("El registro se ha agregado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido registrar correctamente");
                    }
                }
                else 
                {
                    MessageBox.Show(mensajeValidacion);
                }
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
