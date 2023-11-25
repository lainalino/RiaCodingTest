namespace RiaCodingTest.API.Services.Interfaces
{
    public interface IATMService
    {
        public List<string> GetDenominations(int amount);
    }
}
