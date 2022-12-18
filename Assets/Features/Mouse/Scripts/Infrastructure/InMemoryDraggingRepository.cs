using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain;

namespace Features.Mouse.Scripts.Infrastructure
{
    public class InMemoryDraggingRepository : IDraggingRepository
    {
        private IDraggable _previousHoverable;
        private IDraggable _currentHoverable;

        public IDraggable GetPreviousDraggable() => _previousHoverable;
        public IDraggable GetCurrentDraggable() => _currentHoverable;

        public void SetCurrent(IDraggable current) => _currentHoverable = current;
        public void SetPrevious(IDraggable previous) => _previousHoverable = previous;
    }
}