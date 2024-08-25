using Estoque_App.Data.Repositories.Interface;
using Estoque_App.Helpers.Contants;
using Estoque_App.Service.Interface;
using Microsoft.Extensions.Options;

namespace Estoque_App.Service
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IFirebaseRepository _firebaseRepository;

        public FirebaseService(IFirebaseRepository firebaseRepository)
        {
            _firebaseRepository = firebaseRepository;
        }

        public async Task<string> AddImageAsync(Stream fileStream, string fileName)
        {
            return await _firebaseRepository.AddImageAsync(fileStream, fileName);
        }

        public async Task<bool> RemoveImageAsync(string filePath)
        {
            return await _firebaseRepository.RemoveImageAsync(filePath);
        }

        public async Task<string> GetImageAsync(string filePath)
        {
            return await _firebaseRepository.GetImageAsync(filePath);
        }
    }
}
