using UnityEngine;

namespace Features.Mouse.Scripts.Domain.Action
{
    public interface ICheckForInteraction
    {
        void Execute(GameObject gameObject);
    }
}