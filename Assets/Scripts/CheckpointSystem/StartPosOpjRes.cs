using UnityEngine;

public class StartPosOpjRes : MonoBehaviour
{
    private Vector3 StartPos;
    private Quaternion StartRot;
    private void Start()
    {
        StartPos = transform.position;
        StartRot = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = StartPos;
            transform.rotation = StartRot;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
