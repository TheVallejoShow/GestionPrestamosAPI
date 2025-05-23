using gestion_prestamos_api.Models;
using System.Collections.Generic;

namespace gestion_prestamos_api.Repositories
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetAll();
        IEnumerable<Loan> GetByUser(string userEmail);
        Loan GetById(int id);
        Loan Create(Loan loan);
        bool UpdateStatus(int id, string newStatus);
    }
}