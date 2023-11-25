using RiaCodingTest.API.Models;

namespace RiaCodingTest.APIStress
{
    public static class CustomerStress
    {
        private static readonly string[] _firstName = {
            "Leia", "Sadie", "Jose", "Sara",
            "Frank", "Dewey", "Tomas", "Joel",
            "Lukas", "Carlos"
        };
        private static readonly string[] _lastName = {
            "Liberty", "Ray", "Harrison", "Ronan",
            "Drew", "Powell", "Larsen", "Chan",
            "Anderson", "Lane"
        };

        public static List<Customer> GetCustomerRandom()
        {
            var random = new Random();
            var listCustomers = new List<Customer>();
            int countCustomer = random.Next(1, 100);

            for (int index = 0; index < countCustomer; index++)
            {
                listCustomers.Add(new Customer
                {
                    Id = random.Next(0, 9000),
                    Age = random.Next(10, 90),
                    FirstName = _firstName[random.Next(0, _firstName.Length)],
                    LastName = _lastName[random.Next(0, _lastName.Length)],
                       
                });
            }                

            return listCustomers;
        }
    }
}
