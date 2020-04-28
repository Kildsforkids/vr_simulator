using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowableExtend : Throwable {
    // Fields
    public Hand currentHand { get; private set; }

    // Methods
    protected override void OnAttachedToHand(Hand hand) {
        //if (enabled) base.OnAttachedToHand(hand);
        if (enabled)
        {
            hadInterpolation = rigidbody.interpolation;

            attached = true;

            onPickUp?.Invoke();

            hand.HoverLock(null);

            rigidbody.interpolation = RigidbodyInterpolation.None;

            if (velocityEstimator != null)
                velocityEstimator.BeginEstimatingVelocity();

            attachTime = Time.time;
            attachPosition = transform.position;
            attachRotation = transform.rotation;
        }
        currentHand = hand;
    }

    protected override void OnHandHoverBegin(Hand hand) {
        if (enabled) base.OnHandHoverBegin(hand);
    }

    protected override void HandHoverUpdate(Hand hand) {
        if (enabled) base.HandHoverUpdate(hand);
    }

    protected override void HandAttachedUpdate(Hand hand) {
        if (enabled) base.HandAttachedUpdate(hand);
    }

    protected override void OnDetachedFromHand(Hand hand) {
        //if (enabled) base.OnDetachedFromHand(hand);
        if (enabled)
        {
            attached = false;

            onDetachFromHand?.Invoke();

            hand.HoverUnlock(null);

            rigidbody.interpolation = hadInterpolation;

            Vector3 velocity;
            Vector3 angularVelocity;

            GetReleaseVelocities(hand, out velocity, out angularVelocity);

            rigidbody.velocity = velocity;
            rigidbody.angularVelocity = angularVelocity;
        }
        currentHand = null;
    }

    protected override void OnHandHoverEnd(Hand hand) {
        if (enabled) base.OnHandHoverEnd(hand);
    }
}
