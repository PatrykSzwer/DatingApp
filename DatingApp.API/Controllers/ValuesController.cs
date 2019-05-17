using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DatingApp.Model.Repository.IRepository;

namespace DatingApp.API.Controllers
{
    // localhost:5000/api/Values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValueRepository _valueRepository;

        public ValuesController(IValueRepository valueRepository)
        {
            this._valueRepository = valueRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _valueRepository.GetAll();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _valueRepository.Get(id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
