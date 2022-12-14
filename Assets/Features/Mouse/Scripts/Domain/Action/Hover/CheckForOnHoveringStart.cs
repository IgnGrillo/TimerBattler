using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Hover
{
    public class CheckForOnHoveringStart : ICheckForOnHoveringStart
    {
        private readonly HoveringService _service;
        public CheckForOnHoveringStart(HoveringService service) => _service = service;
        public void Execute() => _service.CheckForOnHoveringStart();
    }
}