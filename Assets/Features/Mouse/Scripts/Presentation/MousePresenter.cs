using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;

namespace Features.Mouse.Scripts.Presentation
{
    public class MousePresenter
    {
        private readonly IMouseView _view;
        private readonly IUpdateMousePosition _updateMousePosition;
        private readonly IGetHoverable _getHoverable;
        private readonly IUpdateHoveringAgent _updateHoveringAgent;
        private readonly ICheckForOnHoveringStart _checkForOnHoveringStart;
        private readonly ICheckForOnHovering _checkForOnHovering;
        private readonly ICheckForOnHoveringEnd _checkForOnHoveringEnd;

        public MousePresenter(IMouseView view, IUpdateMousePosition updateMousePosition,
                              IGetHoverable getHoverable,
                              IUpdateHoveringAgent updateHoveringAgent,
                              ICheckForOnHoveringStart checkForOnHoveringStart,
                              ICheckForOnHovering checkForOnHovering,
                              ICheckForOnHoveringEnd checkForOnHoveringEnd)
        {
            _view = view;
            _updateMousePosition = updateMousePosition;
            _getHoverable = getHoverable;
            _updateHoveringAgent = updateHoveringAgent;
            _checkForOnHoveringStart = checkForOnHoveringStart;
            _checkForOnHovering = checkForOnHovering;
            _checkForOnHoveringEnd = checkForOnHoveringEnd;
        }

        public void Initialize() => _view.OnUpdate += Update;

        private void Update()
        {
            _updateMousePosition.Execute();
            var agent = _getHoverable.Execute();
            _updateHoveringAgent.Execute(agent);
            _checkForOnHoveringStart.Execute();
            _checkForOnHovering.Execute();
            _checkForOnHoveringEnd.Execute();
        }
    }
}