
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tarea_net7.Models;

#nullable disable

namespace tarea_net7.Migrations
{
    [DBContext(typeof(Estudiantes_DB))]
    partial class EstudiantesDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tarea_net7.Models.Estudiante", b =>
                {
                    b.Property<int>("Id_Estudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Estudiante"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Carnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo_Electronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Tipo_Sangre")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Estudiante");

                    b.HasIndex("Id_Tipo_Sangre");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("tarea_net7.Models.TipoSangre", b =>
                {
                    b.Property<int>("Id_Tipo_Sangre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Tipo_Sangre"));

                    b.Property<string>("Sangre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Tipo_Sangre");

                    b.ToTable("Tipos_Sangre");
                });

            modelBuilder.Entity("tarea_net7.Models.Estudiante", b =>
                {
                    b.HasOne("tarea_net7.Models.Tipo_Sangre", "Tipo_Sangre")
                        .WithMany()
                        .HasForeignKey("Id_Tipo_Sangre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo_Sangre");
                });
#pragma warning restore 612, 618
        }
    }
}
