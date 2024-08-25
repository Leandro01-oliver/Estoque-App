using Estoque_App.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Estoque_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFirebaseService _firebaseService;

        public HomeController(IFirebaseService firebaseService, ILogger<HomeController> logger)
        {
            _firebaseService = firebaseService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> UploadImage(IFormFile file)
        {
            var stream = file.OpenReadStream();
            string downloadUrl = await _firebaseService.AddImageAsync(stream, file.FileName);
            return downloadUrl;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(string filePath)
        {
            var success = await _firebaseService.RemoveImageAsync(filePath);
            if (success)
            {
                return Content("File deleted successfully");
            }
            else
            {
                return Content("Error deleting file");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(string filePath)
        {
            var imageStream = await _firebaseService.GetImageAsync(filePath);
            if (imageStream != null)
            {
                return File(imageStream, "image/jpeg");
            }
            else
            {
                return Content("File not found");
            }
        }
    }
}
