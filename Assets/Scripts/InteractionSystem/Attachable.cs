using UnityEngine;

abstract public class Attachable : InteractableObject
{
    private ThrowableExtend throwableExtend;

    private void Start()
    {
        throwableExtend = GetComponent<ThrowableExtend>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var triggerController = other.GetComponent<TriggerController>();
        if (triggerController != null)
        {
            if (triggerController.ObjectType == ObjectType)
            {
                AttachTo(other.transform);
            }
        }
    }

    protected virtual void AttachTo(Transform target)
    {
        throwableExtend.currentHand.DetachObject(gameObject);
        transform.position = target.position;
        transform.rotation = target.localRotation;
    }
}
