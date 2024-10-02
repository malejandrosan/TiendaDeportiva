using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permite la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 29/09/2024
 */


namespace CapaLogicaNegocio
{
    public class AdministradorLN
    {

        #region Métodos
        public bool GuardarAdministrador(Administrador administrador)
        {
            try
            {
                bool esIngresado = false;

                Administrador[] administradores = AdministradorAD.Consultar();

                if (administradores != null)
                {
                    for (int i = 0; i < administradores.Length; i++)
                    {
                        if (administradores[i].Id != null && administradores[i].Id == administrador.Id)
                        {
                            esIngresado = true;
                            break;
                        }
                    }
                    if (esIngresado)
                    {
                        return false;
                    }
                    else
                    {
                        return AdministradorAD.GuardarAdministrador(administrador);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Administrador[] Consultar()
        {
            return AdministradorAD.Consultar();
        }


        #endregion
    }
}
