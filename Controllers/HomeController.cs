using Estoque_App.Data.Entities;
using Estoque_App.Data.Models;
using Estoque_App.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Estoque_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFirebaseService _firebaseService;
        private readonly IMidiaService _midiaService;
        private readonly IProdutoService _produtoService;

        public HomeController(IFirebaseService firebaseService, IMidiaService midiaService, IProdutoService produtoService, ILogger<HomeController> logger)
        {
            _firebaseService = firebaseService;
            _produtoService = produtoService;
            _midiaService = midiaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetAllFullIncludeAsync(null,1,10);
            return View(produtos);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] ProdutoVm produto, IFormFile file)
        {
            var existeProduto = await _produtoService.GetByNomeAsync(produto.Nome);
            var existeMidia = await _midiaService.GetByNomeETipoImagemAsync(file.FileName, ProdutoVm.CheckMidia(file.ContentType));
            MidiaVm midiaVm = new MidiaVm();

            if (existeProduto is null)
            { 
                if (existeMidia is null)
                {
                    var url = await UploadImage(file);
                     midiaVm = new MidiaVm()
                    {
                        Url = url,
                        TipoMidia = ProdutoVm.CheckMidia(file.ContentType),
                        Nome = file.FileName
                    };
                    await _midiaService.AddAsync(midiaVm);
                }


                produto.MidiaId = midiaVm.MidiaId;

                await _produtoService.AddAsync(produto);
            }


            return View(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar([FromQuery] Guid produtoId)
        {
            var produto = await _produtoService.GetByIdFullIncludeAsync(produtoId);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar([FromForm] ProdutoVm produto, IFormFile file)
        {
            var existeProduto = await _produtoService.GetByIdFullIncludeAsync(produto.ProdutoId);

            MidiaVm midiaVm = new MidiaVm();

            if (existeProduto is not null)
            {
                var url = await UploadImage(file);
                midiaVm = new MidiaVm()
                {
                    MidiaId = existeProduto.MidiaId ?? Guid.NewGuid(),
                    Url = url,
                    TipoMidia = ProdutoVm.CheckMidia(file.ContentType),
                    Nome = file.FileName
                };

                _midiaService.Update(midiaVm);

                produto.MidiaId = midiaVm.MidiaId;

                _produtoService.Update(produto);
            }

            return RedirectToAction(nameof(Index));
        }

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
    }
}
