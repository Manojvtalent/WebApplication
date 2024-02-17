using System;
using System.ComponentModel.DataAnnotations;

namespace MSMSWEBApi.CustomDataannotations
{
    public class salvalcheck:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int salary=Convert.ToInt32(value);
            if (salary %10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
