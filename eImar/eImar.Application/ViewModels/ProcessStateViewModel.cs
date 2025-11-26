namespace eImar.Application.ViewModels
{
    public class ProcessStateViewModel
    {
        public int ProcessApplicationId { get; set; }
        public string CurrentStateName { get; set; }
        public string CurrentStateDescription { get; set; }
        // Add other relevant process data to be returned to the client
    }
}
