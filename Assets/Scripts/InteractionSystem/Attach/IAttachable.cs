using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public interface IAttachable
    {
        void AttachTo(InteractableObject interactableObject, Transform target);
        //void AttachTo(Transform target);
    }
}
