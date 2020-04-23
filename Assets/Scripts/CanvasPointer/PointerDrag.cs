using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace vr_simulator.CanvasPointer
{
    public class PointerDrag : MonoBehaviour, IDragHandler
    {
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private Scrollbar verticalScrollbar;

        public void OnDrag(PointerEventData eventData)
        {
            Debug.LogError("IsDragging!");
            verticalScrollbar.value += eventData.delta.magnitude / canvas.scaleFactor;
        }
    }
}
