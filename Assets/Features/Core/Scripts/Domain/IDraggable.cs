namespace Features.Core.Scripts.Domain
{
    public interface IDraggable
    {
        UnitDelegate OnDraggingStart { get; set; }
        UnitDelegate OnDragging { get; set;}
        UnitDelegate OnDraggingEnd { get; set;}
    }
}