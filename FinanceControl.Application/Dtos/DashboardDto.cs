using FinanceControl.Domain.Enums;
namespace FinanceControl.Application.Dtos
{
    public class DashboardDto
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance => TotalIncome - TotalExpenses;
    }
}
