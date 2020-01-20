using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float sensitiveX = 3f;
    [SerializeField]
    private float sensitiveY = 3f;

    [SerializeField]
    private float minX = -360;
    [SerializeField]
    private float maxX = 360;
    [SerializeField]
    private float minY = -60;
    [SerializeField]
    private float maxY = 60;

    private Quaternion originalRot;
    private float rotX = 0;
    private float rotY = 0;
    private Transform holdingObject = null;
    private Transform container = null;
    private Transform hand;
    private int layerMask;
    private RaycastHit hit;
    private float yShift = 0.5f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        hand = transform.GetChild(0);
        var rb = GetComponent<Rigidbody>();

        if (rb)
            rb.freezeRotation = true;
        originalRot = transform.localRotation;
    }

    private void Update()
    {
        MouseMove();
        MouseClick();
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position -= Vector3.up * yShift;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.position += Vector3.up * yShift;
        }
    }

    private void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            if (holdingObject == null)
            {
                layerMask = 1 << LayerMask.NameToLayer("Box");

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
                {
                    var detailController = hit.transform.GetComponent<DetailController>();
                    if (detailController.container != null)
                    {
                        if (!detailController.container.isBlocked())
                        {
                            holdingObject = hit.transform;
                            detailController.Hold();
                        }
                    }
                    else
                    {
                        holdingObject = hit.transform;
                        detailController.Hold();
                        /*if (quest.goal[quest.currentGoalNum].CheckIfIsReached(holdingObject, container))
                        {
                            if (quest.currentGoalNum < quest.goal.Length - 1)
                                quest.currentGoalNum++;
                        }*/
                    }
                }
            }
            else
            {
                var detailController = holdingObject.GetComponent<DetailController>();

                detailController.MoveWithHand(hand);

                layerMask = 1 << LayerMask.NameToLayer("Container");

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
                {
                    if (hit.transform != null)
                    {
                        var containerController = hit.transform.GetComponent<ContainerController>();
                        if (container != null)
                        {
                            container.GetComponent<ContainerController>().EnableMesh(false);
                            container = null;
                        }
                        if (containerController.type == detailController.type)
                        {
                            container = hit.transform;
                            containerController.EnableMesh(true);
                        }
                    }
                }
                else
                {
                    if (container != null)
                    {
                        var containerController = container.GetComponent<ContainerController>();
                        if (containerController.type == detailController.type)
                        {
                            containerController.EnableMesh(false);
                            containerController.isActive = false;
                            container = null;
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButton(1))
        {
            if (holdingObject == null)
            {
                layerMask = 1 << LayerMask.NameToLayer("Box");

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
                {
                    if (hit.transform.GetComponent<Rigidbody>().isKinematic)
                    {
                        holdingObject = hit.transform;
                    }
                }
            }
            else
            {
                if (!holdingObject.GetComponent<DetailController>().container.isBlocked())
                {
                    holdingObject.Rotate(0.5f, 0, 0, Space.World);
                }
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            holdingObject = null;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (holdingObject != null)
            {
                var detailRigidbody = holdingObject.GetComponent<Rigidbody>();
                if (container != null)
                {
                    var detailController = holdingObject.GetComponent<DetailController>();
                    var containerController = container.GetComponent<ContainerController>();
                    if (containerController.isConditionObjectsActive())
                    {
                        if (!containerController.isActive)
                        {
                            if (containerController.type == detailController.type)
                            {
                                containerController.EnableMesh(false);
                                detailRigidbody.isKinematic = true;
                                detailController.container = containerController;
                                holdingObject.position = container.position;
                                holdingObject.rotation = container.rotation;
                                /*if (quest.goal[quest.currentGoalNum].CheckIfIsReached(holdingObject, container))
                                {
                                    if (quest.currentGoalNum < quest.goal.Length - 1)
                                        quest.currentGoalNum++;
                                }*/
                                containerController.isActive = true;
                                container = null;
                            }
                        }
                    }
                }
                detailRigidbody.useGravity = true;
                holdingObject.gameObject.layer = 8;
                if (holdingObject.childCount > 0)
                    for (int i = 0; i < holdingObject.childCount; i++)
                    {
                        holdingObject.GetChild(i).gameObject.layer = 0;
                    }
                holdingObject = null;
            }
        }
    }

    private void MouseMove()
    {
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        rotX %= 360;
        rotY %= 360;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        var xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        var yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * xQuaternion * yQuaternion;
    }
}
