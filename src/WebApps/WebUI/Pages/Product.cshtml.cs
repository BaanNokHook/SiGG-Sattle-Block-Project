using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI
{
    public class ProductModel : PageModel
    {
        private readonly IDataSatelliteService _DataSatelliteService;
        private readonly ISatelliteOrchestratorService _SatelliteOrchestratorService;

        public ProductModel(IDataSatelliteService DataSatelliteService, ISatelliteOrchestratorService SatelliteOrchestratorService)
        {
            _DataSatelliteService = DataSatelliteService;
            _SatelliteOrchestratorService = SatelliteOrchestratorService;
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<DataSatelliteModel> ProductList { get; set; } = new List<DataSatelliteModel>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var productList = await _DataSatelliteService.GetDataSatellite();
            CategoryList = productList.Select(p => p.Category).Distinct();

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                ProductList = productList.Where(p => p.Category == categoryName);
                SelectedCategory = categoryName;
            }
            else
            {
                ProductList = productList;
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
                Quantity = 1,
                Color = "Black"
            });

            var SatelliteOrchestratorUpdated = await _SatelliteOrchestratorService.UpdateSatelliteOrchestrator(SatelliteOrchestrator);

            return RedirectToPage("Cart");
        }
    }
}