using ecommerce.WebASP.Logica;
using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.WebASP.WebForms.Administracion.Producto
{
    public partial class wfmProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                _taskProductos.Wait();
                var _listaProducto = _taskProductos.Result;
                loadProductos(_listaProducto);
            }
            UC_DatosEventos();
        }

        //llamar a todos los eventos que tenga el gridview
        private void UC_DatosEventos()
        {
            //instanciar gridview
            GridView gridview = (GridView)this.UC_Datos1.FindControl("GridView1");
            gridview.RowCommand += new GridViewCommandEventHandler(Uc_Datos_RowCommand);

            //poder instanciar eventos que tengamos en el uc

        }

        //forma independiente
        //1ra forma
        void Uc_Datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                //Encriptar
                Response.Redirect("wfmProductoNuevo.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "Eliminar")
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => LogicaProducto.getProductXId(int.Parse(codigo)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;
                if (_infoProducto != null)
                {
                    Task<bool> _taskSaveProduct = Task.Run(() => LogicaProducto.deleteProduct(_infoProducto));
                    _taskSaveProduct.Wait();
                    var resultado = _taskSaveProduct.Result;

                    if (resultado)
                    {
                        Response.Write("<script>alert('Registro Eliminado Correctamente')</script>");

                        Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                        _taskProductos.Wait();
                        var _listaProducto = _taskProductos.Result;
                        loadProductos(_listaProducto);
                    }
                }
            }
        }

        private void loadProductos(List<TBL_PRODUCTO> _listaProducto)
        {
            if (_listaProducto != null && _listaProducto.Count > 0)
            {
                //UC_Datos1.loadData(_listaProducto.ToList());
                UC_Datos1.loadData(_listaProducto.Select(data => new
                {
                    ID = data.PRO_ID,
                    CODIGO = data.PRO_CODIGO,
                    NOMBRE = data.PRO_NOMBRE,
                    PRECIO_C = data.PRO_PRECIOCOMPRA.ToString("0.00"),
                    PRECIO_V = data.PRO_PRECIOVENTA.ToString("0.00"),
                    STOCK_MIN = data.PRO_STOCKMINIMO,
                    STOCK_MAX = data.PRO_STOCKMAXIMO,
                    //MOSTRAR CATEGORIA EN PRODUCTOLISTA
                    CATEGORIA = data.TBL_CATEGORIA.CAT_NOMBRE,
                    ESTADO = data.PRO_STATUS
                }).ToList());
            }
        }

        protected void imbBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Buscar(ddlBuscar.SelectedValue);
        }

        private void Buscar(string op)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                List<TBL_PRODUCTO> _listaProducto = new List<TBL_PRODUCTO>();
                string datoaBuscar = txtBuscar.Text;


                switch (op)
                {
                    case "T":
                        Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                        _taskProductos.Wait();
                        _listaProducto = _taskProductos.Result;
                        loadProductos(_listaProducto);
                        break;

                    case "C":
                        Task<List<TBL_PRODUCTO>> _taskProductos2 = Task.Run(() => LogicaProducto.searchProductXCode(datoaBuscar));
                        _taskProductos2.Wait();
                        _listaProducto = _taskProductos2.Result;
                        loadProductos(_listaProducto);
                        break;

                    case "N":
                        Task<List<TBL_PRODUCTO>> _taskProductos3 = Task.Run(() => LogicaProducto.searchProductXNombre(datoaBuscar));
                        _taskProductos3.Wait();
                        _listaProducto = _taskProductos3.Result;
                        loadProductos(_listaProducto);
                        break;

                    case "Ca":
                        Task<List<TBL_PRODUCTO>> _taskProductos4 = Task.Run(() => LogicaProducto.searchProductXCategoria(datoaBuscar));
                        _taskProductos4.Wait();
                        _listaProducto = _taskProductos4.Result;
                        loadProductos(_listaProducto);
                        break;
                }
            }
        }

        private void nuevoProduct()
        {
            Response.Redirect("wfmProductoNuevo.aspx", true);
        }
        protected void imbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            nuevoProduct();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            nuevoProduct();
        }
    }
}