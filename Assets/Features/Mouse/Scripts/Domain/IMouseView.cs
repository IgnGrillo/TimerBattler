using Features.Core.Scripts;
using UnityEngine;

namespace Features.Mouse.Scripts.Domain
{
    public interface IMouseView
    {
        event UnitDelegate OnUpdate;
        LayerMask InteractableLayerMask { get; }
        LayerMask HoverLayerMask { get; }
        LayerMask DragLayerMask { get; }
    }
}