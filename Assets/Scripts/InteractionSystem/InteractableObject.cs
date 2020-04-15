using UnityEngine;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField]
        private ObjectType _objectType;

        public ObjectType ObjectType { get { return _objectType; } set { _objectType = value; } }

        protected IAttachable attachBehaviour;

        private void Start()
        {
            ObjectType = ObjectType.None;
            attachBehaviour = new Attachment();
        }

        private void OnTriggerEnter(Collider other)
        {
            var triggerController = other.GetComponent<TriggerController>();
            Debug.LogError($"triggerController of {other.name} is null - {triggerController == null}");
            if (triggerController != null)
            {
                if (triggerController.ObjectType == ObjectType)
                {
                    AttachTo(triggerController.transform);
                }
            }
        }

        public IAttachable AttachBehaviour => attachBehaviour;

        public virtual void AttachTo(Transform target) => attachBehaviour.AttachTo(target);
    }

    public enum ObjectType { None, Wheel, Nut, Wrench };
}
