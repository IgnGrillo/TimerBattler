using System.Collections.Generic;
using Features.Caster.Scripts.Domain;
using Features.Core.Scripts;
using Features.Core.Scripts.Domain;
using Features.Core.Scripts.Infrastructure;
using Features.Skills.Scripts.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Features.Caster.Test.Editor
{
    public class CasterPresenterShould
    {
        private const int Once = 1;

        [Test]
        public void TestIntentionallyFailingForCITest()
        {
            Assert.True(false);
        }

        [Test]
        public void AdvanceSkillsOnTimerUpdate()
        {
            var eventBus = new EventBus();
            var skills = new List<ISkills> { Substitute.For<ISkills>(), Substitute.For<ISkills>() };
            var presenter = GivenAPresenter(eventBus, skills);
            GivenAnInitialization(presenter);
            WhenAnOnTimerUpdateIsEmitted(eventBus);
            ThenAdvanceCooldownIsCalled(skills);
        }

        [Test]
        public void NotAdvanceSkillsWhenDisposeAndOnTimerUpdate()
        {
            var eventBus = new EventBus();
            var skills = new List<ISkills> { Substitute.For<ISkills>(), Substitute.For<ISkills>() };
            var presenter = GivenAPresenter(eventBus, skills);
            GivenAnInitialization(presenter);
            GivenADispose(presenter);
            WhenAnOnTimerUpdateIsEmitted(eventBus);
            ThenDontAdvanceCooldown(skills);
        }

        [Test]
        public void ThrowErrorWhenDisposingANonInitializedPresenter()
        {
            var eventBus = new EventBus();
            var presenter = GivenAPresenter(eventBus);
            Assert.Throws<ActionSubscriptionNotFound>(()=> WhenPresenterIsDisposed(presenter));
        }

        private CasterPresenter GivenAPresenter(IEventBus eventBus = null, List<ISkills> skills = null) => new(
                eventBus ?? Substitute.For<IEventBus>(),
                skills ?? new List<ISkills>() { Substitute.For<ISkills>() });

        private void GivenAnInitialization(CasterPresenter presenter) => presenter.Initialize();
        private void GivenADispose(CasterPresenter presenter) => presenter.Dispose();
        private void WhenAnOnTimerUpdateIsEmitted(IEventBus eventBus) => eventBus.EmitEvent(GameEvent.OnTimerUpdate);
        private void WhenPresenterIsDisposed(CasterPresenter presenter) => presenter.Dispose();

        private void ThenAdvanceCooldownIsCalled(List<ISkills> skillsList)
        {
            foreach (var skill in skillsList)
                skill.Received(Once).AdvanceCooldown();
        }

        private void ThenDontAdvanceCooldown(List<ISkills> skillsList)
        {
            foreach (var skill in skillsList)
                skill.DidNotReceive().AdvanceCooldown();
        }
    }
}