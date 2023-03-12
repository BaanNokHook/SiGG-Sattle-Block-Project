﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI
{
    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; }

        public void OnGetContact()
        {
            Message = "Your email was sent.";
        }

        public void OnGetSatelliteOrchestratorControllerSubmitted()
        {
            Message = "Your SatelliteOrchestratorController submitted successfully.";
        }
    }
}