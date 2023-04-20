using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumOfNumberController : ControllerBase
    {
        private readonly List<int> _numbers = new List<int> { 1, 2, 3 };

        [HttpGet]
        public IActionResult GetNumbers()
        {
            return Ok(_numbers);
        }

        [HttpPost("numbers")]
        public IActionResult AddNumber(int number)
        {
            _numbers.Add(number);
            return Ok(_numbers);
        }

        [HttpDelete]
        [Route("numbers/{number}")]
        public IActionResult RemoveNumber(int number)
        {
            if (_numbers.Contains(number))
            {
                _numbers.Remove(number);
                return Ok(_numbers);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
