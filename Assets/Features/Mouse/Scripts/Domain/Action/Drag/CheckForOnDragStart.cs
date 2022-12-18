using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public class CheckForOnDragStart : ICheckForOnDragStart
    { 
        private readonly DraggingService _service;

        public CheckForOnDragStart(DraggingService service) => _service = service;

        public void Execute() => _service.CheckForOnDragStart();
    }
}