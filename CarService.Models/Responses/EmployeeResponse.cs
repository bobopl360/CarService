using CarService.Models.Enums;

namespace CarService.Models.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MonthlySalary { get; set; }

        public PaymentType paymentType { get; set; }
    }
}
