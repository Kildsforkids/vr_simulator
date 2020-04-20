namespace vr_simulator.InteractionSystem
{
    public interface IObserver
    {
        void DoUpdate(InteractableObject interactableObject);
    }
}
