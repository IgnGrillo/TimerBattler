using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class GetInteractable : IGetInteractable
    {
        private readonly MouseRayService _mouseRayService;

        public GetInteractable(MouseRayService mouseRayService) => _mouseRayService = mouseRayService;

        public IInteractable Execute() => _mouseRayService.GetInteractable();
    }
}