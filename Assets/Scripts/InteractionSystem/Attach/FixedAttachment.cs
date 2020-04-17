using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class FixedAttachment : Attachable
    {
        public override void AttachTo(InteractableObject interactableObject, Transform target)
        {
            Debug.Log($"FixedAttachment on {interactableObject.name}");
        }
    }
}
