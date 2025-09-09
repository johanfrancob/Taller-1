using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Management.Shared.Entities;


namespace Management.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        //Entidades de la base de datos

        public DbSet<Employee> Employees { get; set; } //Lo que está entre  <> es el nombre de la tabla en la base de datos, lo que le sigue es el apodo de la tabla



        //---------------------------------


        //Condiciones adicionales para las tablas -----------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
           

        }

        //----------------------------------------------------------------
    }
}
