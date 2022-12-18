using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public class UpdateDraggable : IUpdateDraggable
    {
        private readonly DraggingService _draggingService;

        public UpdateDraggable(DraggingService draggingService)
        {
            _draggingService = draggingService;
        }
        
        public void Execute(IDraggable draggable)
        {
            throw new System.NotImplementedException();
        }
    }
}