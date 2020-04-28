using UnityEngine;
using Valve.VR.InteractionSystem;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public class KeyWrench : InteractableObject
    {
        [SerializeField]
        private Collider circularDriveChildCollider;
        [SerializeField]
        private Transform grabOffset;
        [SerializeField]
        private float nutDistance;
        [SerializeField]
        private float rotScale;

        private enum KeyWrenchState { Default, Lever }

        private KeyWrenchState state;
        private float rotZ = 0f;
        private float rotValue = 0f;
        private Vector3 nutPosition;

        protected override void Start()
        {
            state = KeyWrenchState.Default;
            Attachable = new FixedAttachment();
            UpdateObserversList();
        }
        private void Update()
        {
            if (state == KeyWrenchState.Lever)
            {
                if (Mathf.Abs(transform.parent.localPosition.y - transform.parent.GetComponent<Nut>().AttachmentPosition.y) < nutDistance)
                {
                    if (transform.rotation.eulerAngles.z > rotZ)
                    {
                        if (rotValue > 0)
                            rotValue -= Time.deltaTime;
                        rotZ = transform.rotation.eulerAngles.z;
                        transform.parent.localPosition = nutPosition + Vector3.down * rotValue / rotScale;
                        //Debug.Log($"Rotation value of {transform.parent.name} is {rotValue}");
                    }
                    else if (transform.rotation.eulerAngles.z < rotZ)
                    {
                        rotValue += Time.deltaTime;
                        rotZ = transform.rotation.eulerAngles.z;
                        transform.parent.localPosition = nutPosition + Vector3.down * rotValue / rotScale;
                        //Debug.Log($"Rotation value of {transform.parent.name} is {rotValue}");
                    }
                }
                else
                {
                    CompleteQuest();
                }
            }
        }

        private void CompleteQuest()
        {
            if (Quest != null)
            {
                Quest.Complete();
            }
            SetDefaultState();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            var trigger = other.GetComponent<TriggerController>();
            if (trigger != null)
            {
                if (trigger.ObjectType == ObjectType)
                {
                    AttachTo(Attachable, other.transform);
                    //NotifyQuestObservers();
                    SetLeverState();
                }
            }
        }

        public override void DestroyInteraction()
        {
            Destroy(GetComponent<ThrowableExtend>());
            Destroy(GetComponent<VelocityEstimator>());
        }

        private void SetDefaultState()
        {
            state = KeyWrenchState.Default;
            Destroy(GetComponent<CircularDrive>());
            Destroy(GetComponent<LinearMapping>());
            var throwableExtend = gameObject.AddComponent<ThrowableExtend>();
            throwableExtend.attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.VelocityMovement | Hand.AttachmentFlags.TurnOffGravity;
            throwableExtend.attachmentOffset = grabOffset;
            //throwableExtend.onPickUp.AddListener(NotifyOtherObservers);
            gameObject.AddComponent<VelocityEstimator>();
            GetComponent<Rigidbody>().isKinematic = false;
            rotValue = 0f;
        }

        private void SetLeverState()
        {
            state = KeyWrenchState.Lever;
            var circularDrive = gameObject.AddComponent<CircularDrive>();
            GetComponent<Interactable>().enabled = true;
            circularDrive.childCollider = circularDriveChildCollider;
            circularDrive.axisOfRotation = CircularDrive.Axis_t.ZAxis;
            circularDrive.hoverLock = true;
            nutPosition = transform.parent.localPosition;
            transform.parent.GetComponent<Nut>().AttachmentTrigger.SetActive(false);
        }
    }
}
