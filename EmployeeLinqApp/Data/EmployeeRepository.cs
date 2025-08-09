using EmployeeLinqApp.Models;

namespace EmployeeLinqApp.Data
{
    public static class EmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice Johnson", Department = "HR", Salary = 50000, HireDate = new DateTime(2020, 3, 1) },
            new Employee { Id = 2, Name = "Bob Smith", Department = "IT", Salary = 65000, HireDate = new DateTime(2019, 7, 15) },
            new Employee { Id = 3, Name = "Charlie Davis", Department = "Finance", Salary = 70000, HireDate = new DateTime(2018, 1, 20) },
            new Employee { Id = 4, Name = "Diana Brown", Department = "IT", Salary = 80000, HireDate = new DateTime(2021, 5, 10) },
            new Employee { Id = 5, Name = "Edward Wilson", Department = "HR", Salary = 55000, HireDate = new DateTime(2022, 9, 5) }
        };

        public static List<Employee> GetAll() => _employees;

        public static Employee GetById(int id) =>
            _employees.FirstOrDefault(e => e.Id == id);

        public static void Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
        }

        public static void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Department = employee.Department;
                existing.Salary = employee.Salary;
                existing.HireDate = employee.HireDate;
            }
        }

        public static void Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null) _employees.Remove(emp);
        }
    }
}
