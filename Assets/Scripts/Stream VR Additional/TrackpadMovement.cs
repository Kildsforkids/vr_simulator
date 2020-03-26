using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TrackpadMovement : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Vector2 input;
    [SerializeField]
    private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (input.axis.magnitude > 0.1f)
        {
            var direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            transform.position += Vector3.ProjectOnPlane(direction, Vector3.up) * speed * Time.deltaTime;
        }
    }
}
