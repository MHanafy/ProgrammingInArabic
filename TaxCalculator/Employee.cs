using System;

namespace TaxCalculator
{
    class Employee
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public DateTime BirthDate { get; set; }
        public decimal MonthlySalary { get; set; }
        public int? ManagerId { get; set; }
        public DateTime JoinDate { get; set; }
        public double Age => (DateTime.Now - BirthDate).Days / 365;

        private decimal? _monthlyTax;
        public decimal? MonthlyTax {
            get {
                if (_monthlyTax.HasValue) return _monthlyTax;
                throw new InvalidOperationException("Please call CalculateMonthlyTax before accessing this property.");
            }

            private set { _monthlyTax = value; }
}

        public decimal CalculateMonthlyTax(TaxScale[] taxScales)
        {
            var annualSalary = MonthlySalary * 12;
            for (int i = 0; i < taxScales.Length; i++)
            {
                if(annualSalary >= taxScales[i].From && annualSalary <= taxScales[i].To.GetValueOrDefault(decimal.MaxValue))
                {
                    MonthlyTax = ((taxScales[i].Base + (annualSalary - taxScales[i].From) * taxScales[i].Percent) / 12);
                    return MonthlyTax.Value;
                }
            }
            throw new InvalidOperationException("Tax scale not found");
        }

        public decimal CalculateMonthlyTax(TaxScale[] taxScales, decimal discount)
        {
            var result = CalculateMonthlyTax(taxScales);
            return result - discount;
        }
    }
}
