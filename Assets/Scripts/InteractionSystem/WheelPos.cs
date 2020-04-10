using System;
using UnityEngine;
using Valve.VR.InteractionSystem;
using QuestSystem;

public class WheelPos : MonoBehaviour, IQuestObject
{
    public Action AttachEvent { get; set; }

    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject wheel;
    [SerializeField]
    private float drag;

    private float defaultDrag;
    private Quaternion defaultAngle;

    private void Awake()
    {
        defaultAngle = transform.rotation;
    }

    private void Start()
    {
        defaultDrag = GetComponent<Rigidbody>().drag;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
            GetComponent<ThrowableExtend>()?.currentHand?.DetachObject(gameObject);
            //GetComponent<Interactable>().enabled = false;
            //transform.rotation = Quaternion.Euler(-18, -180, 90);
            transform.rotation = defaultAngle;
            transform.position = new Vector3(transform.position.x, obj.transform.position.y, obj.transform.position.z);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
                RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().drag = drag;
            wheel.GetComponent<MeshCollider>().enabled = false;
            AttachEvent();
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
            transform.rotation = defaultAngle;
            transform.position = new Vector3(transform.position.x, obj.transform.position.y, obj.transform.position.z);
            GetComponent<Interactable>().enabled = false;
            this.enabled = false;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (this.obj.name == obj.name)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            wheel.GetComponent<MeshCollider>().enabled = true;
            GetComponent<Rigidbody>().drag = defaultDrag;
        }
    }
}