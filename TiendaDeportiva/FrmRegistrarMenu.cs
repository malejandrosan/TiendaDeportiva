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
 * Fecha: 21/09/2024
 */

namespace TiendaDeportiva
{
    public partial class FrmRegistrarMenu : Form
    {
        public FrmRegistrarMenu()
        {
            InitializeComponent();
        }

        private void btnNuevoAdministrador_Click(object sender, EventArgs e)
        {
            FrmRegistrarAdministrador frm = new FrmRegistrarAdministrador();
            frm.ShowDialog();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.Show();
            this.Close();
        }

        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            FrmRegistrarArticulo frm = new FrmRegistrarArticulo();
            frm.ShowDialog();
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            FrmRegistrarCategoria frm = new FrmRegistrarCategoria();
            frm.ShowDialog();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmRegistrarCliente frm = new FrmRegistrarCliente();
            frm.ShowDialog();
        }

        private void btnNuevaSucursal_Click(object sender, EventArgs e)
        {
            FrmRegistrarSucursal frm = new FrmRegistrarSucursal();
            frm.ShowDialog();
        }

        private void btnNuevoArticuloASucursal_Click(object sender, EventArgs e)
        {
            FrmRegistrarArticuloXSucursal frm = new FrmRegistrarArticuloXSucursal();
            frm.ShowDialog();
        }
    }
}
