using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float returnTime;

    private Transform player;
    private Vector3 startPos;
    private Quaternion startRot;
    private bool isInvoked = false;

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > maxDistance)
        {
            if (!isInvoked)
            {
                Invoke("ReturnToStartPosition", returnTime);
                isInvoked = true;
            }
        }
        else
        {
            if (isInvoked)
            {
                CancelInvoke("ReturnToStartPosition");
                isInvoked = false;
            }
        }
    }

    private void ReturnToStartPosition()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        isInvoked = false;
    }
}
