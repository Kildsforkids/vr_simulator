using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public class Wheel : InteractableObject
    {
        private void Start()
        {
            ObjectType = ObjectType.Wheel;
            attachBehaviour = new FixedAttachment();
        }

        //protected override void AttachTo(Transform target)
        //{
        //    throwableExtend?.currentHand?.DetachObject(gameObject);
        //    transform.position = target.position;
        //    transform.rotation = target.rotation;
        //    rb.isKinematic = true;
        //    GetComponent<Interactable>().enabled = false;
        //    AttachEvent();
        //}
    }
}

//public class Wheel : InteractableObject
//{
//    private Rigidbody rb;
//    private IAttachable

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        ObjectType = ObjectType.Wheel;
//    }

//    protected override void AttachTo(Transform target)
//    {
//        throwableExtend?.currentHand?.DetachObject(gameObject);
//        transform.position = target.position;
//        transform.rotation = target.rotation;
//        rb.isKinematic = true;
//        GetComponent<Interactable>().enabled = false;
//        AttachEvent();
//    }

    //private void OnTriggerEnter(Collider obj)
    //{
    //    if (this.obj.name == obj.name)
    //    {
    //        GetComponent<ThrowableExtend>()?.currentHand?.DetachObject(gameObject);
    //        //GetComponent<Interactable>().enabled = false;
    //        //transform.rotation = Quaternion.Euler(-18, -180, 90);
    //        transform.rotation = defaultAngle;
    //        transform.position = new Vector3(transform.position.x, obj.transform.position.y, obj.transform.position.z);
    //        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
    //            RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    //        GetComponent<Rigidbody>().isKinematic = false;
    //        GetComponent<Rigidbody>().drag = drag;
    //        wheel.GetComponent<MeshCollider>().enabled = false;
    //        AttachEvent();
    //    }
    //}

    //private void OnTriggerStay(Collider obj)
    //{
    //    if (this.obj.name == obj.name)
    //    {
    //        transform.rotation = defaultAngle;
    //        transform.position = new Vector3(transform.position.x, obj.transform.position.y, obj.transform.position.z);
    //        GetComponent<Interactable>().enabled = false;
    //        this.enabled = false;
    //    }
    //}

    //void OnTriggerExit(Collider obj)
    //{
    //    if (this.obj.name == obj.name)
    //    {
    //        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    //        wheel.GetComponent<MeshCollider>().enabled = true;
    //        GetComponent<Rigidbody>().drag = defaultDrag;
    //    }
    //}
//}
