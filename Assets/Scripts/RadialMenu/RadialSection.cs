using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class RadialSection
{
    public Sprite icon;
    public SpriteRenderer iconRenderer;
    public UnityEvent onPress = new UnityEvent();
}
