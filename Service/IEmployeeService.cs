using Domain.Models;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Service
{
    public interface IEmployeeService
    {
        // Get All Records
        List<Domain.ViewModels.GetAllEmployeeData> GetEmployees();
       
        // Get Single 
        Employee GetSingleEmployee(int id);

        // Add Employee
        List<Employee> AddEmployee(Employee employee);
        // Update
        List<Employee> UpdateEmployee(Employee employee);
        // Delete
        int DeleteEmployee(int id);

       
    }
}
