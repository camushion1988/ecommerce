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
    public partial class wfmCatalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCatalogo();
            }
        }

        private void loadCatalogo()
        {
            Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
            _taskProductos.Wait();
            var _listaProducto = _taskProductos.Result;

            DataList1.DataSource = _listaProducto.Select(data => new
            {
                ID = data.PRO_ID,
                Nombre = data.PRO_NOMBRE,
                Precio = data.PRO_PRECIOVENTA.ToString("0.00"),
                Url = data.PRO_IMAGEN

            }).ToList();
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Comprar")
            {
                //Encriptar
                Response.Redirect("wfmProducto.aspx?cod=" + codigo, true);
            }
        }
    }
}