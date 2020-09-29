using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WEB.Models
{
    public class Estado
    {
        public string codigo_estado { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}