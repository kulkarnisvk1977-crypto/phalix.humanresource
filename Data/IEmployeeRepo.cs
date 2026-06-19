using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResource.Models;

namespace HumanResource.Data
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task<IEnumerable<Employee>> GetEmployeesByDepartment(string department);
    }
}
