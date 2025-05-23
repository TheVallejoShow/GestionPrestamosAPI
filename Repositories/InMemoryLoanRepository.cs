using gestion_prestamos_api.Models;
using System.Collections.Generic;
using System.Linq;

namespace gestion_prestamos_api.Repositories
{
    public class InMemoryLoanRepository : ILoanRepository
    {
        private readonly List<Loan> _loans = new()
        {
            new Loan { Id = 1, UserEmail = "usuario@test.com", Amount = 1000, Status = "Pendiente" },
            new Loan { Id = 2, UserEmail = "admin@test.com", Amount = 500, Status = "Aprobado" },
            new Loan { Id = 3, UserEmail = "admin@test.com", Amount = 200, Status = "Rechazado" }
        };

        public IEnumerable<Loan> GetAll() => _loans;

        public IEnumerable<Loan> GetByUser(string userEmail) => _loans.Where(l => l.UserEmail == userEmail);

        public Loan GetById(int id) => _loans.FirstOrDefault(l => l.Id == id);

        public Loan Create(Loan loan)
        {
            loan.Id = _loans.Max(l => l.Id) + 1;
            loan.Status = "Pendiente";
            _loans.Add(loan);
            return loan;
        }

        public bool UpdateStatus(int id, string newStatus)
        {
            var loan = GetById(id);
            if (loan == null) return false;
            loan.Status = newStatus;
            return true;
        }
    }
}