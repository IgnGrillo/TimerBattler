using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;
using Features.Mouse.Scripts.Provider;

namespace Features.Mouse.Scripts.Domain.Action
{
    class CheckForInteraction : ICheckForInteraction
    {
        private readonly InteractionService _interactionService;

        public CheckForInteraction(InteractionService interactionService)
        {
            _interactionService = interactionService;
        }
        
        public void Execute(IInteractable interactable)
        {
            _interactionService.CheckForInteraction(interactable);
        }
    }
}