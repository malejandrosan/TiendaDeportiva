﻿using System;
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

        #region Métodos
        private string ValidaDatos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                txtId.Focus();
                return "Debe ingresar un número de identificación";
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Focus();
                return "Debe ingresar un nombre";
            }
            if (string.IsNullOrEmpty(txtApellido1.Text))
            {
                txtApellido1.Focus();
                return "Debe ingresar el primer apellido";
            }
            if (string.IsNullOrEmpty(txtApellido2.Text))
            {
                txtApellido2.Focus();
                return "Debe ingresar el segundo apellido";
            }

            return string.Empty;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string valida = ValidaDatos();

                if (string.IsNullOrEmpty(valida))
                {
                    Administrador administrador = new Administrador();
                    administrador.Id = Convert.ToInt32(txtId.Text);
                    administrador.Nombre = txtNombre.Text;
                    administrador.Apellido1 = txtApellido1.Text;
                    administrador.Apellido2 = txtApellido2.Text;
                    administrador.FechaNacimiento = dtpFechaNacimiento.Value;
                    administrador.FechaIngreso = dtpFechaIngreso.Value;

                    AdministradorLN administradorLN = new AdministradorLN();
                    bool esIngresoCorrecto = administradorLN.Guardar(administrador);

                    if (esIngresoCorrecto)
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
                    MessageBox.Show(valida);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Un error ha ocurrido. Contacte al administrador del sistema");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
