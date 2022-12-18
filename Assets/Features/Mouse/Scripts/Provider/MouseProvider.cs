using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;
using Features.Mouse.Scripts.Domain.Services;
using Features.Mouse.Scripts.Infrastructure;
using Features.Mouse.Scripts.Presentation;

namespace Features.Mouse.Scripts.Provider
{
    public static class MouseProvider
    {
        public static MousePresenter MousePresenter(IMouseView mouseView)
        {
            var hoveringService = new HoveringService(new InMemoryHoveringRepository());
            var interactionService = new InteractionService();
            var mouseRayService = new MouseRayService(mouseView.HoverLayerMask, mouseView.InteractableLayerMask);
            return new MousePresenter(mouseView,
                    new UpdateMousePosition(),
                    new GetHoverable(mouseRayService),
                    new UpdateHoverable(hoveringService),
                    new CheckForOnHoveringStart(hoveringService),
                    new CheckForOnHovering(hoveringService),
                    new CheckForOnHoveringEnd(hoveringService), 
                    new GetInteractable(mouseRayService),
                    new CheckForInteraction(interactionService));
        }
    }
}