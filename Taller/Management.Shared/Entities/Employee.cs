using Management.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Shared.Entities
{
    public class Employee : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(30, ErrorMessage = "El nombre no puede superar los 30 caracteres")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(30, ErrorMessage = "El Apellido no puede superar los 30 caracteres")]
        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Fecha de contratación")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(1000000, double.MaxValue, ErrorMessage = "El salario debe ser minimo de $1'000.000")]
        public decimal Salary { get; set; }

    }
}
