using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public class GetDraggable : IGetDraggable
    {
        private readonly MouseRayService _mouseRayService;
        
        public GetDraggable(MouseRayService mouseRayService) => _mouseRayService = mouseRayService;
        
        public IDraggable Execute() => _mouseRayService.GetDraggable();
    }
}