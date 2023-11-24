using RiaCodingTest.Models;
using RiaCodingTest.Services.Interfaces;
using System.Reflection;
using System.Text;

namespace RiaCodingTest.Services
{
    public class ATMService : IATMService
    {
        private readonly ICartridgeService _cartridgeService;

        public ATMService(ICartridgeService cartridgeService)
        {
            this._cartridgeService = cartridgeService;
        }
        public List<string> GetDenominations(int amount)
        {
            List<Cartridge> cartridgeCombinations = _cartridgeService.GetPossibleCartridgeCombinations();
            List<string> finalCombinations = new List<string>();

            cartridgeCombinations.ForEach(cartridgeCombination =>
            {
                var result = GenerateCombinations(cartridgeCombination, amount);
                if (!string.IsNullOrEmpty(result) && !finalCombinations.Contains(result))
                {
                    finalCombinations.Add(result);
                }
            });

            var combinations50 = Utils.Utils.GetCombinationsBy50(amount);
            combinations50.ForEach(x => finalCombinations.Add(Utils.Utils.ConverCartridgeToString(x)));

            var combinations100 = Utils.Utils.GetCombinationsBy100(amount);
            combinations100.ForEach(x => finalCombinations.Add(Utils.Utils.ConverCartridgeToString(x)));

            return finalCombinations;
        }

        private static string GenerateCombinations(Cartridge currentNote, int amount)
        {
            Dictionary<int, int> denominationCombinations = new Dictionary<int, int>();
            string finalResult = string.Empty;
            int withdrawlAmount = amount;
            int sumRemainders = 0;

            foreach (PropertyInfo propertyInfo in currentNote.GetType().GetProperties())
            {
                var note = int.Parse(propertyInfo.GetValue(currentNote, null).ToString());

                if (note > 0)
                {
                    int remainder = amount / note;
                    if (remainder > 0)
                    {
                        denominationCombinations[note] = remainder;
                        sumRemainders += note * remainder;
                        amount = amount % note;
                    }
                }
            }

            if (sumRemainders == withdrawlAmount)
            {
                finalResult = Utils.Utils.ConvertToString(denominationCombinations);
            }

            return finalResult;
        }

    }
}
