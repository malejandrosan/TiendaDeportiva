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
        public bool Guardar(Administrador administrador)
        {
            try
            {
                bool yaExisteRegistro = false;

                Administrador[] arregloAdministradores = AdministradorAD.Consultar();

                if (arregloAdministradores != null)
                {
                    for (int i = 0; i < arregloAdministradores.Length; i++)
                    {
                        if (arregloAdministradores[i] != null && arregloAdministradores[i].Id == administrador.Id)
                        {
                            yaExisteRegistro = true;
                            break;
                        }
                    }
                    if (yaExisteRegistro)
                    {
                        return false;
                    }
                    else
                    {
                        return AdministradorAD.Guardar(administrador);
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
