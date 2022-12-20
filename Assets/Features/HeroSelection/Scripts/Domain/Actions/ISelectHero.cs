namespace Features.HeroSelection.Scripts.Domain.Actions
{
    public interface ISelectHero
    {
        void Execute(IHeroView hero);
    }
}