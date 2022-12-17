namespace Features.Mouse.Scripts.Domain.Action
{
    public class CheckForOnHoveringStart : ICheckForOnHoveringStart
    {
        private readonly HoveringService _service;
        public CheckForOnHoveringStart(HoveringService service) => _service = service;
        public void Execute() => _service.CheckForOnHoveringStart();
    }
}