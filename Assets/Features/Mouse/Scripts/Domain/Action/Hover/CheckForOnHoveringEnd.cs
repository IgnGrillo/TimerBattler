using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Hover
{
    public class CheckForOnHoveringEnd : ICheckForOnHoveringEnd
    {
        private readonly HoveringService _service;
        public CheckForOnHoveringEnd(HoveringService service) => _service = service;
        public void Execute() => _service.CheckForOnHoveringEnd();
    }
}