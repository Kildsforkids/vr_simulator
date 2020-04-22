using System;
using UnityEngine;
using vr_simulator.InteractionSystem;

namespace vr_simulator.QuestSystem.Quests
{
    public class QuestAttach : Quest, IObserver
    {
        [SerializeField]
        private Transform trigger;

        private TriggerController triggerController;

        private void Start()
        {
            triggerController = trigger?.GetComponent<TriggerController>();
            if (triggerController != null)
            {
                if (IsActive)
                {
                    triggerController.ShowHint();
                }
            }
        }

        public void DoUpdate(InteractableObject interactableObject)
        {
            try
            {
                if (triggerController.ObjectType == interactableObject.ObjectType)
                {
                    Debug.Log($"I think it was attach event between {trigger.name} and {interactableObject.name}");
                    triggerController.HideHint();
                }
                else
                {
                    Debug.Log($"{trigger.name} and {interactableObject.name} ObjectType do not match");
                }
            }
            catch (NullReferenceException e)
            {
                Debug.LogError($"{trigger.name} error is [{e}]");
            }
        }
    }
}
