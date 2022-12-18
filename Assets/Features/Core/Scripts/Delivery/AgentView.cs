using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Core.Scripts.Delivery
{
    public class AgentView : MonoBehaviour, IHoverable, IInteractable, IDraggable
    {
        public UnitDelegate OnHoveringStart { get; set; }
        public UnitDelegate OnHovering { get; set; }
        public UnitDelegate OnHoveringEnd { get; set; }
        public UnitDelegate OnInteract { get; set; }
        public UnitDelegate OnDraggingStart { get; set; }
        public UnitDelegate OnDragging { get; set; }
        public UnitDelegate OnDraggingEnd { get; set; }

        private void Start()
        {
            OnHoveringStart += () => Debug.Log($"OnHoveringStart: {name}");
            OnHovering += () => Debug.Log($"OnHovering: {name}");
            OnHoveringEnd += () => Debug.Log($"OnHoveringEnd: {name}");
            OnInteract += () => Debug.Log($"OnInteract: {name}");
            OnDraggingStart += () => Debug.Log($"OnDraggingStart: {name}");
            OnDragging += () => Debug.Log($"OnDragging: {name}");
            OnDraggingEnd += () => Debug.Log($"OnDraggingEnd: {name}");
        }
    }
}