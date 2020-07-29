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
                LblId.Text = _infoProducto.PRO_ID.ToString();
                txtCodigo.Text = _infoProducto.PRO_CODIGO;
                UC_Categoria1.DropDownList.SelectedValue = _infoProducto.CAT_ID.ToString();
                txtNombre.Text = _infoProducto.PRO_NOMBRE;
                txtDescripcion.Text = _infoProducto.PRO_DESCRIPCION;
                txtPrecioCompra.Text = _infoProducto.PRO_PRECIOCOMPRA.ToString();
                txtPrecioVenta.Text = _infoProducto.PRO_PRECIOVENTA.ToString();
                txtStockMinimo.Text = _infoProducto.PRO_STOCKMINIMO.ToString();
                txtStockMaximo.Text = _infoProducto.PRO_STOCKMAXIMO.ToString();
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
                //_infoProducto.PRO_ID = 100;
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
                    newProduct();
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }

        }

        private void updateProduct()
        {
            try
            {
                //validacion
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                //verificar si el producto existe
                var taskProducto = Task.Run(() => LogicaProducto.getProductXId(int.Parse(LblId.Text)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;

                if (_infoProducto != null)
                {
                    _infoProducto.PRO_ID = int.Parse(LblId.Text);
                    _infoProducto.CAT_ID = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                    _infoProducto.PRO_CODIGO = txtCodigo.Text;
                    _infoProducto.PRO_NOMBRE = txtNombre.Text;
                    _infoProducto.PRO_DESCRIPCION = txtDescripcion.Text;
                    _infoProducto.PRO_IMAGEN = "C:/imagen";
                    _infoProducto.PRO_PRECIOCOMPRA = Convert.ToDecimal(txtPrecioCompra.Text);
                    _infoProducto.PRO_PRECIOVENTA = Convert.ToDecimal(txtPrecioVenta.Text);
                    _infoProducto.PRO_STOCKMINIMO = Convert.ToInt32(txtStockMinimo.Text);
                    _infoProducto.PRO_STOCKMAXIMO = Convert.ToInt32(txtStockMaximo.Text);

                    Task<bool> _taskSaveProduct = Task.Run(() => LogicaProducto.updateProduct(_infoProducto));
                    _taskSaveProduct.Wait();
                    var resultado = _taskSaveProduct.Result;

                    if (resultado)
                    {
                        LblMensaje.Text = "Registro Modificado Correctamente";
                        Response.Redirect("wfmProductoLista.aspx", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }

        }

        protected void LnkGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LblId.Text))
            {
                updateProduct(); 
            }
            else
            {
                saveProduct();
            }
        }

        protected void ImgGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(LblId.Text))
            {
                updateProduct();
            }
            else
            {
                saveProduct();
            }
        }
    }
}