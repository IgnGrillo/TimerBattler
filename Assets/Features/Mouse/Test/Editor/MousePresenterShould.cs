using Features.Core.Scripts;
using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;
using Features.Mouse.Scripts.Domain.Action.Drag;
using Features.Mouse.Scripts.Domain.Action.Hover;
using Features.Mouse.Scripts.Domain.Action.Interaction;
using Features.Mouse.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Features.Mouse.Test.Editor
{

    public class MousePresenterShould
    {
        private const int Once = 1;

        [Test]
        public void CastRayOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var presenter = GivenAPresenter(view, getHoverable: getRaycastAgent);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenGetRaycastAgentIsCalled(getRaycastAgent);
        }

        [Test]
        public void UpdateHoverableOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var updateHoveringAgent = GivenAnUpdateHoveringAgent();
            var agentView = Substitute.For<IHoverable>();
            getRaycastAgent.Execute().Returns(agentView);
            var presenter = GivenAPresenter(view, getHoverable: getRaycastAgent,  updateHoverable: updateHoveringAgent);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenUpdateHoveringAgentIsCalled(updateHoveringAgent, agentView);
        }
        
        [Test]
        public void CheckForOnHoveringStartOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var updateHoveringAgent = GivenAnUpdateHoveringAgent();
            var checkForOnHoveringStart = GivenACheckForOnHoveringStart();
            var presenter = GivenAPresenter(view,getHoverable: getRaycastAgent, updateHoverable: updateHoveringAgent, checkForOnHoveringStart: checkForOnHoveringStart);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForOnHoveringStartIsCalled(checkForOnHoveringStart);
        }

        [Test]
        public void CheckForOnHoveringOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var updateHoveringAgent = GivenAnUpdateHoveringAgent();
            var checkForOnHovering = GivenACheckForOnHovering();
            var presenter = GivenAPresenter(view,getHoverable: getRaycastAgent, updateHoverable: updateHoveringAgent, checkForOnHovering: checkForOnHovering);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForOnHoveringIsCalled(checkForOnHovering);
        }
        
        [Test]
        public void CheckForOnHoveringEndOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var updateHoveringAgent = GivenAnUpdateHoveringAgent();
            var checkForOnHoveringEnd = givenACheckForOnHoveringEnd();
            var presenter = GivenAPresenter(view, getHoverable: getRaycastAgent, updateHoverable: updateHoveringAgent, checkForOnHoveringEnd: checkForOnHoveringEnd);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForOnHoveringEndIsCalled(checkForOnHoveringEnd);
        }
        
        [Test]
        public void UpdateMouseCursorPosition()
        {
            var view = GivenAView();
            var updateMousePosition = Substitute.For<IUpdateMousePosition>();
            var presenter = GivenAPresenter(view, updateMousePosition);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            updateMousePosition.Received(Once).Execute();
        }
        
        [Test]
        public void GetInteractableOnUpdate()
        {
            var view = GivenAView();
            var getInteractable = Substitute.For<IGetInteractable>();
            var presenter = GivenAPresenter(view, getInteractable: getInteractable);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenGetInteractable(getInteractable);
        }
        
        [Test]
        public void CheckForInteractOnUpdate()
        {
            var view = GivenAView();
            var checkForInteraction = Substitute.For<ICheckForInteraction>();
            var presenter = GivenAPresenter(view, checkForInteraction: checkForInteraction);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForInteraction(checkForInteraction);
        }
        
        [Test]
        public void GetDraggableOnUpdate()
        {
            var view = GivenAView();
            var getDraggable = Substitute.For<IGetDraggable>();
            var presenter = GivenAPresenter(view, getDraggable: getDraggable);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenGetDraggable(getDraggable);
        }
        
        [Test]
        public void UpdateDraggableOnUpdate()
        {
            var view = GivenAView();
            var getDraggable = GivenAGetDraggable();
            var draggable = Substitute.For<IDraggable>();
            getDraggable.Execute().Returns(draggable);
            var updateDraggable = GivenAUpdateDraggable();
            var presenter = GivenAPresenter(view,getDraggable:getDraggable, updateDraggable: updateDraggable);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenUpdateDraggable(updateDraggable, draggable);
        }
        
        [Test]
        public void CheckForOnDragStartOnUpdate()
        {
            var view = GivenAView();
            var checkForOnDragStart = GivenACheckForOnDragStart();
            var presenter = GivenAPresenter(view,checkForOnDragStart:checkForOnDragStart);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForOnDragStart(checkForOnDragStart);
        }
        
        [Test]
        public void CheckForOnDragOnUpdate()
        {
            var view = GivenAView();
            var checkForOnDrag = GivenACheckForOnDrag();
            var presenter = GivenAPresenter(view,checkForOnDrag:checkForOnDrag);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForOnDrag(checkForOnDrag);
        }
        
        [Test]
        public void CheckForOnDragEndOnUpdate()
        {
            var view = GivenAView();
            var checkForOnDragEnd = givenACheckForOnDragEnd();
            var presenter = GivenAPresenter(view,checkForOnDragEnd:checkForOnDragEnd);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenCheckForOnDragEnd(checkForOnDragEnd);
        }

        private static IMouseView GivenAView() => Substitute.For<IMouseView>();
        private static IGetHoverable GivenARaycastAgent() => Substitute.For<IGetHoverable>();
        private static IUpdateHoverable GivenAnUpdateHoveringAgent() => Substitute.For<IUpdateHoverable>();
        private static ICheckForOnHoveringStart GivenACheckForOnHoveringStart() => Substitute.For<ICheckForOnHoveringStart>();
        private static ICheckForOnHovering GivenACheckForOnHovering() => Substitute.For<ICheckForOnHovering>();
        private static ICheckForOnHoveringEnd givenACheckForOnHoveringEnd() => Substitute.For<ICheckForOnHoveringEnd>();
        private static IGetDraggable GivenAGetDraggable() => Substitute.For<IGetDraggable>();
        private static IUpdateDraggable GivenAUpdateDraggable() => Substitute.For<IUpdateDraggable>();
        private static ICheckForOnDragStart GivenACheckForOnDragStart() => Substitute.For<ICheckForOnDragStart>();
        private static ICheckForOnDrag GivenACheckForOnDrag() => Substitute.For<ICheckForOnDrag>();
        private static ICheckForOnDragEnd givenACheckForOnDragEnd() => Substitute.For<ICheckForOnDragEnd>();
        private MousePresenter GivenAPresenter(IMouseView view = null,
                                               IUpdateMousePosition updateMousePosition = null,
                                               IGetHoverable getHoverable = null,
                                               IUpdateHoverable updateHoverable = null,
                                               ICheckForOnHoveringStart checkForOnHoveringStart = null,
                                               ICheckForOnHovering checkForOnHovering = null,
                                               ICheckForOnHoveringEnd checkForOnHoveringEnd = null,
                                               IGetInteractable getInteractable = null,
                                               ICheckForInteraction checkForInteraction = null,
                                               IGetDraggable getDraggable = null,
                                               IUpdateDraggable updateDraggable = null,
                                               ICheckForOnDragStart checkForOnDragStart = null,
                                               ICheckForOnDrag checkForOnDrag = null,
                                               ICheckForOnDragEnd checkForOnDragEnd = null)
        {
            return new MousePresenter(view ?? Substitute.For<IMouseView>(),
                    updateMousePosition ?? Substitute.For<IUpdateMousePosition>(),
                    getHoverable ?? Substitute.For<IGetHoverable>(),
                    updateHoverable ?? Substitute.For<IUpdateHoverable>(),
                    checkForOnHoveringStart ?? Substitute.For<ICheckForOnHoveringStart>(),
                    checkForOnHovering ?? Substitute.For<ICheckForOnHovering>(),
                    checkForOnHoveringEnd ?? Substitute.For<ICheckForOnHoveringEnd>(),
                    getInteractable ?? Substitute.For<IGetInteractable>(),
                    checkForInteraction ?? Substitute.For<ICheckForInteraction>(),
                    getDraggable ?? Substitute.For<IGetDraggable>(),
                    updateDraggable ?? Substitute.For<IUpdateDraggable>(),
                    checkForOnDragStart ?? Substitute.For<ICheckForOnDragStart>(),
                    checkForOnDrag ?? Substitute.For<ICheckForOnDrag>(),
                    checkForOnDragEnd ?? Substitute.For<ICheckForOnDragEnd>());
        }

        private static void GivenAnInitialization(MousePresenter presenter) => presenter.Initialize();
        private static void WhenOnUpdateIsRaised(IMouseView view) => view.OnUpdate += Raise.Event<UnitDelegate>();
        private static void ThenGetRaycastAgentIsCalled(IGetHoverable getHoverable) => getHoverable.Received(Once).Execute();
        private static void ThenUpdateHoveringAgentIsCalled(IUpdateHoverable updateHoverable, IHoverable hoverable) => updateHoverable.Received(Once).Execute(hoverable);
        private static void ThenCheckForOnHoveringStartIsCalled(ICheckForOnHoveringStart checkForOnHoveringStart) => checkForOnHoveringStart.Received(Once).Execute();
        private static void ThenCheckForOnHoveringIsCalled(ICheckForOnHovering checkForOnHovering) => checkForOnHovering.Received(Once).Execute();
        private static void ThenCheckForOnHoveringEndIsCalled(ICheckForOnHoveringEnd checkForOnHoveringEnd) => checkForOnHoveringEnd.Received(Once).Execute();
        private static void ThenGetInteractable(IGetInteractable getInteractable) => getInteractable.Received(Once).Execute();
        private static void ThenCheckForInteraction(ICheckForInteraction checkForInteraction) => checkForInteraction.Received(Once).Execute(Arg.Any<IInteractable>());
        private static void ThenGetDraggable(IGetDraggable getDraggable) => getDraggable.Received(Once).Execute();
        private static void ThenUpdateDraggable(IUpdateDraggable updateDraggable, IDraggable draggable) => updateDraggable.Received(Once).Execute(draggable);
        private static void ThenCheckForOnDragStart(ICheckForOnDragStart checkForOnDragStart) => checkForOnDragStart.Received(Once).Execute();
        private static void ThenCheckForOnDrag(ICheckForOnDrag checkForOnDrag) => checkForOnDrag.Received(Once).Execute();
        private static void ThenCheckForOnDragEnd(ICheckForOnDragEnd checkForOnDragEnd) => checkForOnDragEnd.Received(Once).Execute();
    }
}