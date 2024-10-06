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
 * 
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * 0830 Programación Avanzada Sesión Virtual 1" de Johan Acosta Ibañez.
 * Enlace: https://www.youtube.com/watch?v=2ZOUapJjgpg&feature=youtu.be
 */

namespace CapaLogicaNegocio
{
    public class ArticuloLN
    {
        #region Métodos
        public bool Guardar(Articulo articulo)
        {
            try
            {
                bool yaExisteRegistro = false;
                Articulo[] arregloArticulos = ArticuloAD.Consultar();

                if (arregloArticulos != null)
                {
                    for (int i = 0; i < arregloArticulos.Length; i++) 
                    { 
                        if (arregloArticulos[i] != null && arregloArticulos[i].Id == articulo.Id)
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
                        return ArticuloAD.Guardar(articulo);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Articulo[] Consultar()
        {
            return ArticuloAD.Consultar();
        }
        #endregion

    }
}
