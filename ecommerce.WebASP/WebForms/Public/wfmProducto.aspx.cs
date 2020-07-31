using ecommerce.WebASP.Logica;
using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.WebASP.WebForms.Public
{
    public partial class wfmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int idProducto = Convert.ToInt32(Request["cod"].ToString());
                    loadProducto(idProducto);
                }
            }
        }

        private void loadProducto(int idProducto)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var task = Task.Run(() => LogicaProducto.getProductXId(idProducto));
            task.Wait();
            _infoProducto = task.Result;
            if (_infoProducto != null)
            {
                imgProducto.ImageUrl = _infoProducto.PRO_IMAGEN;
                lblProducto.Text = _infoProducto.PRO_ID.ToString();
                lblNombre.Text = _infoProducto.PRO_NOMBRE;
                lblDescripcion.Text = _infoProducto.PRO_DESCRIPCION;
                lblPrecio.Text = _infoProducto.PRO_PRECIOVENTA.ToString("0.00");
            }
        }

        protected void btnComprar_Click(object sender, ImageClickEventArgs e)
        {
            List<clsCarrito> _listaCarrito = new List<clsCarrito>();
            _listaCarrito = (List<clsCarrito>)Session["Carrito"];

            clsCarrito _infoProducto = new clsCarrito();
            _infoProducto.idProducto = int.Parse(lblProducto.Text);
            _infoProducto.cantidadProducto = int.Parse(txtCantidad.Text);
            _infoProducto.precioProducto = decimal.Parse(lblPrecio.Text);
            _infoProducto.nombreProducto = lblNombre.Text;

            _listaCarrito.Add(_infoProducto);

            Session["Carrito"] = _listaCarrito;

            Response.Redirect("wfmCatalogo.aspx", true);
        }
    }
}