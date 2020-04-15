using System;
using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public class Attachment : MonoBehaviour, IAttachable
    {
        public Action AttachEvent { get; set; }

        public void AttachTo(Transform target)
        {

        }
    }
}
