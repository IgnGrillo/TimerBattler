namespace Features.Core.Scripts.Domain
{
    public interface IInteractable
    {
        UnitDelegate OnInteract { get; set; }
    }
}