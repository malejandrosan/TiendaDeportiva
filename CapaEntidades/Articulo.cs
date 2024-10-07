using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permita la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 18/09/2024
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * Sesión Virtual 01 Tutor: Marlon Dixon Gómez" de Marlon Dixon Gómez.
 * Enlace: https://www.youtube.com/watch?v=U2dpCmOPsqs
 */

namespace CapaEntidades
{
    public class Articulo
    {
        #region Atributos
        private int id;
        private string descripcion;
        private Categoria categoria;
        private string marca;
        private bool activo;
        #endregion

        #region Métodos Get y Set
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public string Marca { get => marca; set => marca = value; }
        public bool Activo { get => activo; set => activo = value; }
        #endregion

        #region Constructores
        public Articulo()
        {
            id = 0;
            descripcion = string.Empty;
            categoria = null;
            marca = string.Empty;
            activo = false;
        }

        public Articulo(int id, string descripcion, Categoria categoria, string marca, bool activo)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.marca = marca;
            this.activo = activo;
        }
        #endregion

        #region Método ToString
        public override string ToString()
        {
            return $"ID: {id}, descripción: {descripcion}, categoria: {categoria.Nombre}, marca: {marca}, activo: {activo}";
        }
        #endregion
    }
}
