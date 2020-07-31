using ecommerce.WebASP.Logica;
using System;
using System.Collections.Generic;
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

                    if (_listaCarrito.Count > 0 && _listaCarrito != null)
                    {
                        GdvDetalleCompra.DataSource = _listaCarrito.ToList();
                        GdvDetalleCompra.DataBind();
                    } 
                }
            }
        }
    }
}