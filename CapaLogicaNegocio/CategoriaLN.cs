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
    public class CategoriaLN
    {
        #region Métodos
        // <summary>
        // Guarda el objeto en caso de que no haya un duplicado
        // Retorna True cuando se guarda satisfactoriamente
        // Retorna False cuando ya está registrado
        // <summary>
        public bool Guardar(Categoria categoria)
        {
            try
            {
                bool yaRegistroExiste = false;
                Categoria[] arregloCategorias = CategoriaAD.Consultar();

                if (arregloCategorias != null)
                {
                    for (int i = 0; i < arregloCategorias.Length; i++) 
                    { 
                        if (arregloCategorias[i] != null && arregloCategorias[i].Id == categoria.Id)
                        {
                            yaRegistroExiste = true;
                        }
                    }
                    if (yaRegistroExiste)
                    {
                        return false;
                    }
                    else
                    {
                        return CategoriaAD.Guardar(categoria);
                    }
                }
                return false;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }


        public Categoria[] Consultar()
        {
            return CategoriaAD.Consultar();
        }


        // <summary>
        // Consulta y retorna el objeto Categoria existente con el nombre dado de parámetro
        // <summary>
        public Categoria Consultar(string nombre)
        {
            try
            {
                Categoria[] arregloCategorias = CategoriaAD.Consultar();
                
                if (arregloCategorias != null)
                {
                    for (int i = 0; i < arregloCategorias.Length; i++)
                    {
                        if (arregloCategorias[i] != null && arregloCategorias[i].Nombre.Equals(nombre))
                        {
                            return arregloCategorias[i];
                        }
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
