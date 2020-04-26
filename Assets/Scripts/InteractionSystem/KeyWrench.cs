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
                Debug.Log($"Rotate {transform.parent.name} on {transform.rotation.eulerAngles.z}");
                if (transform.rotation.eulerAngles.z > rotZ)
                {
                    rotZ = transform.rotation.eulerAngles.z;
                }
                else
                {
                    rotZ = 0f;
                }
            }
        }

        protected override void OnTriggerEnter(Collider other)
        {
            var trigger = other.GetComponent<TriggerController>();
            if (trigger != null)
            {
                if (trigger.ObjectType == ObjectType)
                {
                    AttachTo(Attachable, other.transform);
                    if (Quest != null)
                    {
                        Quest.Complete();
                    }
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

        private void SetLeverState()
        {
            state = KeyWrenchState.Lever;
            Destroy(GetComponent<Interactable>());
            var circularDrive = gameObject.AddComponent<CircularDrive>();
            GetComponent<Interactable>().enabled = true;
            circularDrive.childCollider = circularDriveChildCollider;
            circularDrive.axisOfRotation = CircularDrive.Axis_t.ZAxis;
            circularDrive.hoverLock = true;
        }
    }
}
