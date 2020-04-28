using UnityEngine;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public class Nut : InteractableObject
    {
        [SerializeField]
        private GameObject attachmentTrigger;
        [SerializeField]
        private Vector3 attachmentPosition;

        public Vector3 AttachmentPosition { get { return attachmentPosition; } set { attachmentPosition = value; } }
        public GameObject AttachmentTrigger => attachmentTrigger;

        protected override void Start()
        {
            Attachable = new FixedAttachment();
            UpdateObserversList();
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
                    AttachmentPosition = transform.localPosition;
                    attachmentTrigger.SetActive(true);
                }
            }
        }
    }
}
