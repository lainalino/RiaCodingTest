using RiaCodingTest.API.Models;

namespace RiaCodingTest.API.Utils
{
    public static class Utils
    {
        /// <summary> 
        /// The code convert dictionary to string
        /// <example>For example: Dictionary<10,15>
        /// results having the value 
        /// "15 X 10 EUR",
        /// </example>
        /// </summary>
        public static string ConvertToString(Dictionary<int, int> denominationCombinations)
        {
            return string.Join(" + ", denominationCombinations.Select(x => x.Value + " X " + x.Key + " EUR").ToArray());
        }

        /// <summary> 
        /// The code convert the object Cartridge to String
        /// <example>For example: combination: Fifty : 1, Hundred: 0, Ten: 10
        /// results in <c>result</c> 
        /// having the value 
        /// "1 X 50 EUR + 10 X 10 EUR",
        /// </example>
        /// </summary>
        public static string ConverterCartridgeToString(Cartridge combination)
        {
            var result = string.Empty;
            if (combination.Hundred > 0)
            {
                result += $"{combination.Hundred} X 100 EUR";
            }

            if (combination.Fifty > 0)
            {
                result += !string.IsNullOrEmpty(result) ? " + " : string.Empty;
                result += $"{combination.Fifty} X 50 EUR";
            }

            if (combination.Ten > 0)
            {
                result += !string.IsNullOrEmpty(result) ? " + " : string.Empty;
                result += $"{combination.Ten} X 10 EUR";
            }

            return result;
        }

        /// <summary> 
        /// The code gets the combinations by 100
        /// <example>For example: amount: 150
        /// results in <c>result</c> 
        /// having the values:
        /// "Fifty: 1, Hundred: 1",
        /// "Fifty: 0, Hundred: 1, Ten: 50"
        /// </example>
        /// It means that there are two ways using 100 mandatory to get 150
        /// </summary>
        public static List<Cartridge> GetCombinationsBy100(int amount)
        {
            int count = amount / 100;
            int balance = amount;
            List<Cartridge> result = new List<Cartridge>();

            //Getting combinations with 50
            for (int i = 0; i < count; i++)
            {
                balance -= 100;
                if (balance >= 50)
                {
                    var result50 = GetCombinationsBy50(balance);
                    result50.ForEach(x => x.Hundred = i + 1);
                    result50.ForEach(x => result.Add(x));
                }
            }

            //Getting combinations without 50
            balance = amount;
            for (int i = 0; i < count; i++)
            {
                balance -= 100;
                int count10 = balance / 10;
                result.Add(new Cartridge
                {
                    Hundred = i + 1,
                    Ten = count10
                });
            }

            return result;
        }

        /// <summary> 
        /// The code gets the combinations by 50
        /// <example>For example: amount: 150
        /// results in <c>result</c> 
        /// having the values:
        /// "Fifty: 1, Ten: 10",
        /// "Fifty: 2, Ten: 50",
        /// "Fifty: 3"
        /// </example>
        /// It means that there are three ways using 50 mandatory to get 150
        /// </summary>

        public static List<Cartridge> GetCombinationsBy50(int amount)
        {
            int count = amount / 50;
            int balance = amount;
            List<Cartridge> result = new List<Cartridge>();

            for (int i = 0; i < count; i++)
            {
                balance -= 50;
                int count10 = balance / 10;

                result.Add(new Cartridge
                {
                    Fifty = i + 1,
                    Ten = count10
                });
            }
            return result;
        }

    }
}
