using RiaCodingTest.API.Models;

namespace RiaCodingTest.API.Services.Interfaces
{
    public interface ICartridgeService
    {
        public List<Cartridge> GetPossibleCartridgeCombinations();
    }
}
