using Features.Core.Scripts.Delivery;

namespace Features.Mouse.Scripts.Domain.Action
{
    class SetInteractable : ISetInteractable
    {
        public SetInteractable(InteractionService interactionService)
        {
            
        }
        
        public void Execute(AgentView agent)
        {
            //_interactionService.SetCurrentInteractable(gameObject);
        }
    }
}