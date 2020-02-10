using UnityEngine;
using Valve.VR.InteractionSystem;

namespace QuestSystem {
    public class QuestTriggerController : MonoBehaviour {
        // Fields
        //[SerializeField]
        //private GameObject relatedGameObject;
        [SerializeField]
        private InteractableObject.Type objectType;
        //public GameObject RelatedGameObject { get => relatedGameObject; set => relatedGameObject = value; }
        public new Collider collider { get; private set; }
        public Quest quest { get; set; }

        // Methods
        void Start() {
            //if (relatedGameObject == null) {
            //    Debug.LogError($"{GetType().Name} in {gameObject.name} needs a related GameObject.");
            //    enabled = false; return;
            //}
            //if (relatedGameObject.GetComponent<Interactable>() == null) {
            //    Debug.LogError($"{GetType().Name} in {gameObject.name} needs an Interractible in related GameObject.");
            //    enabled = false; return;
            //}
            if ((collider = gameObject.GetComponent<Collider>()) == null || !collider.isTrigger) {
                Debug.LogError($"{GetType().Name} in {gameObject.name} needs a trigger collider.");
                enabled = false; return;
            }
            /*
            if (QuestManager.instance.quests.Count == 0) {
                Debug.LogError($"Quests from QuestManager is empty.");
                enabled = false; return;
            }
            */
            if (quest == null) {
                Debug.LogError($"{GetType().Name} in {gameObject.name} is not used in Quests from QuestManager.");
                enabled = false; return;
            }
        }

        private void OnTriggerEnter(Collider other) {
            quest.OnQuestTriggerEnter(collider, other);
        }
    }
}