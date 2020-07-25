using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ecommerce.WebASP.Logica
{
    public class LogicaCategoria
    {
        private static BDDCORDICARRITOEntities db = new BDDCORDICARRITOEntities();

        public static async Task<List<TBL_CATEGORIA>> getAllCategory()
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.CAT_STATUS == "A"
                ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<TBL_CATEGORIA> getCategoryXId(int codigo)
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.CAT_STATUS == "A"
                && data.CAT_ID.Equals(codigo)
                ).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<bool> saveProduct(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                //auditoria basica
                bool resultado = false;
                _infoCategoria.CAT_STATUS = "A";
                _infoCategoria.CAT_FECHACREACION = DateTime.Now;
                db.TBL_CATEGORIA.Add(_infoCategoria);

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<bool> updateProduct(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.CAT_FECHACREACION = DateTime.Now;

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<bool> deleteProduct(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.CAT_FECHACREACION = DateTime.Now;
                _infoCategoria.CAT_STATUS = "I";

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }
    }
}