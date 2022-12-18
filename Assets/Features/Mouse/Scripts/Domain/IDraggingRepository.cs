using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain
{
    public interface IDraggingRepository
    {
        IDraggable GetPreviousDraggable();
        IDraggable GetCurrentDraggable();
        void SetCurrent(IDraggable current);
        void SetPrevious(IDraggable previous);
    }
}