using UnityEngine;

abstract public class InteractableObject : MonoBehaviour
{
    public enum Type { Wheel, Nut, Wrench };

    [SerializeField]
    private Type objectType;

    public Type ObjectType { get { return objectType; } }
}
