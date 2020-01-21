using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    [Header("Scene")]
    public Transform selectionTransform;
    public Transform cursorTransform;

    [Header("Events")]
    public RadialSection top;
    public RadialSection right;
    public RadialSection bottom;
    public RadialSection left;
}
