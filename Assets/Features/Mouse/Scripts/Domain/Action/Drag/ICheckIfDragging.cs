using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action.Drag
{
    public interface ICheckIfDragging
    {
        IDraggable Execute(IDraggable draggable);
    }
}