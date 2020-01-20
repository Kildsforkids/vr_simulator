using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class NewQuestManager
    {
        public static NewQuestManager instance = new NewQuestManager();

        [SerializeField]
        private GameObject canvas;
        [SerializeField]
        private GameObject textPrefab;
    }
}
