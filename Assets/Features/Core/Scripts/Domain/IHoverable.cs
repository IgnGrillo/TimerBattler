namespace Features.Core.Scripts.Domain
{
    public interface IHoverable
    {
        UnitDelegate OnHoveringStart { get; set; }
        UnitDelegate OnHovering { get; set;}
        UnitDelegate OnHoveringEnd { get; set;}
    }
}