using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public abstract class Attachable : IAttachable
    {
        public abstract void AttachTo(InteractableObject interactableObject, Transform target);
    }
}
