using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permite la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 29/09/2024
 */

namespace CapaAccesoDatos
{
    public static class SucursalAD
    {
        #region Atributos
        public static Sucursal[] arregloSucursales = new Sucursal[5];
        public static int indice = 0;
        #endregion

        #region Métodos
        public static bool Guardar(Sucursal sucursal)
        {
            try
            {
                arregloSucursales[indice] = sucursal;
                indice++;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("El repositorio se encuentra lleno");
            }
        }

        public static Sucursal[] Consulta()
        {
            return arregloSucursales;
        }
        #endregion
    }
}
