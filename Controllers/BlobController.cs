using ABCRetailApp_Mary_Tshabalala.services;
using Microsoft.AspNetCore.Mvc;

namespace ABCRetailApp_Mary_Tshabalala.Controllers
{
    public class BlobController : Controller
    {
        private readonly BlobStorageService _blobStorageService;

        public BlobController(BlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _blobStorageService.UploadBlobAsync(file, "productimages");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var blobs = await _blobStorageService.ListBlobsAsync("productimages");
            return View(blobs);
        }
    }

}
