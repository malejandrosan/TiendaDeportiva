using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permita la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 18/09/2024
 */

namespace CapaEntidades
{
    public class Articulo
    {
        // Atributos
        private int id;
        private string descripcion;
        private Categoria categoria;
        private string marca;
        private bool activo;

        // Métodos Get y Set
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public string Marca { get => marca; set => marca = value; }
        public bool Activo { get => activo; set => activo = value; }


        // Constructores de la clase
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

        // Métodos
        public override string ToString()
        {
            return $"Id: {id}, descripción: {descripcion}, categoria: {categoria.Nombre}, marca: {marca}, activo: {activo}";
        }



    }
}
