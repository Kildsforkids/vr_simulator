using UnityEngine;

abstract public class InteractableObject
{
    public enum Type { Wheel, Nut, Wrench };

    [SerializeField]
    private Type objectType;
}
