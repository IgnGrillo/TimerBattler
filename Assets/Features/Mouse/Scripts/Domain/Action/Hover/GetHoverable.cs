using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Hover
{
    public class GetHoverable : IGetHoverable
    {
        private readonly MouseRayService _service;

        public GetHoverable(MouseRayService service) => _service = service;

        public IHoverable Execute() => _service.GetHoverable();
    }
}