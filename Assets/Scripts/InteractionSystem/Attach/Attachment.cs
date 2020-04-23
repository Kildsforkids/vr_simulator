using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class Attachment : Attachable
    {
        public override void AttachTo(InteractableObject interactableObject, Transform target)
        {
            interactableObject?.GetComponent<ThrowableExtend>()?.currentHand?.DetachObject(interactableObject.gameObject);
            //interactableObject.transform.position = target.position;
            interactableObject.transform.SetParent(target.parent);
            //interactableObject.transform.localRotation = new Quaternion(interactableObject.transform.localRotation.x, target.localRotation.y, target.localRotation.z, target.localRotation.w);
            interactableObject.DestroyInteraction();
            target.gameObject.SetActive(false);
            //var originalRotation = interactableObject.transform.rotation;
            //interactableObject.transform.rotation = originalRotation * Quaternion.AngleAxis(90, Vector3.forward);
            //interactableObject.GetComponent<Rigidbody>().isKinematic = true;
            //interactableObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
