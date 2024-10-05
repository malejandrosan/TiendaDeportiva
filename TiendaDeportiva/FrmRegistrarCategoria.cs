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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Focus();
                return "Debe ingresar el nombre";
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
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
                        MessageBox.Show("El registro se ha ingresado correctamente");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
