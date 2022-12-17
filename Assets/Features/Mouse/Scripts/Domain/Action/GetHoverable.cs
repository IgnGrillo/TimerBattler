using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class GetHoverable : IGetHoverable
    {
        private readonly MouseRayService _service;

        public GetHoverable(MouseRayService service) => _service = service;

        public IHoverable Execute() => _service.GetHoverable();
    }
}