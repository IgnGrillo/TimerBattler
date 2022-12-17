using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Mouse.Scripts.Domain.Services
{
    public class InteractionService
    {
        public void CheckForInteraction(IInteractable interactable)
        {
            if (interactable != null && Input.GetMouseButtonDown(0))
                interactable.OnInteract();
        }
    }
}