using CapaEntidades;
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
        public FrmRegistrarCliente()
        {
            InitializeComponent();
        }

        private bool SonDatosValidos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido1.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido2.Text) ||
                    string.IsNullOrWhiteSpace(dtpFechaNacimiento.Value.ToShortDateString()) ||
                    cmbActivo.SelectedIndex.Equals(-1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception e) {
                return false;
            }
        }


        // https://stackoverflow.com/questions/9321844/how-do-i-clear-a-combobox
        private void LimpiarPantalla()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            dtpFechaNacimiento.ResetText();
            cmbActivo.SelectedIndex = -1;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (SonDatosValidos())
            {
                Cliente cliente = new Cliente();

                cliente.Id = Convert.ToInt32(txtId.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido1 = txtApellido1.Text;
                cliente.Apellido2 = txtApellido2.Text;
                cliente.FechaNacimiento = dtpFechaNacimiento.Value;

                // Información sobre arrays tomada de: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
                Cliente[] clientes = new Cliente [5];





                LimpiarPantalla();
            }
            else
            {
                MessageBox.Show("Error: Por favor ingrese todos los espacios.");
            }
        }
    }
}
