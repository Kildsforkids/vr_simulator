using UnityEngine;

abstract public class InteractionObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationOffset;

    //[SerializeField]
    //private Transform holdingPivot;

    public GameController.ObjectType type;
    public ContainerController container;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Hold()
    {
        if (container != null)
        {
            container.isActive = false;
            container = null;
        }
        rb.isKinematic = false;
        gameObject.layer = 10;
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.layer = 10;
            }
        }
    }

    public void MoveWithHand(Transform hand)
    {
        rb.useGravity = false;
        //if (holdingPivot != null)
        //    transform.position = hand.position - holdingPivot.localPosition;
        //else
        //    transform.position = hand.position;
        transform.position = hand.position;
        transform.rotation = Quaternion.Euler(hand.rotation.eulerAngles + rotationOffset);
    }
}