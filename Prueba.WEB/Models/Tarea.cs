using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WEB.Models
{
    public class Tarea
    {
        public int id_tarea { get; set; }
        public Nullable<int> id_colaborador { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public string codigo_estado { get; set; }
        public string codigo_prioridad { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public string nota { get; set; }
    }
}