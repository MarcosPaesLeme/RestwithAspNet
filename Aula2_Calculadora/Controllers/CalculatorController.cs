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
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if(IsNumberic(firstNumber) && IsNumberic(firstNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        // GET api/values/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secondNumber)
        {
            if(IsNumberic(firstNumber) && IsNumberic(firstNumber)) {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firstNumber, string secondNumber)
        {
            if(IsNumberic(firstNumber) && IsNumberic(firstNumber)) {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("multiple/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Multiple(string firstNumber, string secondNumber)
        {
            if(IsNumberic(firstNumber) && IsNumberic(firstNumber)) {
                var multiple = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiple.ToString());
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
