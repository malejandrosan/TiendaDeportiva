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
 * Fecha: 04/10/2024
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * 0830 Programación Avanzada Sesión Virtual 1" de Johan Acosta Ibañez.
 * Enlace: https://www.youtube.com/watch?v=2ZOUapJjgpg&feature=youtu.be
 */

namespace CapaLogicaNegocio
{
    public class SucursalLN
    {
        #region Métodos
        // <summary>
        // Guarda el objeto en caso de que no haya un duplicado
        // Retorna True cuando se guarda satisfactoriamente
        // Retorna False cuando ya está registrado
        // <summary>
        public bool Guardar(Sucursal sucursal)
        {
            try
            {
                bool yaRegistroExiste = false;
                Sucursal[] arregloSucursal = SucursalAD.Consultar();

                if (arregloSucursal != null) 
                {
                    for (int i = 0;  i < arregloSucursal.Length; i++)
                    {
                        if (arregloSucursal[i] != null && arregloSucursal[i].Id == sucursal.Id)
                        {
                            yaRegistroExiste = true;
                            break;
                        }
                    }
                    if (yaRegistroExiste)
                    {
                        return false;
                    }
                    else
                    {
                        return SucursalAD.Guardar(sucursal);
                    }
                }
                return false;

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public Sucursal[] Consultar()
        {
            return SucursalAD.Consultar();
        }

        // <summary>
        // Consulta y retorna el objeto Sucursal existente con el nombre dado de parámetro
        // <summary>
        public Sucursal Consultar(string nombre)
        {
            try
            {
                Sucursal[] arregloSucursal = SucursalAD.Consultar();

                if (arregloSucursal != null)
                {
                    for (int i = 0; i < arregloSucursal.Length; i++)
                    {
                        if (arregloSucursal[i] != null && arregloSucursal[i].Nombre.Equals(nombre))
                        {
                            return arregloSucursal[i];
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
