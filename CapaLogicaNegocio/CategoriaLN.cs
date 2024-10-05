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
 */

namespace CapaLogicaNegocio
{
    public class CategoriaLN
    {
        #region Métodos
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
        #endregion
    }
}
