using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Services;

namespace Features.Mouse.Scripts.Domain.Action.Interaction
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