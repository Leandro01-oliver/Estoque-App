using Estoque_App.Data.Repositories.Interface;
using Estoque_App.Helpers.Contants;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using Microsoft.Extensions.Options;

namespace Estoque_App.Data.Repositories
{
    public class FirebaseRepository : IFirebaseRepository
    {
        private readonly FirebaseAuthSettings _firebaseSettings;

        public FirebaseRepository(IOptions<FirebaseAuthSettings> firebaseSettings)
        {
            _firebaseSettings = firebaseSettings.Value;
        }

        private async Task<string> GetAuthTokenAsync()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = _firebaseSettings.ApiKey,
                AuthDomain = _firebaseSettings.AuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider() 
                },
            };

            var auth = new FirebaseAuthClient(config);
            var authLink = await auth.SignInWithEmailAndPasswordAsync(_firebaseSettings.AuthEmail, _firebaseSettings.AuthPassword);

            var authToken = await authLink.User.GetIdTokenAsync();

            return authToken;
        }

        public async Task<string> AddImageAsync(Stream fileStream, string fileName)
        {
            try
            {
                var authToken = await GetAuthTokenAsync();

                var cancellation = new CancellationTokenSource();

                var storage = new FirebaseStorage(
                    _firebaseSettings.Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(authToken),
                        ThrowOnCancel = true
                    });

                var task = storage
                    .Child("Produtos")
                    .Child(fileName)
                    .PutAsync(fileStream, cancellation.Token);

                var downloadUrl = await task;


                return downloadUrl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> GetImageAsync(string filePath)
        {
            var authToken = await GetAuthTokenAsync();

            var storage = new FirebaseStorage(
                        _firebaseSettings.Bucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(authToken),
                            ThrowOnCancel = true
                        });

            var task = storage
                .Child("Produtos")
                .Child(filePath)
                .GetDownloadUrlAsync();

            return await task;
        }

        public async Task<bool> RemoveImageAsync(string filePath)
        {
            var authToken = await GetAuthTokenAsync();

            var storage = new FirebaseStorage(
                _firebaseSettings.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authToken),
                    ThrowOnCancel = true
                });

            try
            {
                await storage
                    .Child(filePath)
                    .DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
