using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class NewQuestTriggerController : MonoBehaviour
    {
        private enum Type { Wheel, Nut }
        [SerializeField]
        private Type type;
        
        public new Collider collider { get; private set; }
        public Quest quest { get; set; }

        private void Start()
        {
            if ((collider = gameObject.GetComponent<Collider>()) == null || !collider.isTrigger)
            {
                Debug.LogError($"{GetType().Name} in {gameObject.name} needs a trigger collider.");
                enabled = false; return;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            quest.OnQuestTriggerEnter(collider, other);
        }
    }
}
