using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permita la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 19/09/2024
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * Sesión Virtual 01 Tutor: Marlon Dixon Gómez" de Marlon Dixon Gómez.
 * Enlace: https://www.youtube.com/watch?v=U2dpCmOPsqs
 */

namespace CapaEntidades
{
    public class ArticulosXSucursal
    {
        #region Atributos
        private Sucursal sucursal;
        private Articulo articulo;
        private int cantidad;
        #endregion

        #region Métodos Get y Set
        public Sucursal Sucursal { get => sucursal; set => sucursal = value; }
        public Articulo Articulo { get => articulo; set => articulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        #endregion

        #region Constructores
        public ArticulosXSucursal() 
        { 
            sucursal = new Sucursal();
            articulo = new Articulo();
            cantidad = 0;
        }

        public ArticulosXSucursal(Sucursal sucursal, Articulo articulo, int cantidad)
        {
            this.sucursal = sucursal;
            this.articulo = articulo;
            this.cantidad = cantidad;
        }
        #endregion

        #region Método ToString
        public override string ToString()
        {
            return $"Sucursal: {sucursal.Id}, artículo:{articulo.Id}, cantidad: {cantidad}";
        }
        #endregion
    }
}
