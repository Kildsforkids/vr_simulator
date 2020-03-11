using UnityEngine;

public class WheelPos : MonoBehaviour
{
    public GameObject obj;

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("WORK");
        transform.parent.position = new Vector3(transform.parent.position.x, 0.425f, -0.465f);
        transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    void OnTriggerExit(Collider obj)
    {
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
}

//public class NutsPos : MonoBehaviour
//{
//    public GameObject rhoads;
//    GameObject[] nuts = new GameObject[8];

//    void OnTrigerEnter(Collider rhoads)
//    {
//        for (int i = 0; i < 8; i++)
//        {
//            nuts[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
//            nuts[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
//            nuts[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
//        }
//    }
//}