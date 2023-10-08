using Microsoft.AspNetCore.Mvc;

namespace megacal.Controllers;

[Route("api")]
[ApiController]
public class CalcController: ControllerBase
{
    [HttpPost("add")]
    public IActionResult Add([FromBody] Calc calc)
    {
        double res = calc.a + calc.b;

        return Ok(new { result = res });
    }

    [HttpPost("subtract")]
    public IActionResult Subtract([FromBody] Calc calc)
    {
        double res = calc.a - calc.b;

        return Ok(new { result = res });
    }

    [HttpPost("multiply")]
    public IActionResult Multiply([FromBody] Calc calc)
    {
        double res = calc.a * calc.b;

        return Ok(new { result = res });
    }

    [HttpPost("divide")]
    public IActionResult Divide([FromBody] Calc calc)
    {
        if (calc.b != 0)
        {
            double res = calc.a / calc.b;
            return Ok(new { result = res });
        }
        else
        {
            return BadRequest("Division by zero is not allowed.");
        }
    }
}
