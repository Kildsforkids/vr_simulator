using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{

    [SerializeField]
    private ObjectType _objectType;

    public ObjectType ObjectType { get { return _objectType; } set { _objectType = value; } }
}

public enum ObjectType { Wheel, Nut, Wrench };
