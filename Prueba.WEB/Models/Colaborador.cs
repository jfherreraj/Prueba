using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WEB.Models
{
    public class Colaborador
    {
        public int id_colaborador { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}