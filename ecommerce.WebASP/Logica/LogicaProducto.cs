using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

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

        public static async Task<List<TBL_PRODUCTO>> searchProductXCode(string codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                && data.PRO_CODIGO.StartsWith(codigo)
                ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }

        public static async Task<List<TBL_PRODUCTO>> searchProductXNombre(string nombre)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                && data.PRO_NOMBRE.StartsWith(nombre)
                ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el producto");
            }
        }

        public static async Task<List<TBL_PRODUCTO>> searchProductXCategoria(string categoria)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                && data.TBL_CATEGORIA.CAT_NOMBRE.StartsWith(categoria)
                ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productoS");
            }
        }

        //generar secuencia por programacion
        public static int getNextSequence()
        {
            var query = db.Database.SqlQuery<int>("SELECT NEXT VALUE FOR sq_ProductoId");
            var task = query.SingleAsync();
            int valorSequence = task.Result;
            return valorSequence;
        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO _infoPRODUCTO)
        {
            try
            {
                //auditoria basica
                bool resultado = false;

                //genera secuencia
                _infoPRODUCTO.PRO_ID = getNextSequence();
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