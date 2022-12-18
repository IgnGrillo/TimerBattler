using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public interface IUpdateDraggable
    {
        void Execute(IDraggable draggable);
    }
}