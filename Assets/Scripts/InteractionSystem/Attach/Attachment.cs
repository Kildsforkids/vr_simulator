using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class Attachment : Attachable
    {
        public override void AttachTo(InteractableObject interactableObject, Transform target)
        {
            interactableObject.GetComponent<ThrowableExtend>().currentHand.DetachObject(interactableObject.gameObject);
            interactableObject.transform.position = target.position;
            interactableObject.transform.localRotation = new Quaternion(interactableObject.transform.rotation.x, target.rotation.y, target.rotation.z, target.rotation.w);
            interactableObject.GetComponent<Rigidbody>().isKinematic = true;
            interactableObject.transform.SetParent(target);
            interactableObject.DestroyInteraction();
        }
    }
}
