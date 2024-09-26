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
 * Fecha: 24/09/2024
 */

namespace TiendaDeportiva
{
    public partial class FrmRegistrarAdministrador : Form
    {
        public FrmRegistrarAdministrador()
        {
            InitializeComponent();
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtId.Text) ||
                string.IsNullOrEmpty(txtNombre.Text)  ||
                string.IsNullOrEmpty(txtApellido1.Text) ||
                string.IsNullOrEmpty(txtApellido2.Text))
                { return false; }
            return true;
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


        // Formato de fecha tomado de https://stackoverflow.com/questions/1138195/how-to-get-only-the-date-value-from-a-windows-forms-datetimepicker-control
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String id =  txtId.Text;
            String nombre = txtNombre.Text;
            String ape1 = txtApellido1.Text;
            String ape2 = txtApellido2.Text;
            if (ValidarDatos())
            {
                Console.WriteLine($"ID: {id}, nombre: {nombre}, primer apellido: {ape1}, segundo apellido: {ape2}");
                Console.WriteLine($"Fecha Nacimiento: {dtpFechaNacimiento.Value.ToShortDateString()}");
                Console.WriteLine($"Fecha Ingreso: {dtpFechaIngreso.Value.ToShortDateString()}");
                LimpiarPantalla();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
