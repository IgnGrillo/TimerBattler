using Features.Core.Scripts;

namespace Features.Mouse.Scripts.Domain
{
    public interface IMouseView
    {
        event UnitDelegate OnUpdate;
    }
}