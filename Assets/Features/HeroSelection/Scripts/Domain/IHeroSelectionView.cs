using Features.Core.Scripts;
using Features.HeroSelection.Scripts.Infrastructure;

namespace Features.HeroSelection.Scripts.Domain
{
    public interface IHeroSelectionView
    {
        event HeroDelegate OnSelection;
        event UnitDelegate OnConfirmation;
    }
}