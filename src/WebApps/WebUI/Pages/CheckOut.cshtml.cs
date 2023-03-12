using System;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI
{
    public class CheckOutModel : PageModel
    {
        private readonly ISatelliteOrchestratorService _SatelliteOrchestratorService;
        private readonly ISatelliteOrchestratorControllerService _SatelliteOrchestratorControllerService;

        public CheckOutModel(ISatelliteOrchestratorService SatelliteOrchestratorService, ISatelliteOrchestratorControllerService SatelliteOrchestratorControllerService)
        {
            _SatelliteOrchestratorService = SatelliteOrchestratorService;
            _SatelliteOrchestratorControllerService = SatelliteOrchestratorControllerService;
        }

        [BindProperty]
        public SatelliteOrchestratorCheckoutModel SatelliteOrchestratorController { get; set; }

        public SatelliteOrchestratorModel Cart { get; set; } = new SatelliteOrchestratorModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Cart = await _SatelliteOrchestratorService.GetSatelliteOrchestrator(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName = "swn";
            Cart = await _SatelliteOrchestratorService.GetSatelliteOrchestrator(userName);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SatelliteOrchestratorController.UserName = userName;
            SatelliteOrchestratorController.TotalPrice = Cart.TotalPrice;

            await _SatelliteOrchestratorService.CheckoutSatelliteOrchestrator(SatelliteOrchestratorController);
            
            return RedirectToPage("Confirmation", "SatelliteOrchestratorControllerSubmitted");
        }       
    }
}