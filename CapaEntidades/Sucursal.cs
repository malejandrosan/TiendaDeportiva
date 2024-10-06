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
    public class Sucursal
    {
        // Atributos
        private int id;
        private string nombre;
        private Administrador administrador;
        private string direccion;
        private string telefono;
        private bool activo;
        
        // Métodos Get y Set
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Administrador Administrador { get => administrador; set => administrador = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool Activo { get => activo; set => activo = value; }

        // Constructores de la clase
        public Sucursal() 
        {
            id = 0;
            nombre = string.Empty;
            administrador= new Administrador();
            direccion= string.Empty;
            telefono= string.Empty;
            activo = false;
        }

        public Sucursal(int id, string nombre, Administrador administrador, string direccion, string telefono, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.administrador = administrador;
            this.direccion = direccion;
            this.telefono = telefono;
            this.activo = activo;
        }


        // Métodos
        public override string ToString()
        {
            return $"Id: {id}, nombre: {nombre}, administrador: {administrador.Nombre}, dirección: {direccion}, teléfono: {telefono}, activo: {activo}";
        }

    }
}
