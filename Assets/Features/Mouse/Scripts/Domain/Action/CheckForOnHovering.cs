using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class CheckForOnHovering : ICheckForOnHovering
    {
        private readonly HoveringService _service;
        public CheckForOnHovering(HoveringService service) => _service = service;
        public void Execute() => _service.CheckForOnHovering();
    }
}