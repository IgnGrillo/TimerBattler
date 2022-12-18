using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public class CheckForOnDrag : ICheckForOnDrag
    {
        private readonly DraggingService _service;

        public CheckForOnDrag(DraggingService service)
        {
            _service = service;
        }
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}