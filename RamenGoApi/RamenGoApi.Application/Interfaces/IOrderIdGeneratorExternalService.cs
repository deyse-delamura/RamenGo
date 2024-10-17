namespace RamenGoApi.Application.Interfaces
{
    public interface IOrderIdGeneratorExternalService
    {
        Task<string> GenerateOrderIdAsync();
    }
}
