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
        [Test]
        public void CastRayOnUpdate()
        {
            var view = GivenAView();
            var getRaycastAgent = GivenARaycastAgent();
            var presenter = GivenAPresenter(view, getRaycastAgent);
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
            var presenter = GivenAPresenter(view, getRaycastAgent, updateHoveringAgent);
            GivenAnInitialization(presenter);
            WhenOnUpdateIsRaised(view);
            ThenUpdateHoveringAgentIsCalled(updateHoveringAgent, agentView);
        }

        private static IMouseView GivenAView() => Substitute.For<IMouseView>();
        private static IGetRaycastAgent GivenARaycastAgent() => Substitute.For<IGetRaycastAgent>();
        private static IUpdateHoveringAgent GivenAnUpdateHoveringAgent() => Substitute.For<IUpdateHoveringAgent>();

        private MousePresenter GivenAPresenter(IMouseView view = null, IGetRaycastAgent getRaycastAgent = null,
                                               IUpdateHoveringAgent updateHoveringAgent = null)
        {
            return new MousePresenter(view ?? Substitute.For<IMouseView>(),
                    getRaycastAgent ?? Substitute.For<IGetRaycastAgent>(),
                    updateHoveringAgent ?? Substitute.For<IUpdateHoveringAgent>());
        }

        private static void GivenAnInitialization(MousePresenter presenter) => presenter.Initialize();
        private static void WhenOnUpdateIsRaised(IMouseView view) => view.OnUpdate += Raise.Event<UnitDelegate>();
        private static void ThenGetRaycastAgentIsCalled(IGetRaycastAgent getRaycastAgent) => getRaycastAgent.Received(1).Execute();
        private static void ThenUpdateHoveringAgentIsCalled(IUpdateHoveringAgent updateHoveringAgent, IAgentView agentView) => updateHoveringAgent.Received(1).Execute(agentView);
        /*
        [Test]
        public void ExecuteCheckForInteractionOnMouseUp()
        {
            _view = Substitute.For<IMouseView>();
            _checkForInteraction = Substitute.For<ICheckForInteraction>();
            _setInteractable = Substitute.For<ISetInteractable>();
            _presenter = new MousePresenter(_view, _setInteractable, _checkForInteraction);
            _presenter.Initialize();
            var gameObject = new GameObject();
            _view.OnMouseUp += Raise.Event<GameObjectDelegate>(gameObject);
            _checkForInteraction.Received(1).Execute(gameObject);
        }
        */
    }
}