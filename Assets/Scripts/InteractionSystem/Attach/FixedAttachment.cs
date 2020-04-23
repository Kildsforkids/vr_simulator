using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class FixedAttachment : Attachable
    {
        public override void AttachTo(InteractableObject interactableObject, Transform target)
        {
            interactableObject?.GetComponent<ThrowableExtend>()?.currentHand?.DetachObject(interactableObject.gameObject);
            interactableObject.transform.position = target.position;
            interactableObject.transform.rotation = target.rotation;
            interactableObject.transform.SetParent(target.parent);
            //interactableObject.transform.localRotation = new Quaternion(interactableObject.transform.localRotation.x, target.localRotation.y, target.localRotation.z, target.localRotation.w);
            interactableObject.DestroyInteraction();
            //var originalRotation = interactableObject.transform.rotation;
            //interactableObject.transform.rotation = originalRotation * Quaternion.AngleAxis(90, Vector3.forward);
            interactableObject.GetComponent<Rigidbody>().isKinematic = true;
            target.gameObject.SetActive(false);
            //interactableObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
