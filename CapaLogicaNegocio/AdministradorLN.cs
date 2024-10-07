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
    public class AdministradorLN
    {

        #region Métodos
        // <summary>
        // Guarda el objeto en caso de que no haya un duplicado
        // Retorna True cuando se guarda satisfactoriamente
        // Retorna False cuando ya está registrado
        // <summary>
        public bool Guardar(Administrador administrador)
        {
            try
            {
                bool yaExisteRegistro = false;

                Administrador[] arregloAdministradores = AdministradorAD.Consultar();

                if (arregloAdministradores != null)
                {
                    for (int i = 0; i < arregloAdministradores.Length; i++)
                    {
                        if (arregloAdministradores[i] != null && arregloAdministradores[i].Id == administrador.Id)
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
                        return AdministradorAD.Guardar(administrador);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Administrador[] Consultar()
        {
            return AdministradorAD.Consultar();
        }

        // <summary>
        // Consulta y retorna el objeto Administrador existente con el nombre dado de parámetro
        // <summary>
        public Administrador Consultar(string nombre)
        {
            try
            {
                Administrador [] arregloAdministradores = AdministradorAD.Consultar();

                if (arregloAdministradores != null)
                {
                    for (int i = 0; i < arregloAdministradores.Length; i++)
                    {
                        if (arregloAdministradores[i] != null && arregloAdministradores[i].Nombre.Equals(nombre))
                        {
                            return arregloAdministradores[i];
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
