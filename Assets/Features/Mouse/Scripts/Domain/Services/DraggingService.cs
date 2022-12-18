using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;

namespace Features.Mouse.Scripts.Domain.Services
{
    public class DraggingService
    {
        private readonly IDraggingRepository _repository;

        public DraggingService(IDraggingRepository repository) => _repository = repository;

        public void UpdateDraggable(IDraggable draggable)
        {
            _repository.SetPrevious(_repository.GetCurrentDraggable());
            _repository.SetCurrent(draggable);
        }

        public void CheckForOnDragStart()
        {
            var previousDraggable = _repository.GetPreviousDraggable();
            var currentDraggable = _repository.GetCurrentDraggable();
            
            if (IsCurrentlyDragging() && IsDifferentDraggable())
                currentDraggable.OnDraggingStart();

            bool IsCurrentlyDragging() => currentDraggable != null;
            bool IsDifferentDraggable() => currentDraggable != previousDraggable;
        }
        
        public void CheckForOnDrag()
        {
            var previousDraggable = _repository.GetPreviousDraggable();
            var currentDraggable = _repository.GetCurrentDraggable();
            
            if (IsHoveringAnAgent() && IsHoveringSameAgent())
                currentDraggable.OnDragging();

            bool IsHoveringAnAgent() => currentDraggable != null;
            bool IsHoveringSameAgent() => currentDraggable == previousDraggable;
        }
        
        public void CheckForOnDragEnd()
        {
            var previousDraggable = _repository.GetPreviousDraggable();
            var currentDraggable = _repository.GetCurrentDraggable();
            
            if (IsNotHoveringAnAgent() && WasHoveringAnAgent())
                previousDraggable.OnDraggingEnd();

            bool IsNotHoveringAnAgent() => currentDraggable == null;
            bool WasHoveringAnAgent() => currentDraggable != previousDraggable;
            
        }
    }
}