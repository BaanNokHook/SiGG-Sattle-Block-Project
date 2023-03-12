using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataSatelliteService _DataSatelliteService;
        private readonly ISatelliteOrchestratorService _SatelliteOrchestratorService;

        public IndexModel(IDataSatelliteService DataSatelliteService, ISatelliteOrchestratorService SatelliteOrchestratorService)
        {
            _DataSatelliteService = DataSatelliteService;
            _SatelliteOrchestratorService = SatelliteOrchestratorService;
        }

        public IEnumerable<DataSatelliteModel> ProductList { get; set; } = new List<DataSatelliteModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _DataSatelliteService.GetDataSatellite();
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
                Quantity = 1,
                Color = "Black"
            });

            var SatelliteOrchestratorUpdated = await _SatelliteOrchestratorService.UpdateSatelliteOrchestrator(SatelliteOrchestrator);
            return RedirectToPage("Cart");
        }
    }
}
