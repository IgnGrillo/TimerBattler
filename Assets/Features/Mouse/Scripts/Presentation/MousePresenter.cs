using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;

namespace Features.Mouse.Scripts.Presentation
{
    public class MousePresenter
    {
        private readonly IMouseView _view;
        private readonly IUpdateMousePosition _updateMousePosition;
        private readonly IGetHoverable _getHoverable;
        private readonly IUpdateHoverable _updateHoverable;
        private readonly ICheckForOnHoveringStart _checkForOnHoveringStart;
        private readonly ICheckForOnHovering _checkForOnHovering;
        private readonly ICheckForOnHoveringEnd _checkForOnHoveringEnd;
        private readonly IGetInteractable _getInteractable;
        private readonly ICheckForInteraction _checkForInteraction;

        public MousePresenter(IMouseView view, 
                              IUpdateMousePosition updateMousePosition,
                              IGetHoverable getHoverable,
                              IUpdateHoverable updateHoverable,
                              ICheckForOnHoveringStart checkForOnHoveringStart,
                              ICheckForOnHovering checkForOnHovering,
                              ICheckForOnHoveringEnd checkForOnHoveringEnd, 
                              IGetInteractable getInteractable,
                              ICheckForInteraction checkForInteraction)
        {
            _view = view;
            _updateMousePosition = updateMousePosition;
            _getHoverable = getHoverable;
            _updateHoverable = updateHoverable;
            _checkForOnHoveringStart = checkForOnHoveringStart;
            _checkForOnHovering = checkForOnHovering;
            _checkForOnHoveringEnd = checkForOnHoveringEnd;
            _getInteractable = getInteractable;
            _checkForInteraction = checkForInteraction;
        }

        public void Initialize() => _view.OnUpdate += Update;

        private void Update()
        {
            _updateMousePosition.Execute();
            UpdateHoverableLogic();
            UpdateInteractableLogic();

            void UpdateHoverableLogic()
            {
                var hoverable = _getHoverable.Execute();
                _updateHoverable.Execute(hoverable);
                _checkForOnHoveringStart.Execute();
                _checkForOnHovering.Execute();
                _checkForOnHoveringEnd.Execute();
            }
            void UpdateInteractableLogic()
            {
                var interactable = _getInteractable.Execute();
                _checkForInteraction.Execute(interactable);
            }
        }
    }
}