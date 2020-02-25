using UnityEngine;

public class Trigger : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent trigger;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            trigger.Invoke();
        }
    }
}
