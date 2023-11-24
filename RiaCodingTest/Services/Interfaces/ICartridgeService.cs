using RiaCodingTest.Models;

namespace RiaCodingTest.Services.Interfaces
{
    public interface ICartridgeService
    {
        public List<Cartridge> GetPossibleCartridgeCombinations();
    }
}
