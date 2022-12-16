using System;
using Features.Core.Scripts;
using Features.Mouse.Scripts.Domain;
using Features.Mouse.Scripts.Provider;
using UnityEngine;

namespace Features.Mouse.Scripts.Delivery
{
    public class MouseView : MonoBehaviour, IMouseView
    {
        [SerializeField] private LayerMask raycastLayerMask;
        
        public event UnitDelegate OnUpdate;
        public LayerMask RaycastLayerMask => raycastLayerMask;

        private void Start()
        {
            var presenter = MouseProvider.MousePresenter(this);
            presenter.Initialize();
        }

        private void Update() => OnUpdate();
    }
}