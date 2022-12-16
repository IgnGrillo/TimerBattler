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
            return new MousePresenter(mouseView, new UpdateMousePosition(),
                    new GetRaycastAgent(new MouseRayService(mouseView.RaycastLayerMask)),
                    new UpdateHoveringAgent(new HoveringService(new InMemoryHoveringRepository())),
                    new CheckForOnHoveringStart(), new CheckForOnHovering(), new CheckForOnHoveringEnd());
        }
    }
}