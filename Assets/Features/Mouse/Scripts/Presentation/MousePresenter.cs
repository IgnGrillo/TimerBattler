using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;

namespace Features.Mouse.Scripts.Presentation
{
    public class MousePresenter
    {
        private readonly IMouseView _view;
        private readonly IGetRaycastAgent _getRaycastAgent;
        private readonly IUpdateHoveringAgent _updateHoveringAgent;

        public MousePresenter(IMouseView view, IGetRaycastAgent getRaycastAgent,
                              IUpdateHoveringAgent updateHoveringAgent)
        {
            _view = view;
            _getRaycastAgent = getRaycastAgent;
            _updateHoveringAgent = updateHoveringAgent;
        }

        public void Initialize()
        {
            _view.OnUpdate += Update;
        }

        private void Update()
        {
            var agent = _getRaycastAgent.Execute();
            _updateHoveringAgent.Execute(agent);
        }
    }
}