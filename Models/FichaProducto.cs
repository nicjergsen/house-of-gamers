using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHouseofg.Models
{
    public class FichaProducto
    {
        public PRODUCTOS producto { get; set; }
        public List<VALORACIONES> valoracion { get; set; }
        public VALORACIONES val { get; set; } 
        public USUARIOS user { get; set; }
        public double prom_val = 0;

    }
}