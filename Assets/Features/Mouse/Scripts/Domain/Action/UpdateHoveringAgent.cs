using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class UpdateHoveringAgent : IUpdateHoveringAgent
    {
        private readonly HoveringService _service;

        public UpdateHoveringAgent(HoveringService service) => _service = service;

        public void Execute(IHoverable hoverable) => _service.UpdateHovering(hoverable);
    }
}