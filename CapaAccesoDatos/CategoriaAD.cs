using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace CapaAccesoDatos
{
    public static class CategoriaAD
    {
        #region Atributos
        public static Categoria[] arregloCategorias = new Categoria[10];
        public static int indice = 0;
        #endregion


        #region Métodos
        public static bool Guardar(Categoria categoria)
        {
            try
            {
                arregloCategorias[indice] = categoria;
                indice++;
                return true;
            }
            catch (IndexOutOfRangeException) 
            {
                throw new IndexOutOfRangeException("El repositorio se encuentra lleno");
            }
        }

        public static Categoria[] Consultar()
        {
            return arregloCategorias;
        }
        #endregion

    }
}
