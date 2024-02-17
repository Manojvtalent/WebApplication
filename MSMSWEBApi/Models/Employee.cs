using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMSWEBApi.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
public int EmpId { get; set; }
        //[Required(ErrorMessage ="please select true or false")]
   
        
        
        public bool Active { get; set; }
        //[Required(ErrorMessage = "Please enter name...!")]
        //[StringLength(15, ErrorMessage = "Please enter only 15 charecters....!")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter Charecters only...!")]

        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter email...!")] 
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter proper email formate...!")]
        public string Email { get; set; }

        public string Password { get; set; }
        public string gender { get; set; }
        ////[Required(ErrorMessage = "Please enter Phone...!")]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter digits only...!")]
        public string phonenumber { get; set; }
        [Required(ErrorMessage = "Please enter salary...!")]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter digits only...!")]
        
        public decimal salary { get; set; }
        [Required(ErrorMessage = "Please enter address...!")]
        public string Address { get; set; }
        [ForeignKey("Department")]
        [Required(ErrorMessage = "Please select department...!")]
        public int DeptNo { get; set; } 
     

    }
}
