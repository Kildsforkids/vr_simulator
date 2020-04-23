using UnityEngine;
using UnityEngine.UI;
using vr_simulator.InteractionSystem;

namespace vr_simulator.ScreenUI
{
    public class InformationBoard : MonoBehaviour, IObserver
    {
        [SerializeField]
        private Text hintText;
        [SerializeField]
        private GameObject infoPanel;
        [SerializeField]
        private Text title;
        [SerializeField]
        private Text description;
        [SerializeField]
        private Image image;

        public void DoUpdate(InteractableObject interactableObject)
        {
            if (interactableObject.ObjectInformation != null)
            {
                hintText.enabled = false;
                title.text = interactableObject.ObjectInformation.title;
                description.text = interactableObject.ObjectInformation.description;
                image.sprite = interactableObject.ObjectInformation.image;
                infoPanel.SetActive(true);
            }
            else
            {
                infoPanel.SetActive(false);
                hintText.text = $"Упс, похоже мы не нашли никакой информации\n по объекту \"{interactableObject.name}\"";
                hintText.enabled = true;
            }
        }
    }
}
