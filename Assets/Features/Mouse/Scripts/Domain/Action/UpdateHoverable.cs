using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class UpdateHoverable : IUpdateHoverable
    {
        private readonly HoveringService _service;

        public UpdateHoverable(HoveringService service) => _service = service;

        public void Execute(IHoverable hoverable) => _service.UpdateHovering(hoverable);
    }
}