using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;

namespace Features.Mouse.Scripts.Presentation
{
    public class MousePresenter
    {
        private readonly IMouseView _view;
        private readonly IGetRaycastAgent _getRaycastAgent;
        private readonly IUpdateHoveringAgent _updateHoveringAgent;
        private readonly ICheckForOnHoveringStart _checkForOnHoveringStart;
        private readonly ICheckForOnHovering _checkForOnHovering;
        private readonly ICheckForOnHoveringEnd _checkForOnHoveringEnd;

        public MousePresenter(IMouseView view, IGetRaycastAgent getRaycastAgent,
                              IUpdateHoveringAgent updateHoveringAgent,
                              ICheckForOnHoveringStart checkForOnHoveringStart,
                              ICheckForOnHovering checkForOnHovering,
                              ICheckForOnHoveringEnd checkForOnHoveringEnd)
        {
            _view = view;
            _getRaycastAgent = getRaycastAgent;
            _updateHoveringAgent = updateHoveringAgent;
            _checkForOnHoveringStart = checkForOnHoveringStart;
            _checkForOnHovering = checkForOnHovering;
            _checkForOnHoveringEnd = checkForOnHoveringEnd;
        }

        public void Initialize()
        {
            _view.OnUpdate += Update;
        }

        private void Update()
        {
            var agent = _getRaycastAgent.Execute();
            _updateHoveringAgent.Execute(agent);
            _checkForOnHoveringStart.Execute();
            _checkForOnHovering.Execute();
            _checkForOnHoveringEnd.Execute();
        }
    }
}