using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permita la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 17/09/2024
 */

namespace CapaEntidades
{
    public class Categoria
    {
        // Atributos
        private int id;
        private string nombre;
        private string descripcion;

        // Métodos Get y Set
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }


        // Constructores de la clase
        public Categoria()
        {
            id = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
        } 

        public Categoria(int id, string nombre, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }


        /* Métodos 
         * Información tomada de https://www.webdevtutor.net/blog/c-tostring-override
         */
        public override string ToString()
        {
            return $"Id: {id}, nombre: {nombre}, descripción: {descripcion}";
        }


    }
}
