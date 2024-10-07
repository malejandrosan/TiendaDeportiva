﻿using System;
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
    public class Cliente
    {
        #region Atributos
        private int id;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private DateTime fechaNacimiento;
        private bool activo;
        #endregion

        #region Métodos Get y Set
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public bool Activo { get => activo; set => activo = value; }
        #endregion

        #region Constructores
        public Cliente() 
        {
            id = 0;
            nombre = string.Empty;
            apellido1 = string.Empty;
            apellido2 = string.Empty;
            fechaNacimiento = new DateTime();
            activo = false;
        }

        public Cliente(int id, string nombre, string apellido1, string apellido2, DateTime fechaNacimiento, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.fechaNacimiento = fechaNacimiento;
            this.activo = activo;
        }
        #endregion

        #region Método ToString
        public override string ToString()
        {
            return $"Id: {id}, nombre: {nombre}, apellido 1: {apellido1}, apellido 2: {apellido2}, fecha de nacimiento: {fechaNacimiento}, activo: {activo}";
        }
        #endregion

    }
}
