using System.ComponentModel.DataAnnotations;

namespace RiaCodingTest.API.Models
{
    public class Customer
    {
        [Required(ErrorMessage= "Id is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be grather than 18")]
        public int Age { get; set; }
       
    }

    
}
