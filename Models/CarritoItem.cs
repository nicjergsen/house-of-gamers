using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHouseofg.Models
{
    public class CarritoItem
    {
        public PRODUCTOS producto { get; set; }
        public int cantidad { get; set; }
        public PEDIDOS pedido { get; set; }
        public String usuario { get; set; }

        public CarritoItem()
        {
        }

        public CarritoItem(PRODUCTOS prod, int cant)
        {
            this.producto = prod;
            this.cantidad = cant;
        }

    }
}