using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestwithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
   
        // GET api/values/5/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public ActionResult<string> Get(string firstNumber, string secondNumber)
        {
            if(IsNumberic(firstNumber) && IsNumberic(firstNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return sum.ToString();
            }
            
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalNumber;
            if(decimal.TryParse(number, out decimalNumber)) {
                return decimalNumber;
            }
            return 0;
        }

        private bool IsNumberic(string value)
        {
            double number;
            bool isNumber = double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
