using UnityEngine;
using Valve.VR.InteractionSystem;

public class WheelPos : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    private Quaternion startRotation = Quaternion.identity; 

    private void OnTriggerEnter(Collider obj)
    {
        Debug.Log($"{this.obj.name} = {obj.name}");
        if (this.obj.name == obj.name)
        {
            GetComponent<ThrowableExtend>().currentHand.DetachObject(gameObject);
            GetComponent<Interactable>().enabled = false;
            transform.rotation = startRotation;
            transform.position = new Vector3(transform.position.x, 0.425f, -0.465f);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
                RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnTriggerStay(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
                RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }
}