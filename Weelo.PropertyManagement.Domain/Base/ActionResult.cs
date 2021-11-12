namespace Weelo.PropertyManagement.Domain.Base
{
    public class ActionResult
    {
        public bool IsSuccessful { get; set; }
        public object Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
