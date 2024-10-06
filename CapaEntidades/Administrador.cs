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
    public class Administrador
    {
        // Atributos
        private int id;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private DateTime fechaNacimiento;
        private DateTime fechaIngreso;

        // Métodos Get y Set
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }

        // Constructores de la clase
        public Administrador()
        {
            id = 0;
            nombre = string.Empty;
            apellido1 = string.Empty;
            apellido2 = string.Empty;
            fechaNacimiento = new DateTime();
            fechaIngreso = new DateTime();
        }

        public Administrador(int id, string nombre, string apellido1, string apellido2, DateTime fechaNacimiento, DateTime fechaIngreso)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaIngreso = fechaIngreso;
        }

        // Métodos
        public override string ToString()
        {
            return nombre ;
        }

    }
}
