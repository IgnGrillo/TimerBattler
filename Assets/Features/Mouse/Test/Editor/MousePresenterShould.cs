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
            var presenter = GivenAPresenter(view, getRaycastAgent: getRaycastAgent);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenGetRaycastAgentIsCalled(getRaycastAgent);
        }

        [Test]
        public void SetHoveringAgentOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var updateHoveringAgent = GivenAnUpdateHoveringAgent();
            var agentView = Substitute.For<IAgentView>();
            getRaycastAgent.Execute().Returns(agentView);
            var presenter = GivenAPresenter(view, getRaycastAgent: getRaycastAgent,  updateHoveringAgent:updateHoveringAgent);
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
            var agentView = Substitute.For<IAgentView>();
            getRaycastAgent.Execute().Returns(agentView);
            var presenter = GivenAPresenter(view,getRaycastAgent: getRaycastAgent, updateHoveringAgent:updateHoveringAgent, checkForOnHoveringStart: checkForOnHoveringStart);
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
            var agentView = Substitute.For<IAgentView>();
            getRaycastAgent.Execute().Returns(agentView);
            var presenter = GivenAPresenter(view,getRaycastAgent: getRaycastAgent, updateHoveringAgent: updateHoveringAgent, checkForOnHovering: checkForOnHovering);
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
            var agentView = Substitute.For<IAgentView>();
            getRaycastAgent.Execute().Returns(agentView);
            var presenter = GivenAPresenter(view, getRaycastAgent: getRaycastAgent, updateHoveringAgent: updateHoveringAgent, checkForOnHoveringEnd: checkForOnHoveringEnd);
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

        private static IMouseView GivenAView() => Substitute.For<IMouseView>();
        private static IGetRaycastAgent GivenARaycastAgent() => Substitute.For<IGetRaycastAgent>();
        private static IUpdateHoveringAgent GivenAnUpdateHoveringAgent() => Substitute.For<IUpdateHoveringAgent>();
        private static ICheckForOnHoveringStart GivenACheckForOnHoveringStart() => Substitute.For<ICheckForOnHoveringStart>();
        private static ICheckForOnHovering GivenACheckForOnHovering() => Substitute.For<ICheckForOnHovering>();
        private static ICheckForOnHoveringEnd givenACheckForOnHoveringEnd() => Substitute.For<ICheckForOnHoveringEnd>();
        private MousePresenter GivenAPresenter(IMouseView view = null, 
                                               IUpdateMousePosition updateMousePosition = null,
                                               IGetRaycastAgent getRaycastAgent = null,
                                               IUpdateHoveringAgent updateHoveringAgent = null,
                                               ICheckForOnHoveringStart checkForOnHoveringStart = null,
                                               ICheckForOnHovering checkForOnHovering = null,
                                               ICheckForOnHoveringEnd checkForOnHoveringEnd = null)
        {
            return new MousePresenter(view ?? Substitute.For<IMouseView>(),
                    updateMousePosition ?? Substitute.For<IUpdateMousePosition>(),
                    getRaycastAgent ?? Substitute.For<IGetRaycastAgent>(),
                    updateHoveringAgent ?? Substitute.For<IUpdateHoveringAgent>(),
                    checkForOnHoveringStart ?? Substitute.For<ICheckForOnHoveringStart>(),
                    checkForOnHovering ?? Substitute.For<ICheckForOnHovering>(),
                    checkForOnHoveringEnd ?? Substitute.For<ICheckForOnHoveringEnd>());
        }

        private static void GivenAnInitialization(MousePresenter presenter) => presenter.Initialize();
        private static void WhenOnUpdateIsRaised(IMouseView view) => view.OnUpdate += Raise.Event<UnitDelegate>();
        private static void ThenGetRaycastAgentIsCalled(IGetRaycastAgent getRaycastAgent) => getRaycastAgent.Received(Once).Execute();
        private static void ThenUpdateHoveringAgentIsCalled(IUpdateHoveringAgent updateHoveringAgent, IAgentView agentView) => updateHoveringAgent.Received(Once).Execute(agentView);
        private static void ThenCheckForOnHoveringStartIsCalled(ICheckForOnHoveringStart checkForOnHoveringStart) => checkForOnHoveringStart.Received(Once).Execute();
        private static void ThenCheckForOnHoveringIsCalled(ICheckForOnHovering checkForOnHovering) => checkForOnHovering.Received(Once).Execute();
        private static void ThenCheckForOnHoveringEndIsCalled(ICheckForOnHoveringEnd checkForOnHoveringEnd ) => checkForOnHoveringEnd.Received(Once).Execute();
    }
}