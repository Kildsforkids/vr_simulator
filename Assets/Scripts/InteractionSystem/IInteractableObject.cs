using UnityEngine;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public interface IInteractableObject
    {
        Attachable Attachable { get; set; }
        void AttachTo(IAttachable attachable, Transform target);
    }
}
