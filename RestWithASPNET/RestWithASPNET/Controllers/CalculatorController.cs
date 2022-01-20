using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")] //Path que eu escolido ( Sum Computa a soma de uma sequencia de valores numericos! )
        public IActionResult Sum(string firstNumber, string secondNumber) //To passando como string para testar valida;'ao
        {

            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)) //soma
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Sub/{firstNumber}/{secondNumber}")] //Sub (-)
        public IActionResult Sub (string firstNumber, string secondNumber) 
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) //Sub
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")] //Mult (*)
        public IActionResult Mult(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) //Sub
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")] //Divion (/)
        public IActionResult divion(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")] //media
        public IActionResult Mean(string firstNumber, string secondNumber) 
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}")] //SquareRoot
        public IActionResult SquareRoot(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber))
            {
                var SquareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(SquareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }


        private bool IsNumeric(string strNumber) //Se ele parciar, entao vai ser numerioco. se n'ao vai dar false 
        {
            double number;
            bool isNumber = double.TryParse //TryParse = "Um valor retornado indica se a conversão foi bem-sucedida."
               (    
                    strNumber,
                    System.Globalization.NumberStyles.Any, 
                    System.Globalization.NumberFormatInfo.InvariantInfo, 
                    out number 
               );

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber) 
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

    }
}
