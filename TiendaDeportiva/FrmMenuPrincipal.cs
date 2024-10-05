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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        // Referencia sobre .ShowDialog tomada de https://meeraacademy.com/show-vs-showdialog-in-c-windows-forms-application/
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Oculta FrmPrincipal y muestra FrmRegistrarMenu
            FrmRegistrarMenu frm = new FrmRegistrarMenu();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}
