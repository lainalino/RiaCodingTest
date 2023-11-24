using RiaCodingTest.Models;

namespace RiaCodingTest.Services.Interfaces
{
    public interface IATMService
    {
        public List<string> GetDenominations(int amount);
    }
}
