using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSMSWEBApi.DataAcess.IRepositories;
using MSMSWEBApi.Models;
using System.Threading.Tasks;
using System;

namespace MSMSWEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        public IDeptRepository IDeptrep;
        public DeptController(IDeptRepository _IDeptrep)
        {
            this.IDeptrep= _IDeptrep;
        }
        [Route("InsertDepartment")]
        [HttpPost]
        public async Task<IActionResult> InsertDepartment([FromBody] Department dept)
        {
            //if (emp.Active == true)
            //{
            try
            {
                var cout = await IDeptrep.InsertDepartment(dept);
                return Ok(cout + "record Insert successfully...!");
            }
            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }
            //}
            //else
            //{
            //    return BadRequest("sorry for inconviniance....!\n this employee Id is not Active");
            //}
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //if (emp.Active==true)
            //{
            try
            {
                var DepList = await IDeptrep.Alldepartment();
                if (DepList.Count != 0)
                {
                    return Ok(DepList);
                }
                else
                {
                    return NotFound("there is no data available in the database table...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }
            // }
            //else
            //{
            //    return BadRequest("sorry for inconviniance....!\n this employee Id is not Active");
            //}
        }
    }
}
