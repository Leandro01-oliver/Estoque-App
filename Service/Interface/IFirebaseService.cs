namespace Estoque_App.Service.Interface
{
    public interface IFirebaseService
    {
        Task<string> AddImageAsync(Stream fileStream, string fileName);
        Task<bool> RemoveImageAsync(string filePath);
        Task<string> GetImageAsync(string filePath);
    }
}
