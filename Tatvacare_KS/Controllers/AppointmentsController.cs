using Microsoft.AspNetCore.Mvc;
using Tatvacare_KS.Model;
using Tatvacare_KS.Services;

namespace Tatvacare_KS.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentsController : Controller
    {
        private readonly AppointmentService _service;

        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll(CancellationToken ct)
        {
            var list = await _service.GetAllAsync(ct);
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Appointment>> GetOne(int id, CancellationToken ct)
        {
            var a = await _service.GetByIdAsync(id, ct);
            if (a is null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Create([FromBody] Appointment a, CancellationToken ct)
        {
            var result = await _service.CreateAsync(a, ct);
            if (!result.ok)
            {
                return BadRequest(new { message = result.error });
            }

            return CreatedAtAction(nameof(GetOne), new { id = result.created!.Id }, result.created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Appointment a, CancellationToken ct)
        {
            var result = await _service.UpdateAsync(id, a, ct);
            if (!result.ok)
            {
                return BadRequest(new { message = result.error });
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            bool deleted = await _service.DeleteAsync(id, ct);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
