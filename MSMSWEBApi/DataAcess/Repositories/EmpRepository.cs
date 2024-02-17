using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSMSWEBApi.DataAcess.IRepositories;
using MSMSWEBApi.Dbcontext;
using MSMSWEBApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSMSWEBApi.DataAcess.Repositories
{
    public class EmpRepository : IEmpRepository
    {
        public ProjectDbcontext db;
        public EmpRepository(ProjectDbcontext _db)
        {
            this.db = _db;
        }
        public async Task<int> DeleteEmployee(int EmpId)
        {
            var Emp = db.Employees.Find(EmpId);
            db.Employees.Remove(Emp);
            return await db.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<bool> Getemployeebyemailandactivestatus(string Email)
        {
            var employeeexits = await db.Employees.FirstOrDefaultAsync(x => x.Email == Email);
            return employeeexits != null && employeeexits.Active;
        }

        public async Task<Employee> GetEmployeeByemailIdandpassword(string Email, string password)
        {
           
                // Find the employee with the given email and password
                var emp = await db.Employees.FirstOrDefaultAsync(x => x.Email == Email && x.Password == password);

                // If an employee is found, return their email
           
                    return emp;
              
                // If no employee is found, return null
               

            }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            var emp = await db.Employees.FirstOrDefaultAsync(x => x.EmpId == empId);
            return emp;
        }

        public async Task<int> InsertEmployee(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee emp)
        {
            db.Employees.Update(emp);
            return await db.SaveChangesAsync();
        }
    }
}
