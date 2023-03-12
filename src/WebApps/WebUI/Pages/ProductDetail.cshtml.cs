using System;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI
{
    public class ProductDetailModel : PageModel
    {
        private readonly IDataSatelliteService _DataSatelliteService;
        private readonly ISatelliteOrchestratorService _SatelliteOrchestratorService;

        public ProductDetailModel(IDataSatelliteService DataSatelliteService, ISatelliteOrchestratorService SatelliteOrchestratorService)
        {
            _DataSatelliteService = DataSatelliteService;
            _SatelliteOrchestratorService = SatelliteOrchestratorService;
        }

        public DataSatelliteModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _DataSatelliteService.GetDataSatellite(productId);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _DataSatelliteService.GetDataSatellite(productId);

            var userName = "swn";
            var SatelliteOrchestrator = await _SatelliteOrchestratorService.GetSatelliteOrchestrator(userName);

            SatelliteOrchestrator.Items.Add(new SatelliteOrchestratorItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = Quantity,
                Color = Color
            });

            var SatelliteOrchestratorUpdated = await _SatelliteOrchestratorService.UpdateSatelliteOrchestrator(SatelliteOrchestrator);

            return RedirectToPage("Cart");
        }
    }
}