using Microsoft.AspNetCore.Mvc;
using MSMSWEBApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSMSWEBApi.DataAcess.IRepositories
{
    public interface IEmpRepository
    {
        Task<List<Employee>> GetAll();
        Task<int> InsertEmployee(Employee emp);
        Task<int> UpdateEmployee(Employee emp);
        Task<int> DeleteEmployee(int EmpId);
        Task<Employee> GetEmployeeById(int EmployeeId);
        Task<Employee> GetEmployeeByemailIdandpassword(string Email, string password);
        Task<bool> Getemployeebyemailandactivestatus(string Email);
    }
}

































