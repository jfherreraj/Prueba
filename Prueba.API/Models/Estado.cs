//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estado
    {
        public Estado()
        {
            this.Tarea = new HashSet<Tarea>();
        }
    
        public string codigo_estado { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}