namespace Shopping.Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public SatelliteOrchestratorModel SatelliteOrchestratorWithProducts { get; set; }
        public IEnumerable<SatelliteOrchestratorControllerResponseModel> SatelliteOrchestratorControllers { get; set; }
    }
}