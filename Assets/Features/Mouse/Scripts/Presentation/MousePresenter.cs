using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;
using Features.Mouse.Scripts.Domain.Action.Drag;
using Features.Mouse.Scripts.Domain.Action.Hover;
using Features.Mouse.Scripts.Domain.Action.Interaction;

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
        private readonly IGetDraggable _getDraggable;
        private readonly ICheckIfDragging _checkIfDragging;
        private readonly IUpdateDraggable _updateDraggable;
        private readonly ICheckForOnDragStart _checkForOnDragStart;
        private readonly ICheckForOnDrag _checkForOnDrag;
        private readonly ICheckForOnDragEnd _checkForOnDragEnd;

        public MousePresenter(IMouseView view,
                              IUpdateMousePosition updateMousePosition,
                              IGetHoverable getHoverable,
                              IUpdateHoverable updateHoverable,
                              ICheckForOnHoveringStart checkForOnHoveringStart,
                              ICheckForOnHovering checkForOnHovering,
                              ICheckForOnHoveringEnd checkForOnHoveringEnd,
                              IGetInteractable getInteractable,
                              ICheckForInteraction checkForInteraction,
                              IGetDraggable getDraggable,
                              ICheckIfDragging checkIfDragging,
                              IUpdateDraggable updateDraggable,
                              ICheckForOnDragStart checkForOnDragStart,
                              ICheckForOnDrag checkForOnDrag,
                              ICheckForOnDragEnd checkForOnDragEnd)
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
            _getDraggable = getDraggable;
            _checkIfDragging = checkIfDragging;
            _updateDraggable = updateDraggable;
            _checkForOnDragStart = checkForOnDragStart;
            _checkForOnDrag = checkForOnDrag;
            _checkForOnDragEnd = checkForOnDragEnd;
        }

        public void Initialize() => _view.OnUpdate += Update;

        private void Update()
        {
            _updateMousePosition.Execute();
            UpdateHoverableLogic();
            UpdateInteractableLogic();
            UpdateDraggableLogic();
            
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
            void UpdateDraggableLogic()
            {
                var draggable = _getDraggable.Execute();
                _checkIfDragging.Execute(draggable);
                _updateDraggable.Execute(draggable);
                _checkForOnDragStart.Execute();
                _checkForOnDrag.Execute();
                _checkForOnDragEnd.Execute();
            }
        }
    }
}