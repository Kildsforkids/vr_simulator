using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem {
    public class QuestManager : MonoBehaviour {
        // Singleton
        public static QuestManager instance = new QuestManager();

        // Fields
        [SerializeField]
        private GameObject canvas;
        [SerializeField]
        private GameObject textPrefab;
        // Quests array
        [HideInInspector]
        public List<Quest> quests = new List<Quest>();
        // Methods
        void Awake() {
            var questContainers = GetComponentsInChildren<Transform>().Select(elem => elem.gameObject).ToList();
            if (questContainers.Find(elem => elem == gameObject).GetComponents<Quest>().Any()) {
                Debug.LogAssertion("Quests lying directly in the QuestManager will not be used.");
            }
            questContainers.Remove(gameObject);
            foreach (GameObject elem in questContainers) {
                var elemQuests = elem.GetComponentsInChildren<Quest>();
                if (elemQuests != null) instance.quests.AddRange(elemQuests);
                //Vector3 addPos = new Vector3(0f, 0.1f, 0f);
                int i = 0;
                foreach (var quest in elemQuests) {
                    var text = Instantiate(textPrefab, canvas.transform);
                    quest.Title = text.GetComponent<Text>();
                    text.GetComponent<Text>().text = quest.description;
                    text.transform.localPosition += Vector3.down * text.GetComponent<RectTransform>().rect.height * i++;
                    //text.transform.localPosition += addPos;
                    //addPos += new Vector3(0f, -15f, 0f);
                }
            }
        }
    }
}