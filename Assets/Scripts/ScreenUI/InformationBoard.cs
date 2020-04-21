using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using vr_simulator.InteractionSystem;

namespace vr_simulator.ScreenUI
{
    public class InformationBoard : MonoBehaviour, IObserver
    {
        [SerializeField]
        private Text hintText;

        public void DoUpdate(InteractableObject interactableObject)
        {
            hintText.text = interactableObject.HintText;
        }
    }
}
