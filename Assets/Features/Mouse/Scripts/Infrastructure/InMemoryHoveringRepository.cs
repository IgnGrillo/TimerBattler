using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain;

namespace Features.Mouse.Scripts.Infrastructure
{
    public class InMemoryHoveringRepository : IHoveringRepository
    {
        private IHoverable _previousHoverable;
        private IHoverable _currentHoverable;

        public IHoverable GetPreviousHoverable() => _previousHoverable;
        public IHoverable GetCurrentHoverable() => _currentHoverable;

        public void SetCurrent(IHoverable current) => _currentHoverable = current;
        public void SetPrevious(IHoverable previous) => _previousHoverable = previous;
    }
}