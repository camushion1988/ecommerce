using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce.WebASP.Logica
{
    public class clsCarrito
    {
        public int idProducto { get; set; }
        public int cantidadProducto { get; set; }

        public decimal precioProducto { get; set; }
        public string nombreProducto { get; set; }


    }
}