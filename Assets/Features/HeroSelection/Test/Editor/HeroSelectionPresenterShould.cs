using Features.Core.Scripts;
using Features.HeroSelection.Scripts.Domain;
using Features.HeroSelection.Scripts.Domain.Actions;
using Features.HeroSelection.Scripts.Infrastructure;
using Features.HeroSelection.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Features.HeroSelection.Test.Editor
{
    public class HeroSelectionPresenterShould
    {
        private const int Once = 1;

        [Test]
        public void UpdateSelectedHeroWhenOnSelect()
        {
            var hero = GivenAHeroView();
            var view = GivenAHeroSelectionView();
            var selectHero = GivenASelectHero();
            var presenter = GivenAPresenter(view, selectHero);
            GivenAPresenterInitialization(presenter);
            WhenOnSelectionIsCalled(view, hero);
            ThenSelectHero(selectHero, hero);
        }

        [Test]
        public void SetSelectedHeroAsPlayersHeroWhenOnConfirmed()
        {
            var view = GivenAHeroSelectionView();
            var confirmHero = GivenAConfirmHero();
            var presenter = GivenAPresenter(view, confirmHero: confirmHero);
            GivenAPresenterInitialization(presenter);
            WhenOnConfirmationIsCalled(view);
            ThenConfirmHero(confirmHero);
        }

        private static IHeroView GivenAHeroView() => Substitute.For<IHeroView>();
        private static IHeroSelectionView GivenAHeroSelectionView() => Substitute.For<IHeroSelectionView>();
        private static ISelectHero GivenASelectHero() => Substitute.For<ISelectHero>();
        private static IConfirmHero GivenAConfirmHero() => Substitute.For<IConfirmHero>();
        private static HeroSelectionPresenter GivenAPresenter(IHeroSelectionView view = null,
                                                              ISelectHero selectHero = null,
                                                              IConfirmHero confirmHero = null)
        {
            return new HeroSelectionPresenter(view ?? Substitute.For<IHeroSelectionView>(),
                    selectHero ?? Substitute.For<ISelectHero>(),
                    confirmHero ?? Substitute.For<IConfirmHero>());
        }
        private static void GivenAPresenterInitialization(HeroSelectionPresenter presenter) => presenter.Initialize();
        private static void WhenOnSelectionIsCalled(IHeroSelectionView view, IHeroView hero) => view.OnSelection += Raise.Event<HeroDelegate>(hero);
        private static void WhenOnConfirmationIsCalled(IHeroSelectionView view) => view.OnConfirmation += Raise.Event<UnitDelegate>();
        private static void ThenSelectHero(ISelectHero selectHero, IHeroView hero) => selectHero.Received(Once).Execute(hero);
        private static void ThenConfirmHero(IConfirmHero confirmHero) => confirmHero.Received(Once).Execute();
    }
}