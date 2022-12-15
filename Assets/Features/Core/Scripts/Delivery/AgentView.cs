using Features.Core.Scripts.Domain;
using UnityEngine;

namespace Features.Core.Scripts.Delivery
{
    public class AgentView : MonoBehaviour, IAgentView {
        public UnitDelegate OnHoveringStart { get; }
        public UnitDelegate OnHovering { get; }
        public UnitDelegate OnHoveringEnd { get; }
    }
}