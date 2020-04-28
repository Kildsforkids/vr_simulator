using UnityEngine;

public abstract class TypableObject : MonoBehaviour
{
    [SerializeField]
    private ObjectType _objectType;

    public ObjectType ObjectType { get { return _objectType; } set { _objectType = value; } }
}

public enum ObjectType { None, Wheel, Nut, Wrench }
