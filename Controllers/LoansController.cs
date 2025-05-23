using gestion_prestamos_api.Models;
using gestion_prestamos_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gestion_prestamos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _repository;

        public LoansController(ILoanRepository repository)
        {
            _repository = repository;
        }

        // GET: api/loans
        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        // GET: api/loans/user/{email}
        [HttpGet("user/{email}")]
        public IActionResult GetByUser(string email) => Ok(_repository.GetByUser(email));

        // POST: api/loans
        [HttpPost]
        public IActionResult Create([FromBody] Loan loan)
        {
            var createdLoan = _repository.Create(loan);
            return CreatedAtAction(nameof(GetByUser), new { email = loan.UserEmail }, createdLoan);
        }

        // PUT: api/loans/{id}/status?status=Aprobado
        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromQuery] string status)
        {
            if (status != "Aprobado" && status != "Rechazado")
                return BadRequest("Estado inválido");

            var updated = _repository.UpdateStatus(id, status);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}