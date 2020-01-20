using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem {
    [System.Serializable]
    abstract public class Quest : MonoBehaviour {
        [SerializeField]
        public string description;

        public Text Title { get; set; }
        // Methods
        /// <summary>
        /// The action that must be called to complete the quest.
        /// </summary>
        abstract public void Action();
        /// <summary>
        /// Finishes the quest and removes it from the quest list.
        /// </summary>
        abstract public void End();
        /// <summary>
        /// List of triggers associated with this quest.
        /// </summary>
        abstract public List<QuestTriggerController> GetRelatedTriggers();
        /// <summary>
        /// Function called when any trigger associated with this quest is triggered.
        /// </summary>
        /// <param name="subjectCollider">Сollider of the object that performs the action</param>
        /// <param name="objectCollider">Collider of the object being acted upon</param>
        abstract public void OnQuestTriggerEnter(Collider subjectCollider, Collider objectCollider);
    }
}

/*
static class QuestActionExtension {
    public static void Invoke(this Quest.ActionType action, in Quest quest) {
        if (action == Quest.ActionType.Attach) quest.action = Attach;
    }
    public static void Attach(in Quest quest) {
        quest.objectTrigger.gameObject.transform.position = quest.subjectTrigger.gameObject.transform.position;
        quest.subjectTrigger.GetComponent<Rigidbody>().isKinematic = true;
    }
}*/