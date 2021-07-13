using System.Threading.Tasks;

namespace FelixUnitTestLesson
{
    public interface INumberRepository
    {
        int? GetNumber(string numberId);
        Task SaveNumber(string numberId, int number);
        Task DeleteNumber(string numberId);
    }
}