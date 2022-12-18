using Features.Core.Scripts;
using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Domain.Action;
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

        private static IMouseView GivenAView() => Substitute.For<IMouseView>();
        private static IGetHoverable GivenARaycastAgent() => Substitute.For<IGetHoverable>();
        private static IUpdateHoverable GivenAnUpdateHoveringAgent() => Substitute.For<IUpdateHoverable>();
        private static ICheckForOnHoveringStart GivenACheckForOnHoveringStart() => Substitute.For<ICheckForOnHoveringStart>();
        private static ICheckForOnHovering GivenACheckForOnHovering() => Substitute.For<ICheckForOnHovering>();
        private static ICheckForOnHoveringEnd givenACheckForOnHoveringEnd() => Substitute.For<ICheckForOnHoveringEnd>();
        private MousePresenter GivenAPresenter(IMouseView view = null,
                                               IUpdateMousePosition updateMousePosition = null,
                                               IGetHoverable getHoverable = null,
                                               IUpdateHoverable updateHoverable = null,
                                               ICheckForOnHoveringStart checkForOnHoveringStart = null,
                                               ICheckForOnHovering checkForOnHovering = null,
                                               ICheckForOnHoveringEnd checkForOnHoveringEnd = null,
                                               IGetInteractable getInteractable = null,
                                               ICheckForInteraction checkForInteraction = null)
        {
            return new MousePresenter(view ?? Substitute.For<IMouseView>(),
                    updateMousePosition ?? Substitute.For<IUpdateMousePosition>(),
                    getHoverable ?? Substitute.For<IGetHoverable>(),
                    updateHoverable ?? Substitute.For<IUpdateHoverable>(),
                    checkForOnHoveringStart ?? Substitute.For<ICheckForOnHoveringStart>(),
                    checkForOnHovering ?? Substitute.For<ICheckForOnHovering>(),
                    checkForOnHoveringEnd ?? Substitute.For<ICheckForOnHoveringEnd>(),
                    getInteractable ?? Substitute.For<IGetInteractable>(),
                    checkForInteraction ?? Substitute.For<ICheckForInteraction>());
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
    }
}