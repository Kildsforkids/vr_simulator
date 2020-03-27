using UnityEngine;
using Valve.VR.InteractionSystem;

public class KeyWrench : InteractableObject
{
    public bool IsAttached { get; set; }

    private Rigidbody rb;
    private CircularDrive circularDrive;
    private ThrowableExtend throwableExtend;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        circularDrive = GetComponent<CircularDrive>();
        throwableExtend = GetComponent<ThrowableExtend>();
        IsAttached = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsAttached)
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
    }

    protected void AttachTo(Transform target)
    {
        throwableExtend.currentHand.DetachObject(gameObject);
        transform.position = target.position;
        transform.rotation = target.rotation;
        rb.isKinematic = true;
        Destroy(GetComponent<ThrowableExtend>());
        Destroy(GetComponent<VelocityEstimator>());
        circularDrive.enabled = true;
        IsAttached = true;
    }
}
