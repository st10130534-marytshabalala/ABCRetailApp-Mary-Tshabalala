using ABCRetailApp_Mary_Tshabalala.Models;
using ABCRetailApp_Mary_Tshabalala.services;
using Microsoft.AspNetCore.Mvc;

namespace ABCRetailApp_Mary_Tshabalala.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TableStorageService _tableStorageService;

        public CustomerController(TableStorageService tableStorageService)
        {
            _tableStorageService = tableStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _tableStorageService.GetCustomersAsync();
            return View(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(customerprofile customer)
        {
            await _tableStorageService.AddCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }

}
