using System.Collections.Generic;

namespace WebUI.Models
{
    public class SatelliteOrchestratorModel
    {
        public string UserName { get; set; }
        public List<SatelliteOrchestratorItemModel> Items { get; set; } = new List<SatelliteOrchestratorItemModel>();
        public decimal TotalPrice { get; set; }
    }
}
