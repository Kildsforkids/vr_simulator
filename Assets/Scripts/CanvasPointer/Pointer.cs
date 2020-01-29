using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float defaultLength = 5.0f;
    public GameObject dot;
    public VRInputModule inputModule;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Использовать по умолчанию или расстояние
        float targetLength = defaultLength;

        // Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // По умолчанию
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // Или основанные на hit
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        // Установить position точки
        dot.transform.position = endPosition;

        // LineRenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
