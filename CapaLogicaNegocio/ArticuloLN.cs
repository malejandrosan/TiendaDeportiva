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
 * Fecha: 06/10/2024
 * 
 * Esta clase está inspirada en el modelo de capas explicado en el video
 * 0830 Programación Avanzada Sesión Virtual 1" de Johan Acosta Ibañez.
 * Enlace: https://www.youtube.com/watch?v=2ZOUapJjgpg&feature=youtu.be
 */

namespace CapaLogicaNegocio
{
    public class ArticuloLN
    {
        #region Métodos
        // <summary>
        // Guarda el objeto en caso de que no haya un duplicado
        // Retorna True cuando se guarda satisfactoriamente
        // Retorna False cuando ya está registrado
        // <summary>
        public bool Guardar(Articulo articulo)
        {
            try
            {
                bool yaExisteRegistro = false;
                Articulo[] arregloArticulos = ArticuloAD.Consultar();

                if (arregloArticulos != null)
                {
                    for (int i = 0; i < arregloArticulos.Length; i++) 
                    { 
                        if (arregloArticulos[i] != null && arregloArticulos[i].Id == articulo.Id)
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
                        return ArticuloAD.Guardar(articulo);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Articulo[] Consultar()
        {
            return ArticuloAD.Consultar();
        }

        // <summary>
        // Consulta y retorna el objeto Articulo existente con el nombre dado de parámetro
        // <summary>
        public Articulo Consultar(int id)
        {
            try
            {
                Articulo[] arregloArticulos = ArticuloAD.Consultar();

                if (arregloArticulos != null)
                {
                    for (int i = 0; i < arregloArticulos.Length; i++)
                    {
                        if (arregloArticulos[i] != null && arregloArticulos[i].Id == id)
                        {
                            return arregloArticulos[i];
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


        // <summary>
        // Retorna arreglo Articulo con solo los articulos activos
        // <summary>
        public Articulo[] ConsultarActivos()
        {
            Articulo[] arregloArticulos = ArticuloAD.Consultar();
            int cantidadActivos = ContarArticulosActivos();
            Articulo[] arregloArticulosActivos = new Articulo[cantidadActivos];
            int indice = 0;

            for (int i = 0; i < arregloArticulos.Length; i++)
            {
                if (arregloArticulos[i] != null && arregloArticulos[i].Activo)
                {
                    arregloArticulosActivos[indice] = arregloArticulos[i];
                    indice++;
                }
            }
            return arregloArticulosActivos;
        }


        // <summary>
        // Retorna un entero con la cantidad de articulos activos
        // <summary>
        public int ContarArticulosActivos()
        {
            Articulo[] arregloArticulos = ArticuloAD.Consultar();
            int contador = 0;

            foreach (Articulo articulo in arregloArticulos)
            {
                if (articulo != null && articulo.Activo)
                {
                    contador++;
                }
            }
            return contador;
        }
        #endregion

    }
}
