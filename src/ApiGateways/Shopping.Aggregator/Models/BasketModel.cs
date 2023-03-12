namespace Shopping.Aggregator.Models
{
    public class SatelliteOrchestratorModel
    {
        public string UserName { get; set; }
        public List<SatelliteOrchestratorItemExtendedModel> Items { get; set; } = new List<SatelliteOrchestratorItemExtendedModel>();
        public decimal TotalPrice { get; set; }
    }
}