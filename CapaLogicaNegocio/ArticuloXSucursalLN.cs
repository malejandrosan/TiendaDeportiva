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
 * Fecha: 06/10/2024
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * 0830 Programación Avanzada Sesión Virtual 1" de Johan Acosta Ibañez.
 * Enlace: https://www.youtube.com/watch?v=2ZOUapJjgpg&feature=youtu.be
 */

namespace CapaLogicaNegocio
{
    public class ArticuloXSucursalLN
    {
        #region Métodos
        // <summary>
        // Guarda el objeto en caso de que no haya un duplicado
        // Retorna True cuando se guarda satisfactoriamente
        // Retorna False cuando ya está registrado
        // <summary>
        public bool Guardar(ArticulosXSucursal articulosXSucursal)
        {
            try
            {
                bool yaExisteRegistro = false;
                ArticulosXSucursal[] arreglo = ArticuloXSucursalAD.Consultar();

                if (arreglo != null)
                {
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        if (arreglo[i] != null && arreglo[i].Sucursal.Equals(articulosXSucursal.Sucursal))
                        {
                            if (arreglo[i].Articulo.Id == articulosXSucursal.Articulo.Id && arreglo[i].Sucursal.Id == articulosXSucursal.Sucursal.Id)
                            {
                                yaExisteRegistro = true;
                                break;
                            }
                        }
                    }
                    if (yaExisteRegistro)
                    {
                        return false;
                    }
                    else
                    {
                        return ArticuloXSucursalAD.Guardar(articulosXSucursal);
                    }
                }
                return false;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public ArticulosXSucursal[] Consultar()
        {
            return ArticuloXSucursalAD.Consultar();
        }

    }
}
