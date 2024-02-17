using Microsoft.EntityFrameworkCore;
using MSMSWEBApi.DataAcess.IRepositories;
using MSMSWEBApi.Dbcontext;
using MSMSWEBApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSMSWEBApi.DataAcess.Repositories
{
    public class DeptRepository : IDeptRepository
    {
        public ProjectDbcontext db;
        public DeptRepository(ProjectDbcontext _db)
        {
            this.db = _db;
        }
        public async Task<List<Department>> Alldepartment()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<int> InsertDepartment(Department Dept)
        {
            await db.Departments.AddAsync(Dept);
            return await db.SaveChangesAsync();
        }
    }
}
