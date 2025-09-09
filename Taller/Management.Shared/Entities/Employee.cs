using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Shared.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(100, ErrorMessage = "El Apellido no puede superar los 100 caracteres")]
        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string LastName { get; set; }
        public DateTime HireDate { get; set; } 
        public bool IsActive { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(1000000, double.MaxValue, ErrorMessage = "El salario debe minimo es de $1'000.000")]
        public decimal Salary { get; set; }

    }
}
