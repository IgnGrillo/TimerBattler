using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain
{
    public interface IHoveringRepository
    {
        IHoverable GetPreviousHoverable();
        IHoverable GetCurrentHoverable();
        void SetCurrent(IHoverable current);
        void SetPrevious(IHoverable previous);
    }
}