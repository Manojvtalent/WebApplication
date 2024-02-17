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
    public class EmpController : ControllerBase
    {
        public IEmpRepository Iemprep;
        public EmpController(IEmpRepository _Iemprep)
        {
            this.Iemprep = _Iemprep;
        }
        [Route("InsertEmployees")]
        [HttpPost]
        public async Task<IActionResult>InsertEmployees([FromBody] Employee emp)
        {
            //if (emp.Active == true)
            //{
            try
            {
                var cout = await Iemprep.InsertEmployee(emp);
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
                var Emplist = await Iemprep.GetAll();
                if (Emplist.Count != 0)
                {
                    return Ok(Emplist);
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
        [Route("UpdateEmployee")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee emp)
        {
            //if (emp.Active == true)
            //{
            try
            {
                var cout = await Iemprep.UpdateEmployee(emp);
                return Ok(cout + "record upadate successfully...!");
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
        [Route("DeleteEmployee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            //if (emp.Active == true)
            //{
            try
            {
                var cout = await Iemprep.DeleteEmployee(EmpId);
                return Ok(cout + "record upadate successfully...!");
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
        [Route("GetEmployeeByemailIdandpassword")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByemailIdandpassword(string email, string password)
        {

            try
            {
                var Emplist = await Iemprep.GetEmployeeByemailIdandpassword(email, password);




                return Ok(Emplist);




            }

            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }


        }
        [Route("Getemployeebyemailandactivestatus")]
        [HttpGet]
        public async Task<ActionResult<bool>> Getemployeebyemailandactivestatus(string email)
        {
            try
            {
                var result = await Iemprep.Getemployeebyemailandactivestatus(email);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }


        }
        [Route("GetEmployeeByempId")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByempId(int empId)
        {

            try
            {
                var Emplist = await Iemprep.GetEmployeeById(empId);




                return Ok(Emplist);




            }

            catch (Exception ex)
            {
                return BadRequest("sorry for inconviniance ...!\nWe Will solve the as soon as possible\n" + ex.Message);
            }

        }
    }
}
