using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* UNED III Cuatrimestre
 * Proyecto I: Programa que permita la administración de una Tienda Deportiva
 * Estudiante: Mario Sánchez Gamboa
 * Fecha: 17/09/2024
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * Sesión Virtual 01 Tutor: Marlon Dixon Gómez" de Marlon Dixon Gómez.
 * Enlace: https://www.youtube.com/watch?v=U2dpCmOPsqs
 */

namespace CapaEntidades
{
    public class Categoria
    {
        // Atributos
        public int id;
        public string nombre;
        public string descripcion;

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
            return nombre;
        }


    }
}
