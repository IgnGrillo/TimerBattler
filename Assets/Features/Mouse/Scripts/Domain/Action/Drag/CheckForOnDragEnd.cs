using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public class CheckForOnDragEnd : ICheckForOnDragEnd
    {
        private readonly DraggingService _service;

        public CheckForOnDragEnd(DraggingService service)
        {
            _service = service;
        }
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}