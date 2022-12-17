using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;
using Features.Mouse.Scripts.Infrastructure;
using Features.Mouse.Scripts.Presentation;

namespace Features.Mouse.Scripts.Provider
{
    public static class MouseProvider
    {
        public static MousePresenter MousePresenter(IMouseView mouseView)
        {
            var hoveringService = new HoveringService(new InMemoryHoveringRepository());
            return new MousePresenter(mouseView,
                    new UpdateMousePosition(),
                    new GetHoverable(new MouseRayService(mouseView.RaycastLayerMask)),
                    new UpdateHoveringAgent(hoveringService),
                    new CheckForOnHoveringStart(hoveringService),
                    new CheckForOnHovering(hoveringService),
                    new CheckForOnHoveringEnd(hoveringService));
        }
    }
}