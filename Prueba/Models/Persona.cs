namespace Prueba.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string email { get; set; }

        [StringLength(30)]
        public string cedula { get; set; }
    }
}
