using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permite la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 05/10/2024
 */


namespace TiendaDeportiva
{
    public partial class FrmConsultar : Form
    {
        #region Constructor
        public FrmConsultar()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        private void cmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cmbOpciones.SelectedItem.ToString();
            dgvConsultar.DataSource = null;
            dgvConsultar.Rows.Clear();

            switch (opcion)
            {
                case "Administrador":
                    AdministradorLN administradorLN = new AdministradorLN();
                    Administrador[] arregloAdministrador = administradorLN.Consultar();
                    dgvConsultar.DataSource = arregloAdministrador;
                    break;

                case "Cliente":
                    ClienteLN clienteLN = new ClienteLN();
                    Cliente[] arregloCliente = clienteLN.Consultar();
                    dgvConsultar.DataSource = arregloCliente;
                    break;

                case "Artículo":
                    ArticuloLN articuloLN = new ArticuloLN();
                    Articulo[] arregloArticulos = articuloLN.Consultar();
                    dgvConsultar.DataSource = arregloArticulos;
                    break;

                case "Artículos Por Sucursal":
                    ArticuloXSucursalLN articuloXSucursalLN = new ArticuloXSucursalLN();
                    ArticulosXSucursal[] arregloArticulosXSucursal = articuloXSucursalLN.Consultar();
                    dgvConsultar.DataSource = arregloArticulosXSucursal;
                    break;

                case "Categoria":
                    CategoriaLN categoriaLN = new CategoriaLN();
                    Categoria[] arregloCategorias = categoriaLN.Consultar();
                    dgvConsultar.DataSource = arregloCategorias;
                    break;

                case "Sucursal":
                    SucursalLN sucursalLN = new SucursalLN();
                    Sucursal[] arregloSucursales = sucursalLN.Consultar();
                    dgvConsultar.DataSource = arregloSucursales;
                    break;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
