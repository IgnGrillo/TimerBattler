using Features.HeroSelection.Scripts.Domain;
using Features.HeroSelection.Scripts.Domain.Actions;

namespace Features.HeroSelection.Scripts.Presentation
{
    public class HeroSelectionPresenter
    {
        private readonly IHeroSelectionView _view;
        private readonly ISelectHero _selectHero;
        private readonly IConfirmHero _confirmHero;

        public HeroSelectionPresenter(IHeroSelectionView view, ISelectHero selectHero, IConfirmHero confirmHero)
        {
            _view = view;
            _selectHero = selectHero;
            _confirmHero = confirmHero;
        }

        public void Initialize()
        {
            _view.OnSelection += _selectHero.Execute;
            _view.OnConfirmation += _confirmHero.Execute;
        }
    }
}