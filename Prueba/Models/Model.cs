namespace Prueba.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ctx")
        {
        }

        public virtual DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .Property(e => e.cedula)
                .IsFixedLength();
        }
    }
}
