using CounterAPI.Entities;
using CounterAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly ICountRepository _countRepository;

        public CountController(ICountRepository countRepository)
        {
            _countRepository = countRepository ?? throw new ArgumentNullException(nameof(_countRepository));
        }

        [HttpGet("get-number")]
        public async Task<IActionResult> GetNumber()
        {
            var currentNumber = await _countRepository.GetNumberAsync();
            return Ok(currentNumber);
        }


        [HttpGet("get-number-by-id")]
        public async Task<IActionResult> GetNumberById(int id)
        {
            var currentNumber = await _countRepository.GetNumberByIdAsync(id);
            if (currentNumber == null)
                return BadRequest("Nie ma takiego numeru o ID: " + id);
            
            return Ok(currentNumber);
        }

        [HttpPost("post-number")]
        public async Task<IActionResult> PostNumber(int id, int number)
        {
            if(id == null)
                return BadRequest("Błędne ID");

            var count = new Count() { Id = id, CountNumber = number};
            await _countRepository.AddNumberAsync(count);

            return Ok(count);
                
        }
        [HttpPost("increase-number")]
        public async Task<IActionResult> IncreaseNumber(int id)
        {
            var currentNumber = await _countRepository.GetNumberByIdAsync(id);
            if (currentNumber == null)
                return BadRequest("Nie ma takiego numeru o ID: " + id);
            currentNumber.CountNumber++;
            _countRepository.UpdateNumber(currentNumber);
            return Ok(new { msg = "Pomyślna inkrementacja" });
        }

        [HttpPost("reset-number")]
        public async Task<IActionResult> UpdateNumberToZero(int id)
        {          
            var currentNumber = await _countRepository.GetNumberByIdAsync(id);
            if (currentNumber == null)
                return BadRequest("Nie ma takiego numeru");
                currentNumber.CountNumber = 0;
            _countRepository.UpdateNumber(currentNumber);
            return Ok(new {msg = "Pomyślnie zresetowano"});
        }

        [HttpPost("decrease-number")]
        public async Task<IActionResult> DecreaseNumber(int id)
        {
            var currentNumber = await _countRepository.GetNumberByIdAsync(id);
            if (currentNumber == null)
                return BadRequest("Nie ma takiego numeru");
            if (currentNumber.CountNumber == 0)
                return NoContent();

            currentNumber.CountNumber--;
            _countRepository.UpdateNumber(currentNumber);

            return Ok(new { msg = "Pomyślna dekrementacja" });

        }
        [HttpDelete("delete-number")]
        public async Task<IActionResult> DeleteNumberAsync(int id)
        {
            var currentNumber = await _countRepository.GetNumberByIdAsync(id);
            if (currentNumber == null)
                return BadRequest("Nie ma takiego numeru");

            await _countRepository.DeleteNumberByIdAsync(currentNumber.Id);

            return NoContent();

        }





    }
}
