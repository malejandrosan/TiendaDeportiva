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
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * 0830 Programación Avanzada Sesión Virtual 1" de Johan Acosta Ibañez.
 * Enlace: https://www.youtube.com/watch?v=2ZOUapJjgpg&feature=youtu.be
 */

namespace CapaLogicaNegocio
{
    public class ArticuloXSucursalLN
    {
        #region
        public bool Guardar(ArticulosXSucursal articulosXSucursal)
        {
            try
            {
                return true;
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
