using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action
{
    public interface IUpdateHoverable
    {
        void Execute(IHoverable hoverable);
    }
}