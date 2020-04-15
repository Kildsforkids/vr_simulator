using System;
using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class FixedAttachment : MonoBehaviour, IAttachable
    {
        public Action AttachEvent { get; set; }

        private ThrowableExtend throwableExtend;

        private void Start()
        {
            throwableExtend = GetComponent<ThrowableExtend>();
        }

        public void AttachTo(Transform target)
        {
            throwableExtend.currentHand.DetachObject(gameObject);
            transform.position = target.position;
            transform.rotation = target.localRotation;
            AttachEvent();
        }
    }
}
