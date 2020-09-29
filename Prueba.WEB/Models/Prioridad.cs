using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WEB.Models
{
    public class Prioridad
    {
        public string codigo_prioridad { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}