using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Mouse.Scripts.Domain.Services
{
    public class DraggingService
    {
        private readonly IDraggingRepository _repository;

        public DraggingService(IDraggingRepository repository) => _repository = repository;

        public IDraggable CheckIfDragging(IDraggable draggable)
        {
            if (draggable != null && Input.GetMouseButton(0)) return draggable;
            return null;
        }
        
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
            
            if (IsDragging() && IsDraggingSameDraggable())
                currentDraggable.OnDragging();

            bool IsDragging() => currentDraggable != null;
            bool IsDraggingSameDraggable() => currentDraggable == previousDraggable;
        }
        
        public void CheckForOnDragEnd()
        {
            var previousDraggable = _repository.GetPreviousDraggable();
            var currentDraggable = _repository.GetCurrentDraggable();
            
            if (IsNotDragging() && WasDragging())
                previousDraggable.OnDraggingEnd();

            bool IsNotDragging() => currentDraggable == null;
            bool WasDragging() => currentDraggable != previousDraggable;
        }
    }
}