using UnityEngine;

namespace vr_simulator.InteractionSystem
{
    public class TriggerController : TypableObject, IObserver
    {
        [SerializeField]
        private GameObject hint;

        public void ShowHint()
        {
            hint.SetActive(true);
        }

        public void HideHint()
        {
            hint.SetActive(false);
        }

        public void DoUpdate(InteractableObject interactableObject)
        {
            HideHint();
        }
    }
}
