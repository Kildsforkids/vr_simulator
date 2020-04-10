using UnityEngine;

abstract public class InteractableObject : MonoBehaviour
{

    [SerializeField]
    private ObjectType _objectType;

    public ObjectType ObjectType => _objectType;
}

public enum ObjectType { Wheel, Nut, Wrench };

