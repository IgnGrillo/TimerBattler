using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Mouse.Scripts.Domain.Services
{
    public class MouseRayService
    {
        private readonly LayerMask _hoverableLayerMask;
        private readonly LayerMask _interactableLayerMask;
        private readonly LayerMask _draggableLayerMask;
        private readonly Camera _camera;
        private RaycastHit _raycastHitInfo;

        public MouseRayService(LayerMask hoverableLayerMask, LayerMask interactableLayerMask, LayerMask draggableLayerMask)
        {
            _hoverableLayerMask = hoverableLayerMask;
            _interactableLayerMask = interactableLayerMask;
            _draggableLayerMask = draggableLayerMask;
            _camera = Camera.main;
        }

        public IHoverable GetHoverable()
        {
            CastRay();
            return GetHoverableFromCollider();
            
            void CastRay() => Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _raycastHitInfo, Mathf.Infinity, _hoverableLayerMask);
            IHoverable GetHoverableFromCollider() => _raycastHitInfo.collider != null ? _raycastHitInfo.collider.GetComponentInParent<IHoverable>() : null;
        }

        public IInteractable GetInteractable()
        {
            CastRay();
            return GetInteractableFromCollider();
            
            void CastRay() => Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _raycastHitInfo, Mathf.Infinity, _interactableLayerMask);
            IInteractable GetInteractableFromCollider() => _raycastHitInfo.collider != null ? _raycastHitInfo.collider.GetComponentInParent<IInteractable>() : null;
        }
        
        public IDraggable GetDraggable()
        {
            CastRay();
            return GetDraggableFromCollider();
            
            void CastRay() => Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _raycastHitInfo, Mathf.Infinity, _draggableLayerMask);
            IDraggable GetDraggableFromCollider() => _raycastHitInfo.collider != null ? _raycastHitInfo.collider.GetComponentInParent<IDraggable>() : null;
        }
    }
}