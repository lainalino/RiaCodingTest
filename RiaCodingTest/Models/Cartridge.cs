
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RiaCodingTest.Models
{
    //Class to inform the available Cartrigdes (10, 50, 100)
    public class Cartridge
    {
        public int Hundred { get; set; }
        public int Fifty { get; set; }
        public int Ten { get; set; }
    }
}
