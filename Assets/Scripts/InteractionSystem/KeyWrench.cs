using UnityEngine;
using Valve.VR.InteractionSystem;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public class KeyWrench : InteractableObject
    {
        [SerializeField]
        private Collider circularDriveChildCollider;

        private enum KeyWrenchState { Default, Lever }

        private KeyWrenchState state;
        private float rotZ = 0f;
        private float rotValue = 0f;
        private Vector3 nutPosition;
        private float rotScale = 10000f;

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
                if (rotValue < 1500)
                {
                    if (transform.rotation.eulerAngles.z > rotZ)
                    {
                        rotValue--;
                        rotZ = transform.rotation.eulerAngles.z;
                        transform.parent.localPosition = nutPosition + Vector3.down * rotValue / rotScale;
                        Debug.Log($"Rotation value of {transform.parent.name} is {rotValue}");
                    }
                    else if (transform.rotation.eulerAngles.z < rotZ)
                    {
                        rotValue++;
                        rotZ = transform.rotation.eulerAngles.z;
                        transform.parent.localPosition = nutPosition + Vector3.down * rotValue / rotScale;
                        Debug.Log($"Rotation value of {transform.parent.name} is {rotValue}");
                    }
                }
                else
                {
                    SetDefaultState();
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
            Destroy(GetComponent<Interactable>());
            gameObject.AddComponent<ThrowableExtend>();
            gameObject.AddComponent<VelocityEstimator>();
        }

        private void SetLeverState()
        {
            state = KeyWrenchState.Lever;
            Destroy(GetComponent<Interactable>());
            var circularDrive = gameObject.AddComponent<CircularDrive>();
            GetComponent<Interactable>().enabled = true;
            circularDrive.childCollider = circularDriveChildCollider;
            circularDrive.axisOfRotation = CircularDrive.Axis_t.ZAxis;
            circularDrive.hoverLock = true;
            nutPosition = transform.parent.localPosition;
        }
    }
}
