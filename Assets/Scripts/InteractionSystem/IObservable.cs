namespace vr_simulator.InteractionSystem
{
    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
}
