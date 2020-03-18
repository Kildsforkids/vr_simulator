using UnityEngine;
using Valve.VR.InteractionSystem;

public class WheelPos : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject wheel;

    private void OnTriggerEnter(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
            GetComponent<ThrowableExtend>().currentHand.DetachObject(gameObject);
            GetComponent<Interactable>().enabled = false;
            transform.rotation = Quaternion.Euler(-18, -180, 90);
            transform.position = new Vector3(transform.position.x, obj.transform.position.y - 0.4f, obj.transform.position.z);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
                RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            GetComponent<Rigidbody>().isKinematic = false;
            wheel.GetComponent<MeshCollider>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        transform.rotation = Quaternion.Euler(-18, -180, 90);
        transform.position = new Vector3(transform.position.x, obj.transform.position.y - 0.4f, obj.transform.position.z);
    }

    void OnTriggerExit(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            wheel.GetComponent<MeshCollider>().enabled = true;
        }
    }
}