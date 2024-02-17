using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserwebApiController : Controller
    {
        private IConfiguration configuration;
        public UserwebApiController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        DataTable dtd;
        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var userList = new List<UsersD>();
            var connectionString = this.configuration.GetConnectionString("Constr");
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("select * from UsersD", conn);
                try
                {
                    await conn.OpenAsync();
                    using (var ad = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        ad.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            var User = new UsersD();
                            User.UserId = Convert.ToInt32(row["userId"]);
                            User.UserName = row["userName"].ToString();
                            User.email = row["email"].ToString();
                            User.password = row["password"].ToString();
                            User.phoneno = row["phoneno"].ToString();
                            return Json(User);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                }
            }
            return Json(userList);
        }
        [Route("Getemailandpassword")]
        [HttpGet]
        public  JsonResult FindByParams(string email, string password)
        {
           
            var  connString = new SqlConnection(this.configuration.GetConnectionString("Constr"));
           var dtb = new DataTable();
           var cmd = new SqlCommand("select * from  where UsersD where email='" +email+ "'and paassword='"+password+"'", connString);
            try
            {
                connString.OpenAsync();
               var adap = new SqlDataAdapter(cmd);
                adap.Fill(dtb);
                if (dtb.Rows.Count > 0)
                {
                    return Json(dtb);
                }
                else
                    return Json("Not Found!");
            }
            catch (Exception ef)
            {
                return Json(StatusCodes.Status500InternalServerError, ef.Message);
            }
            finally { connString.Close(); }
        }
    }

}
        //[Route("GetEmailAndPassword")]
        //[HttpGet]
        //public async Task<IActionResult> GetEmailAndPassword(string email, string password)
        //{
        //    var connectionString = this.configuration.GetConnectionString("Constr");
        //    using (var conn = new SqlConnection(connectionString))
        //    {
        //        var cmd = new SqlCommand("select * from UsersD where email=@email and password=@password", conn);
        //        cmd.Parameters.AddWithValue("@email", email);
        //        cmd.Parameters.AddWithValue("@password", password);
        //        try
        //        {
        //            await conn.OpenAsync();
        //            using (var ad = new SqlDataAdapter(cmd))
        //            {
        //                var dt = new DataTable();
        //                ad.Fill(dt);
        //                if (dt.Rows.Count > 0)
        //                {
        //                    return Json(dt.Rows[0]);
        //                }
        //                else
        //                {
        //                    return Json("Not Found!");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return Json(ex.Message);
        //        }
        //        finally { conn.Close(); }
        //    }
        //}
   

