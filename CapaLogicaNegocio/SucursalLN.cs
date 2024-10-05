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
 * Fecha: 04/10/2024
 */

namespace CapaLogicaNegocio
{
    public class SucursalLN
    {
        #region Métodos
        public bool Guardar(Sucursal sucursal)
        {
            try
            {
                bool yaRegistroExiste = false;
                Sucursal[] arregloSucursal = SucursalAD.Consultar();

                if (arregloSucursal != null) 
                {
                    for (int i = 0;  i < arregloSucursal.Length; i++)
                    {
                        if (arregloSucursal[i] != null && arregloSucursal[i].Id == sucursal.Id)
                        {
                            yaRegistroExiste = true;
                            break;
                        }
                    }
                    if (yaRegistroExiste)
                    {
                        return false;
                    }
                    else
                    {
                        return SucursalAD.Guardar(sucursal);
                    }
                }
                return false;

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public Sucursal[] Consultar()
        {
            return SucursalAD.Consultar();
        }
        #endregion
    }
}
