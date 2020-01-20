using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowableExtend : Throwable {
    // Fields
    public Hand currentHand { get; private set; }
    
    // Methods
    protected override void OnAttachedToHand(Hand hand) {
        if (enabled) base.OnAttachedToHand(hand);
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
        if (enabled) base.OnDetachedFromHand(hand);
        currentHand = null;
    }

    protected override void OnHandHoverEnd(Hand hand) {
        if (enabled) base.OnHandHoverEnd(hand);
    }
}
