using System;
using UnityEngine;

namespace vr_simulator.InteractionSystem.Attach
{
    public interface IAttachable
    {
        Action AttachEvent { get; set; }

        void AttachTo(Transform target);
    }
}
