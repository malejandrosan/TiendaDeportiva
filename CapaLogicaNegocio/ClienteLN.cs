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
 * Fecha: 4/10/2024
 *
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * 0830 Programación Avanzada Sesión Virtual 1" de Johan Acosta Ibañez.
 * Enlace: https://www.youtube.com/watch?v=2ZOUapJjgpg&feature=youtu.be
 */

namespace CapaLogicaNegocio
{
    public class ClienteLN
    {
        #region Métodos
        public bool Guardar(Cliente cliente)
        {
            try
            {
                bool yaExisteRegistro = false;

                Cliente[] arregloClientes = ClienteAD.Consultar();

                if (arregloClientes != null)
                {
                    for (int i = 0; i < arregloClientes.Length; i++)
                    {
                        if (arregloClientes[i] != null && arregloClientes[i].Id == cliente.Id)
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
                        return ClienteAD.Guardar(cliente);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente[] Consultar() 
        { 
            return ClienteAD.Consultar();
        }
        #endregion
    }
}
