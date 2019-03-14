using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHouseofg.Models
{
    public class Historial
    {
        public PRODUCTOS producto { get; set; }
        public DETALLES detalle { get; set; }
        public PEDIDOS pedido { get; set; }
    }
}