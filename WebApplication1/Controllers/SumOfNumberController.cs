using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        private string _connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=VegaVestaNew;Integrated Security=True";

        [HttpGet("AllBrandNames")]
        public ActionResult<List<string>> GetAllBrandNames()
        {
            List<string> brandNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT VegaBrandName FROM VegaBrand";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        brandNames.Add(reader.GetString(0));
                    }
                }
            }
            return Ok(brandNames);
        }
    }
}
