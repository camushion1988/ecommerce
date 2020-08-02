using ecommerce.WebASP.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.WebASP.WebForms.Public
{
    public partial class wfmDetCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Carrito"] != null)
                {
                    List<clsCarrito> _listaCarrito = new List<clsCarrito>();
                    _listaCarrito = (List<clsCarrito>)Session["Carrito"];
                    loadCarrito(_listaCarrito);
                }
            }
        }

        private void loadCarrito(List<clsCarrito> _listaCarrito)
        {
            //validacion de carrito vacio
            if (_listaCarrito.Count > 0 && _listaCarrito != null)
            {
                //declarar variables
                int contador = 1;
                decimal subtotal = 0;
                decimal iva0 = 0;
                decimal iva12 = 0;
                decimal total = 0;

                foreach (var item in _listaCarrito)
                {
                    item.numeroProducto = contador;
                    item.valorTotal = item.precioProducto * item.cantidadProducto;
                    subtotal = subtotal + item.valorTotal;
                    contador++;
                }
                //atencion uso de (,) o (.)
                iva12 = (subtotal * Convert.ToDecimal("0,12"));
                total = subtotal + iva12;

                if (_listaCarrito.Count > 0 && _listaCarrito != null)
                {
                    GdvDetalleCompra.DataSource = _listaCarrito.Select(data => new
                    {
                        No = data.numeroProducto,
                        Codigo = data.codigoProducto,
                        Cantidad = data.cantidadProducto,
                        Producto = data.nombreProducto,
                        Precio = data.precioProducto,
                        Valor_Total = data.valorTotal
                    }).ToList();

                    GdvDetalleCompra.DataBind();
                }

                lblSutt.Text = subtotal.ToString("0.00");
                lblIva12.Text = iva12.ToString("0.00");
                lblTotal.Text = total.ToString("0.00"); 
            }
        }
    }
}