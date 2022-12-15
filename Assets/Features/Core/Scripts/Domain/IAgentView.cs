namespace Features.Core.Scripts.Domain
{
    public interface IAgentView
    {
        UnitDelegate OnHoveringStart { get; }
        UnitDelegate OnHovering { get; }
        UnitDelegate OnHoveringEnd { get; }
    }
}