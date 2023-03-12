using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI
{
    public class SatelliteOrchestratorControllerModel : PageModel
    {
        private readonly ISatelliteOrchestratorControllerService _SatelliteOrchestratorControllerService;

        public SatelliteOrchestratorControllerModel(ISatelliteOrchestratorControllerService SatelliteOrchestratorControllerService)
        {
            _SatelliteOrchestratorControllerService = SatelliteOrchestratorControllerService;
        }

        public IEnumerable<SatelliteOrchestratorControllerResponseModel> SatelliteOrchestratorControllers { get; set; } = new List<SatelliteOrchestratorControllerResponseModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            SatelliteOrchestratorControllers = await _SatelliteOrchestratorControllerService.GetSatelliteOrchestratorControllersByUserName("swn");

            return Page();
        }       
    }
}