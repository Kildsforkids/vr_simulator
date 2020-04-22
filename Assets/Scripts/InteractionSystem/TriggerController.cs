using UnityEngine;

namespace vr_simulator.InteractionSystem
{
    public class TriggerController : TypableObject
    {
        [SerializeField]
        private GameObject hint;

        public void ShowHint()
        {
            if (hint.GetComponent<Animation>() != null && hint != null)
            {
                hint.SetActive(true);
                hint.GetComponent<Animation>().Play("WheelHint");
            }
        }

        public void HideHint()
        {
            if (hint.GetComponent<Animation>() != null && hint != null)
            {
                hint.GetComponent<Animation>().Stop("WheelHint");
                hint.SetActive(false);
            }
        }
    }
}
