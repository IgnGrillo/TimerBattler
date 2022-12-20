using Features.Core.Scripts;
using Features.HeroSelection.Scripts.Domain;
using Features.HeroSelection.Scripts.Infrastructure;
using UnityEngine;

namespace Features.HeroSelection.Scripts.Delivery
{
    public class HeroSelectionView : MonoBehaviour, IHeroSelectionView
    {
        public event HeroDelegate OnSelection;
        public event UnitDelegate OnConfirmation;
    }
}