using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using tarea_net7.Models;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace tarea_net7.Models
{
    public class DB_Estudiantes : DBContext
    {
        public DB_Estudiantes(DBContextOptions<DB_Estudiantes> options) : base (options)
        {
        }

        public DBSet<Estudiante> Estudiantes { get; set; }
        public DBSet<TipoSangre> TiposSangre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.TipoSangre)
                .WithMany()
                .HasForeignKey(e => e.IdTipoSangre);
        }
    }

    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public required string Carnet { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Correo { get; set; }
        public int Id_Tipo_Sangre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }

        // Propiedad de navegación para la relación con TipoSangre
        public required TipoSangre TipoSangre { get; set; }
    }

    public class TipoSangre
    {
        [Key]
        public int Id_Tipo_Sangre { get; set; }
        public required string Sangre { get; set; }
    }


}
