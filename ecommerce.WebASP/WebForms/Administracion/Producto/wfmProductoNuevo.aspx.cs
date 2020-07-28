using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ecommerce.WebASP.Models;
using ecommerce.WebASP.Logica;
using System.Threading.Tasks;

namespace ecommerce.WebASP.WebForms.Administracion.Producto
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private void newProduct()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStockMaximo.Text = "";
            txtStockMinimo.Text = "";
            UC_Categoria1.DropDownList.SelectedIndex = 0;
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            newProduct();
        }

        protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
        {
            newProduct();
        }

        private void saveProduct()
        {
            try
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                _infoProducto.PRO_ID = 100;
                _infoProducto.CAT_ID = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                _infoProducto.PRO_CODIGO = txtCodigo.Text;
                _infoProducto.PRO_NOMBRE = txtNombre.Text;
                _infoProducto.PRO_DESCRIPCION = txtDescripcion.Text;
                _infoProducto.PRO_IMAGEN = "C:/imagen";
                _infoProducto.PRO_PRECIOCOMPRA = Convert.ToDecimal(txtPrecioCompra.Text);
                _infoProducto.PRO_PRECIOVENTA = Convert.ToDecimal(txtPrecioVenta.Text);
                _infoProducto.PRO_STOCKMINIMO = Convert.ToInt32(txtStockMinimo.Text);
                _infoProducto.PRO_STOCKMAXIMO = Convert.ToInt32(txtStockMaximo.Text);

                Task<bool> _taskSaveProduct = Task.Run(() => LogicaProducto.saveProduct(_infoProducto));
                _taskSaveProduct.Wait();
                var resultado = _taskSaveProduct.Result;

                if (resultado)
                {
                    LblMensaje.Text = "Registro Guardado Correctamente";
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
            
        }

        protected void LnkGuardar_Click(object sender, EventArgs e)
        {
            saveProduct();
        }

        protected void ImgGuardar_Click(object sender, ImageClickEventArgs e)
        {
            saveProduct();
        }
    }
}