using Features.Core.Scripts;
using Features.HeroSelection.Scripts.Domain;
using Features.HeroSelection.Scripts.Infrastructure;

namespace Features.HeroSelection.Scripts.Delivery
{
    public class HeroSelectionView : IHeroSelectionView
    {
        public event HeroDelegate OnSelection;
        public event UnitDelegate OnConfirmation;
    }
}