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
    }
}
