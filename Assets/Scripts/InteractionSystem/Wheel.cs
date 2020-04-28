using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public class Wheel : InteractableObject
    {
        protected override void Start()
        {
            Attachable = new FixedAttachment();
            UpdateObserversList();
        }
    }
}
