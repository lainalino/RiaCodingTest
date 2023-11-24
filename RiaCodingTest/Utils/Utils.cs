using RiaCodingTest.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace RiaCodingTest.Utils
{
    public static class Utils
    {
        public static string ConvertToString(Dictionary<int, int> denominationCombinations)
        {
            return string.Join(" + ", denominationCombinations.Select(x => x.Key + " X " + x.Value + " EUR").ToArray());
        }

        public static string ConverCartridgeToString(Cartridge combinations)
        {
            var result = string.Empty;
            if (combinations.Hundred > 0)
            {
                result += "100 X " + combinations.Hundred.ToString() + " EUR";
            }

            if (combinations.Fifty > 0)
            {
                result += !string.IsNullOrEmpty(result) ? " + " : string.Empty;
                result += "50 X " + combinations.Fifty.ToString() + " EUR";
            }

            if (combinations.Ten > 0)
            {
                result += !string.IsNullOrEmpty(result) ? " + " : string.Empty;
                result += "10 X " + combinations.Ten.ToString() + " EUR";
            }

            return result;
        }
        public static List<Cartridge> GetCombinationsBy100(int amount)
        {
            int count = amount / 100 - 1;
            int balance = amount;
            List<Cartridge> result = new List<Cartridge>();

            for (int i = 0; i < count; i++)
            {
                balance -= 100;
                var result50 = GetCombinationsBy50(balance);
                result50.ForEach(x => x.Ten = i + 1);

                result50.ForEach(x => result.Add(x));
            }
            return result;
        }

        public static List<Cartridge> GetCombinationsBy50(int amount)
        {
            int count = amount / 50 - 1;
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
