using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class Attachment : Attachable
    {
        public override void AttachTo(InteractableObject interactableObject, Transform target)
        {
            //Debug.Log($"Attachment on {interactableObject.name}");
            interactableObject.GetComponent<ThrowableExtend>()?.currentHand?.DetachObject(interactableObject.gameObject);
            interactableObject.transform.position = target.position;
            interactableObject.transform.rotation = target.localRotation;
            interactableObject.GetComponent<Rigidbody>().isKinematic = true;
            interactableObject.DestroyInteraction();
            interactableObject.transform.SetParent(target);
        }
    }
}
