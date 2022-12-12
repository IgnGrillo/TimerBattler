using Features.Core.Scripts;
using Features.Mouse.Scripts.Domain;
using UnityEngine;

namespace Features.Mouse.Scripts.Delivery
{
    public class MouseView : MonoBehaviour, IMouseView
    {
        public event UnitDelegate OnUpdate;
    }
}