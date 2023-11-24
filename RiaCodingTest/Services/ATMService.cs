using RiaCodingTest.Models;
using RiaCodingTest.Services.Interfaces;
using System.Reflection;

namespace RiaCodingTest.Services
{
    public class ATMService : IATMService
    {
        private readonly ICartridgeService _cartridgeService;

        public ATMService(ICartridgeService cartridgeService)
        {
            this._cartridgeService = cartridgeService;
        }

        /// <summary> 
        /// The code checks all possible combinations that the ATM can pay.
        /// <example>For example: 150
        /// results in <c>finalCombinations</c> 
        /// having the value 
        /// "15 X 10 EUR",
        /// "3 X 50 EUR",
        /// "1 X 100 EUR + 5 X 10 EUR",
        /// "1 X 100 EUR + 1 X 50 EUR",
        /// "1 X 50 EUR + 10 X 10 EUR",
        /// "2 X 50 EUR + 5 X 10 EUR".
        /// </example>
        /// </summary>
        public List<string> GetDenominations(int amount)
        {
            List<Cartridge> cartridgeCombinations = _cartridgeService.GetPossibleCartridgeCombinations();
            List<string> finalCombinations = new List<string>();

            // Checking the possibilities with fixed definition of Cartridges 10, 50 and 100
            cartridgeCombinations.ForEach(cartridgeCombination =>
            {
                var result = GenerateCombinations(cartridgeCombination, amount);
                if (!string.IsNullOrEmpty(result) && !finalCombinations.Contains(result))
                {
                    finalCombinations.Add(result);
                }
            });

            //getting the additional combinations using 50
            var combinations50 = Utils.Utils.GetCombinationsBy50(amount);
            combinations50.ForEach(x => finalCombinations.Add(Utils.Utils.ConverterCartridgeToString(x)));

            //getting the additional combinations using 100
            var combinations100 = Utils.Utils.GetCombinationsBy100(amount);
            combinations100.ForEach(x => finalCombinations.Add(Utils.Utils.ConverterCartridgeToString(x)));

            //Avoiding show repeated results
            return finalCombinations.Distinct().ToList();
        }

        /// <summary> 
        /// The code checks the combination with the available notes 
        /// <example>For example: currentNote: Fifty : 0, Hundred: 100, Ten: 10; amount: 150
        /// results in <c>finalResult</c> 
        /// having the value 
        /// "1 X 100 EUR + 5 X 10 EUR",
        /// </example>
        /// </summary>
        private static string GenerateCombinations(Cartridge currentNote, int amount)
        {
            Dictionary<int, int> denominationCombinations = new Dictionary<int, int>();
            string finalResult = string.Empty;
            int withdrawalAmount = amount;
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

            // case the dominations is equal to withdrawal Amount, add the information to finalResult
            if (sumRemainders == withdrawalAmount)
            {
                finalResult = Utils.Utils.ConvertToString(denominationCombinations);
            }

            return finalResult;
        }

    }
}
