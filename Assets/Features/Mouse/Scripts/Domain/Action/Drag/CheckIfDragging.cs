using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public class CheckIfDragging : ICheckIfDragging
    {
        private readonly DraggingService _service;
        
        public CheckIfDragging(DraggingService service) => _service = service;
        
        public IDraggable Execute(IDraggable draggable) => _service.CheckIfDragging(draggable);
    }
}