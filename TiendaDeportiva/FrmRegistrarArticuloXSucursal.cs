using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaDeportiva
{
    public partial class FrmRegistrarArticuloXSucursal : Form
    {
        public FrmRegistrarArticuloXSucursal()
        {
            InitializeComponent();
        }

        private void LimpiarPantalla()
        {
            cmbSucursal.SelectedIndex = 0;
            txtCantidad.Text = string.Empty;

        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
