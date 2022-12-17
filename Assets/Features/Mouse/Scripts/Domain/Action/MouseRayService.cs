using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class MouseRayService
    {
        private readonly LayerMask _layerMask;
        private readonly Camera _camera;
        private RaycastHit _raycastHitInfo;

        public MouseRayService(LayerMask layerMask)
        {
            _layerMask = layerMask;
            _camera = Camera.main;
        }

        public IHoverable GetHoverable()
        {
            CastRay();
            return GetAgent();
            
            void CastRay() => Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _raycastHitInfo, Mathf.Infinity, _layerMask);
            IHoverable GetAgent() => _raycastHitInfo.collider != null ? _raycastHitInfo.collider.GetComponentInParent<IHoverable>() : null;
        }
    }
}