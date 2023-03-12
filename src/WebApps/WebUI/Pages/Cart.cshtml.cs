using System;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI
{
    public class CartModel : PageModel
    {
        private readonly ISatelliteOrchestratorService _SatelliteOrchestratorService;

        public CartModel(ISatelliteOrchestratorService SatelliteOrchestratorService)
        {
            _SatelliteOrchestratorService = SatelliteOrchestratorService;
        }

        public SatelliteOrchestratorModel Cart { get; set; } = new SatelliteOrchestratorModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Cart = await _SatelliteOrchestratorService.GetSatelliteOrchestrator(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "swn";
            var SatelliteOrchestrator = await _SatelliteOrchestratorService.GetSatelliteOrchestrator(userName);

            var item = SatelliteOrchestrator.Items.Single(x => x.ProductId == productId);
            SatelliteOrchestrator.Items.Remove(item);

            var SatelliteOrchestratorUpdated = await _SatelliteOrchestratorService.UpdateSatelliteOrchestrator(SatelliteOrchestrator);

            return RedirectToPage();
        }
    }
}