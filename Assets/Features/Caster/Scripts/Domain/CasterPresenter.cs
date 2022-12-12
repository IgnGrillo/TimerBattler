using System.Collections.Generic;
using Features.Core.Scripts;
using Features.Core.Scripts.Domain;
using Features.Skills.Scripts.Domain;

namespace Features.Caster.Scripts.Domain
{
    public class CasterPresenter
    {
        private IEventBus _eventBus;
        private List<ISkills> _skills;

        public CasterPresenter(IEventBus eventBus, List<ISkills> skills)
        {
            _eventBus = eventBus;
            _skills = skills;
        }
        
        public void Initialize() => _eventBus.SubscribeToEmission(GameEvent.OnTimerUpdate, AdvanceSkillsCooldown);
        public void Dispose() => _eventBus.Unsubscribe(GameEvent.OnTimerUpdate, AdvanceSkillsCooldown);

        private void AdvanceSkillsCooldown()
        {
            foreach (var skill in _skills)
                skill.AdvanceCooldown();
        }
    }
}