using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            if (number == null)
                throw new InvalidOperationException($"No number found with ID {numberId}");

            return number.Value * multiplier;
        }

        public double DivideNumberFromDatabaseBy(string numberId, int divisor)
        {
            if (divisor == 0)
                throw new ArgumentOutOfRangeException("Cannot divide by zero");
            if (divisor < 0)
                throw new ArgumentOutOfRangeException("Cannot divide by a negative number");

            var number = _numberRepository.GetNumber(numberId);

            if (number.HasValue)
                throw new InvalidOperationException($"No number found with ID {numberId}");

            return number.Value / divisor;
        }

        public async Task CreateNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number != 47)
                {
                    var numberId = Guid.NewGuid().ToString();
                    await _numberRepository.SaveNumber(numberId, number);
                }
            }
        }

        public async Task UpdateNumbers(IEnumerable<(string, int)> numbers)
        {
            foreach (var (numberId, number) in numbers)
            {
                await _numberRepository.SaveNumber(numberId, number);
            }
        }

        public async Task DeleteNumber(string numberId)
        {
            var number = _numberRepository.GetNumber(numberId);

            if (number.HasValue)
                throw new InvalidOperationException($"No number found with ID {numberId}");

            await _numberRepository.DeleteNumber(numberId);
        }
    }
}
