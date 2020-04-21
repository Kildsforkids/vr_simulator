using UnityEngine;
using UnityEngine.EventSystems;

namespace vr_simulator.CanvasPointer
{
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
            // Use default or distance
            PointerEventData data = inputModule.GetData();
            float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

            // Raycast
            RaycastHit hit = CreateRaycast(targetLength, LayerMask.GetMask("UI"));

            // Default
            //Vector3 endPosition = transform.position + (transform.forward * targetLength);
            Vector3 endPosition = Vector3.zero;

            // Or based on hit
            if (hit.collider != null)
            {
                endPosition = hit.point;
            }

            if (endPosition != Vector3.zero)
            {
                // Set position of the dot
                if (!dot.activeSelf)
                {
                    dot.SetActive(true);
                }
                dot.transform.position = endPosition;

                if (!lineRenderer.enabled)
                {
                    lineRenderer.enabled = true;
                }
                // Set linerenderer
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, endPosition);
            }
            else if (lineRenderer.enabled)
            {
                if (dot.activeSelf)
                {
                    dot.SetActive(false);
                }
                lineRenderer.enabled = false;
            }
        }

        private RaycastHit CreateRaycast(float length, int layerMask = 0)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            Physics.Raycast(ray, out hit, defaultLength, layerMask);

            return hit;
        }
    }
}
