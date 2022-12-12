using Features.Core.Scripts;
using Features.Core.Scripts.Domain;
using Features.Core.Scripts.Infrastructure;
using Features.Time.Scripts.Domain;
using Features.Time.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Features.Time.Test.Editor
{
    public class TimePresenterShould
    {
        private ITimerView _view;
        private IEventBus _eventBus;
        private TimerPresenter _presenter;
        private const int Once = 1;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ITimerView>();
            _eventBus = Substitute.For<IEventBus>();
            _presenter = new TimerPresenter(_view, _eventBus);
        }

        [Test]
        public void SendOnTimeUpdateWhenTimerTriggers()
        {
            var timeToTick = 4.01f;
            GivenATimeToTickOf(timeToTick);
            GivenAnInitializedPresenter();
            WhenOnTimerUpdateIsRaised(timeToTick);
            ThenEventBusSendsOnTimerUpdateEvent();
        }

        [Test]
        public void UpdateVisualsWhenTimerTriggers()
        {
            var elapsedTime = 0.1f;
            var timeToTick =1f;
            GivenATimeToTickOf(timeToTick);
            GivenAnInitializedPresenter();
            WhenOnTimerUpdateIsRaised(elapsedTime);
            ThenUpdateTimerDisplayIsCalled(elapsedTime/timeToTick);
        }

        [Test]
        public void StopUpdatingTimerWhenStopTimerEventIsTriggered()
        {
            var elapsedTime = 0.1f;
            var bus = new EventBus();
            GivenAnInitializedPresenterUsingClassical(null, bus);
            GivenAnEmissionOfType(bus);
            WhenOnTimerUpdateIsRaised(elapsedTime);
            ThenEventBusDoesNotSendOnTimerUpdateEvent(_eventBus);
            ThenUpdateTimerDisplayIsNotCalled(_view);
        }

        private void GivenATimeToTickOf(float timeToTick) => _view.GetTimeToTick().Returns(timeToTick);
        private void GivenAnInitializedPresenter() => _presenter.Initialize();
        private void GivenAnInitializedPresenterUsingClassical(ITimerView view = null, IEventBus bus = null)
        {
            var presenter = new TimerPresenter(view ?? _view, bus ?? _eventBus);
            presenter.Initialize();
        }
        private static void GivenAnEmissionOfType(EventBus bus) => bus.EmitEvent(GameEvent.OnTimerStop);
        private void WhenOnTimerUpdateIsRaised(float timeToTick) => _view.OnTimerUpdate += Raise.Event<FloatDelegate>(timeToTick);
        private void ThenEventBusSendsOnTimerUpdateEvent() => _eventBus.Received(Once).EmitEvent(GameEvent.OnTimerUpdate);
        private void ThenUpdateTimerDisplayIsCalled(float elapsedTime) => _view.Received(Once).UpdateTimerDisplay(elapsedTime);
        private void ThenEventBusDoesNotSendOnTimerUpdateEvent(IEventBus bus) => bus.DidNotReceive().EmitEvent(GameEvent.OnTimerUpdate);
        private void ThenUpdateTimerDisplayIsNotCalled(ITimerView view) => view.DidNotReceive().UpdateTimerDisplay(Arg.Any<float>());
    }
}