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
                lblNombre.Text = _infoProducto.PRO_NOMBRE;
                lblDescripcion.Text = _infoProducto.PRO_DESCRIPCION;
                lblPrecio.Text = _infoProducto.PRO_PRECIOVENTA.ToString("0.00");

                //LblId.Text = _infoProducto.PRO_ID.ToString();
                //txtCodigo.Text = _infoProducto.PRO_CODIGO;
                //UC_Categoria1.DropDownList.SelectedValue = _infoProducto.CAT_ID.ToString();
                //txtNombre.Text = _infoProducto.PRO_NOMBRE;
                //txtDescripcion.Text = _infoProducto.PRO_DESCRIPCION;
                //txtPrecioCompra.Text = _infoProducto.PRO_PRECIOCOMPRA.ToString();
                //txtPrecioVenta.Text = _infoProducto.PRO_PRECIOVENTA.ToString();
                //txtStockMinimo.Text = _infoProducto.PRO_STOCKMINIMO.ToString();
                //txtStockMaximo.Text = _infoProducto.PRO_STOCKMAXIMO.ToString();
            }
        }
    }
}