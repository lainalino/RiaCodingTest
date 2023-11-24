using RiaCodingTest.Models;
using RiaCodingTest.Services.Interfaces;

namespace RiaCodingTest.Services
{
    public class CartridgeService : ICartridgeService
    {
        public List<Cartridge> GetPossibleCartridgeCombinations()
        {
            return new List<Cartridge>
            {
               new Cartridge
                {
                   Ten = 10
                },
                new Cartridge
                {
                   Fifty= 50
                },new Cartridge
                {
                   Hundred= 100
                },
                new Cartridge
                {
                    Fifty = 50,
                    Ten = 10
                },
                new Cartridge
                {
                    Hundred = 100,
                    Ten = 10
                },
                new Cartridge
                {
                   Hundred = 100,
                   Fifty = 50
                },
                new Cartridge
                {
                    Hundred = 100,
                    Fifty = 50,
                    Ten = 10
                }
            };
        }
    }
}
