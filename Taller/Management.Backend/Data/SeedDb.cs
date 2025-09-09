using Management.Shared.Entities;
using System.Diagnostics.Metrics;

namespace Management.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEmployeesAsync();
            
        }

        private async Task CheckEmployeesAsync()
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new Employee
                {
                    FirstName = "Andres",
                    LastName = "Gomez",
                    IsActive = true,
                    HireDate = new DateTime(2020, 5, 10),
                    Salary = 1200000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Laura",
                    LastName = "Martinez",
                    IsActive = true,
                    HireDate = new DateTime(2021, 3, 15),
                    Salary = 1500000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Carlos",
                    LastName = "Ramirez",
                    IsActive = true,
                    HireDate = new DateTime(2019, 8, 20),
                    Salary = 2000000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Juliana",
                    LastName = "Torres",
                    IsActive = true,
                    HireDate = new DateTime(2022, 1, 5),
                    Salary = 1800000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Sebastian",
                    LastName = "Lopez",
                    IsActive = true,
                    HireDate = new DateTime(2018, 11, 30),
                    Salary = 2500000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Paola",
                    LastName = "Hernandez",
                    IsActive = false,
                    HireDate = new DateTime(2017, 6, 1),
                    Salary = 1400000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Jorge",
                    LastName = "Castro",
                    IsActive = true,
                    HireDate = new DateTime(2021, 9, 25),
                    Salary = 1750000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Natalia",
                    LastName = "Cabrera",
                    IsActive = true,
                    HireDate = new DateTime(2020, 2, 12),
                    Salary = 2200000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Diego",
                    LastName = "Sanchez",
                    IsActive = true,
                    HireDate = new DateTime(2022, 7, 19),
                    Salary = 1600000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Mariana",
                    LastName = "Suarez",
                    IsActive = true,
                    HireDate = new DateTime(2019, 12, 8),
                    Salary = 2100000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Felipe",
                    LastName = "Rojas",
                    IsActive = true,
                    HireDate = new DateTime(2016, 4, 3),
                    Salary = 3000000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Angela",
                    LastName = "Moreno",
                    IsActive = false,
                    HireDate = new DateTime(2015, 10, 14),
                    Salary = 1350000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Daniel",
                    LastName = "Mejia",
                    IsActive = true,
                    HireDate = new DateTime(2021, 8, 21),
                    Salary = 1850000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Camila",
                    LastName = "Vargas",
                    IsActive = true,
                    HireDate = new DateTime(2018, 1, 18),
                    Salary = 2400000
                });

                _context.Employees.Add(new Employee
                {
                    FirstName = "Ricardo",
                    LastName = "Jimenez",
                    IsActive = true,
                    HireDate = new DateTime(2020, 6, 27),
                    Salary = 1950000
                });

                await _context.SaveChangesAsync();
            }


            await _context.SaveChangesAsync();
        }
    }

}
