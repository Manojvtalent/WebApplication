using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMSWEBApi.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
     public int DeptNo{get; set;}
        public string Dname { get; set;}
        public string location {  get; set;}    
    }
}
