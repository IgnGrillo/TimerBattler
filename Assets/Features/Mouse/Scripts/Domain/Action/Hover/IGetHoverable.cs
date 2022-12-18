using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action.Hover
{
    public interface IGetHoverable
    {
        IHoverable Execute();
    }
}