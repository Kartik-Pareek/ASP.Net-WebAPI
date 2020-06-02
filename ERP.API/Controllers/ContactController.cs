using System.Threading.Tasks;
using ERP.DATA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }

        // GET api/contact
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Contacts.ToListAsync();

            return Ok(values);
        }

        // GET api/contact/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/contact
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/contact/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/contact/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}