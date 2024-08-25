namespace Estoque_App.Data.Repositories.Interface
{
    public interface IFirebaseRepository
    {
        Task<string> AddImageAsync(Stream fileStream, string fileName);
        Task<bool> RemoveImageAsync(string filePath);
        Task<string> GetImageAsync(string filePath);
    }
}
