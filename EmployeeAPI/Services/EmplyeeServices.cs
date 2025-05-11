using EmployeeAPI.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;


namespace EmployeeAPI.Services
{
    public class EmplyeeServices
    {
        static List<Employee> employeesList { get; }
        static int nextEmpId  = 3;

        static EmplyeeServices()
        {
            employeesList = new List<Employee>{ new Employee { Id = 1, Name = "John Doe", title = "HR", salary = 50000 },
                                                new Employee { Id = 2, Name = "Jane Smith", title = "IT", salary = 60000 }};
        }
        public static List<Employee> GetAllEmployees() => employeesList;
        public static Employee Get ( int id) {
            int index = employeesList.FindIndex(e => e.Id == id);
            if( index == -1 )return null; ;
            return employeesList[index];
        }

        public static void Add( Employee emp)
        {
            emp.Id = nextEmpId++;
            employeesList.Add(emp);
        }

        public static void  Delete ( int id)
        {
            int index = employeesList.FindIndex(e => e.Id == id);
            if (index == -1) return;
            employeesList.RemoveAt(index);
        }
        public static void update (Employee emp)
        {
            int index = employeesList.FindIndex(e => e.Id == emp.Id);
            if (index == -1) return;
            employeesList[index] = emp;
        }

        
    }
}
