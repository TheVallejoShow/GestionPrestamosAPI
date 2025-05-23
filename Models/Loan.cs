namespace gestion_prestamos_api.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}