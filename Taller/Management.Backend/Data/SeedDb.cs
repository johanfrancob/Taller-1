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

                _context.Employees.Add(new Employee { FirstName = "Sofia", LastName = "Delgado", IsActive = true, HireDate = new DateTime(2017, 2, 14), Salary = 1650000 });
                _context.Employees.Add(new Employee { FirstName = "Mauricio", LastName = "Pardo", IsActive = true, HireDate = new DateTime(2019, 3, 22), Salary = 1900000 });
                _context.Employees.Add(new Employee { FirstName = "Valentina", LastName = "Restrepo", IsActive = true, HireDate = new DateTime(2020, 9, 1), Salary = 1750000 });
                _context.Employees.Add(new Employee { FirstName = "Santiago", LastName = "Aguirre", IsActive = true, HireDate = new DateTime(2018, 7, 11), Salary = 2050000 });
                _context.Employees.Add(new Employee { FirstName = "Liliana", LastName = "Castaño", IsActive = false, HireDate = new DateTime(2016, 11, 5), Salary = 1420000 });
                _context.Employees.Add(new Employee { FirstName = "Camilo", LastName = "Ospina", IsActive = true, HireDate = new DateTime(2021, 4, 18), Salary = 2000000 });
                _context.Employees.Add(new Employee { FirstName = "Monica", LastName = "Salinas", IsActive = true, HireDate = new DateTime(2017, 8, 29), Salary = 1850000 });
                _context.Employees.Add(new Employee { FirstName = "Fabian", LastName = "Cardenas", IsActive = true, HireDate = new DateTime(2019, 1, 30), Salary = 2150000 });
                _context.Employees.Add(new Employee { FirstName = "Luz Marina", LastName = "Patiño", IsActive = false, HireDate = new DateTime(2015, 5, 25), Salary = 1380000 });
                _context.Employees.Add(new Employee { FirstName = "Oscar", LastName = "Beltran", IsActive = true, HireDate = new DateTime(2022, 10, 9), Salary = 1950000 });
                _context.Employees.Add(new Employee { FirstName = "Carolina", LastName = "Rivera", IsActive = true, HireDate = new DateTime(2018, 3, 17), Salary = 2080000 });
                _context.Employees.Add(new Employee { FirstName = "Juan", LastName = "Perez", IsActive = true, HireDate = new DateTime(2016, 6, 6), Salary = 1500000 });
                _context.Employees.Add(new Employee { FirstName = "Daniela", LastName = "Ortiz", IsActive = true, HireDate = new DateTime(2020, 12, 12), Salary = 1800000 });
                _context.Employees.Add(new Employee { FirstName = "Miguel", LastName = "Herrera", IsActive = true, HireDate = new DateTime(2019, 9, 3), Salary = 2200000 });
                _context.Employees.Add(new Employee { FirstName = "Tatiana", LastName = "Roldan", IsActive = true, HireDate = new DateTime(2018, 2, 22), Salary = 2050000 });
                _context.Employees.Add(new Employee { FirstName = "Cristian", LastName = "Morales", IsActive = true, HireDate = new DateTime(2021, 5, 7), Salary = 1900000 });
                _context.Employees.Add(new Employee { FirstName = "Veronica", LastName = "Molina", IsActive = false, HireDate = new DateTime(2017, 12, 19), Salary = 1450000 });
                _context.Employees.Add(new Employee { FirstName = "Hector", LastName = "Zamora", IsActive = true, HireDate = new DateTime(2016, 3, 28), Salary = 2400000 });
                _context.Employees.Add(new Employee { FirstName = "Melissa", LastName = "Arias", IsActive = true, HireDate = new DateTime(2022, 1, 26), Salary = 1850000 });
                _context.Employees.Add(new Employee { FirstName = "Pedro", LastName = "Alvarez", IsActive = true, HireDate = new DateTime(2015, 9, 14), Salary = 1550000 });
                _context.Employees.Add(new Employee { FirstName = "Sara", LastName = "Lozano", IsActive = true, HireDate = new DateTime(2020, 4, 30), Salary = 2100000 });
                _context.Employees.Add(new Employee { FirstName = "Esteban", LastName = "Quintero", IsActive = true, HireDate = new DateTime(2019, 11, 21), Salary = 2000000 });
                _context.Employees.Add(new Employee { FirstName = "Manuela", LastName = "Valencia", IsActive = true, HireDate = new DateTime(2018, 5, 13), Salary = 2300000 });
                _context.Employees.Add(new Employee { FirstName = "Victor", LastName = "Rangel", IsActive = true, HireDate = new DateTime(2017, 7, 4), Salary = 1950000 });
                _context.Employees.Add(new Employee { FirstName = "Karen", LastName = "Figueroa", IsActive = false, HireDate = new DateTime(2021, 10, 15), Salary = 1600000 });
                _context.Employees.Add(new Employee { FirstName = "Vanessa", LastName = "Blanco", IsActive = true, HireDate = new DateTime(2016, 1, 19), Salary = 1750000 });
                _context.Employees.Add(new Employee { FirstName = "Hernan", LastName = "Duarte", IsActive = true, HireDate = new DateTime(2022, 7, 27), Salary = 2050000 });
                _context.Employees.Add(new Employee { FirstName = "Pablo", LastName = "Barrera", IsActive = true, HireDate = new DateTime(2015, 3, 10), Salary = 1800000 });
                _context.Employees.Add(new Employee { FirstName = "Lina", LastName = "Gallego", IsActive = true, HireDate = new DateTime(2020, 8, 2), Salary = 2150000 });
                _context.Employees.Add(new Employee { FirstName = "Hugo", LastName = "Serrano", IsActive = true, HireDate = new DateTime(2019, 4, 6), Salary = 2200000 });
                _context.Employees.Add(new Employee { FirstName = "Gloria", LastName = "Muñoz", IsActive = false, HireDate = new DateTime(2017, 10, 23), Salary = 1500000 });
                _context.Employees.Add(new Employee { FirstName = "Ruben", LastName = "Parra", IsActive = true, HireDate = new DateTime(2016, 12, 1), Salary = 2000000 });
                _context.Employees.Add(new Employee { FirstName = "Simon", LastName = "Salas", IsActive = true, HireDate = new DateTime(2018, 9, 9), Salary = 1850000 });
                _context.Employees.Add(new Employee { FirstName = "Eliana", LastName = "Correa", IsActive = true, HireDate = new DateTime(2021, 2, 2), Salary = 1900000 });
                _context.Employees.Add(new Employee { FirstName = "Leandro", LastName = "Naranjo", IsActive = true, HireDate = new DateTime(2015, 11, 18), Salary = 2100000 });
                _context.Employees.Add(new Employee { FirstName = "Yesenia", LastName = "Rios", IsActive = true, HireDate = new DateTime(2019, 6, 28), Salary = 1700000 });
                _context.Employees.Add(new Employee { FirstName = "Matias", LastName = "Prieto", IsActive = true, HireDate = new DateTime(2020, 3, 5), Salary = 2050000 });
                _context.Employees.Add(new Employee { FirstName = "Brenda", LastName = "Salgado", IsActive = true, HireDate = new DateTime(2018, 12, 31), Salary = 1950000 });
                _context.Employees.Add(new Employee { FirstName = "Emilio", LastName = "Cifuentes", IsActive = true, HireDate = new DateTime(2017, 4, 12), Salary = 2250000 });
                _context.Employees.Add(new Employee { FirstName = "Noelia", LastName = "Montoya", IsActive = false, HireDate = new DateTime(2022, 11, 3), Salary = 1600000 });
                _context.Employees.Add(new Employee { FirstName = "Alvaro", LastName = "Gaitan", IsActive = true, HireDate = new DateTime(2016, 8, 16), Salary = 2350000 });
                _context.Employees.Add(new Employee { FirstName = "Nicole", LastName = "Pineda", IsActive = true, HireDate = new DateTime(2019, 2, 8), Salary = 1750000 });
                _context.Employees.Add(new Employee { FirstName = "Gabriel", LastName = "Caicedo", IsActive = true, HireDate = new DateTime(2021, 6, 20), Salary = 2000000 });
                _context.Employees.Add(new Employee { FirstName = "Martin", LastName = "Ibanez", IsActive = true, HireDate = new DateTime(2015, 7, 7), Salary = 2450000 });
                _context.Employees.Add(new Employee { FirstName = "Ximena", LastName = "Camacho", IsActive = true, HireDate = new DateTime(2020, 1, 15), Salary = 1850000 });


                await _context.SaveChangesAsync();
            }






            await _context.SaveChangesAsync();
        }
    }

}
