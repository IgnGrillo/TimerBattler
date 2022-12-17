using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Core.Scripts.Delivery
{
    public class AgentView : MonoBehaviour, IHoverable {
        public UnitDelegate OnHoveringStart { get; set; }
        public UnitDelegate OnHovering { get; set; }
        public UnitDelegate OnHoveringEnd { get; set; }

        private void Start()
        {
            OnHoveringStart += () => Debug.Log($"OnHoveringStart: {name}");
            OnHovering += () => Debug.Log($"OnHovering: {name}");
            OnHoveringEnd += () => Debug.Log($"OnHoveringEnd: {name}");
        }
    }
}