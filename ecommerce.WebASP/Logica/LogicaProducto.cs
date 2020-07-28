using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ecommerce.WebASP.Logica
{
    public class LogicaProducto
    {
        private static BDDCORDICARRITOEntities db = new BDDCORDICARRITOEntities();

        public static async Task<List<TBL_PRODUCTO>> getAllProduct()
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXId(int codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                && data.PRO_ID.Equals(codigo)
                ).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXCode(string codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                && data.PRO_CODIGO.Equals(codigo)
                ).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO _infoPRODUCTO)
        {
            try
            {
                //auditoria basica
                bool resultado = false;
                _infoPRODUCTO.PRO_STATUS = "A";
                _infoPRODUCTO.PRO_FECHACREACION = DateTime.Now;
                db.TBL_PRODUCTO.Add(_infoPRODUCTO);

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al guardar producto");
            }
        }

        public static async Task<bool> updateProduct(TBL_PRODUCTO _infoPRODUCTO)
        {
            try
            {
                bool resultado = false;
                _infoPRODUCTO.PRO_FECHACREACION = DateTime.Now;

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }

        public static async Task<bool> deleteProduct(TBL_PRODUCTO _infoPRODUCTO)
        {
            try
            {
                bool resultado = false;
                _infoPRODUCTO.PRO_FECHACREACION = DateTime.Now;
                _infoPRODUCTO.PRO_STATUS = "I";

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }
    }
}