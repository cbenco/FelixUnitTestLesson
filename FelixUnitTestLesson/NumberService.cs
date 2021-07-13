using System;
using System.Collections.Generic;
using System.Text;

namespace FelixUnitTestLesson
{
    public class NumberService
    {
        public readonly INumberRepository _numberRepository;

        public NumberService(INumberRepository numberRepository)
        {
            _numberRepository = numberRepository;
        }

        public int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public int MultiplyNumberFromDatabaseBy(string numberId, int multiplier)
        {
            var number = _numberRepository.GetNumber(numberId);
            return number * multiplier;
        }

        public double DivideNumberFromDatabaseBy(string numberId, int divisor)
        {
            if (divisor == 0)
                throw new ArgumentOutOfRangeException("Cannot divide by zero");
            if (divisor < 0)
                throw new ArgumentOutOfRangeException("Cannot divide by a negative number");

            var number = _numberRepository.GetNumber(numberId);
            return number / divisor;
        }
    }
}
