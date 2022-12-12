namespace Features.Skills.Scripts.Domain
{
    public interface ISkills
    {
        void Execute();
        void AdvanceCooldown();
    }
}