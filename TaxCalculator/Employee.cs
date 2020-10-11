using System;

namespace TaxCalculator
{
    class Employee
    {
        private TaxScale[] _taxScales;
        public Employee(TaxScale[] taxScales)
        {
            _taxScales = taxScales;
        }

        public int Id;
        public string FirstName;
        public string LastName;
        public DateTime BirthDate { get; set; }

        private decimal _monthlySalary;
        public decimal MonthlySalary { get => _monthlySalary;
            set { 
                _monthlySalary = value;
                CalculateMonthlyTax();
            }
        }
        public int? ManagerId { get; set; }
        public DateTime JoinDate { get; set; }
        public double Age => (DateTime.Now - BirthDate).Days / 365;

        public decimal MonthlyTax { get; private set; }

        private decimal CalculateMonthlyTax()
        {
            var annualSalary = MonthlySalary * 12;
            for (int i = 0; i < _taxScales.Length; i++)
            {
                if(annualSalary >= _taxScales[i].From && annualSalary <= _taxScales[i].To.GetValueOrDefault(decimal.MaxValue))
                {
                    MonthlyTax = ((_taxScales[i].Base + (annualSalary - _taxScales[i].From) * _taxScales[i].Percent) / 12);
                    return MonthlyTax;
                }
            }
            throw new InvalidOperationException("Tax scale not found");
        }

        //public decimal CalculateMonthlyTax(TaxScale[] taxScales, decimal discount)
        //{
        //    var result = CalculateMonthlyTax(taxScales);
        //    return result - discount;
        //}
    }
}
