using MSMSWEBApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSMSWEBApi.DataAcess.IRepositories
{
    public interface IDeptRepository
    {
        Task<List<Department>> Alldepartment();
        Task<int> InsertDepartment(Department Dept);


    }
}
