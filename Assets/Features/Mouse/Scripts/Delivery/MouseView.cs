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
        [SerializeField] private Texture2D defaultMouseSprite;
        
        public event UnitDelegate OnUpdate;
        public LayerMask RaycastLayerMask => raycastLayerMask;

        private void Awake()
        {
            //This will be updated by a separate Action, currently here just as an implementation example
            Cursor.SetCursor(defaultMouseSprite, Vector2.zero, CursorMode.Auto);
        }

        private void Start()
        {
            var presenter = MouseProvider.MousePresenter(this);
            presenter.Initialize();
        }

        private void Update() => OnUpdate();
    }
}