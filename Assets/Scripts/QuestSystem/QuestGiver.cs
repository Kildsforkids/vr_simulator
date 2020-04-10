﻿using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField]
        private Quest _quest;
        [SerializeField]
        private QuestPlayer _player;
        [SerializeField]
        private Text _titleText;
        [SerializeField]
        private Text _descriptionText;

        private void Start()
        {
            UpdateQuestWindow();
            AcceptQuest();
        }

        public void UpdateQuestWindow(bool setQuestTitleColor = false)
        {
            if (setQuestTitleColor)
            {
                _titleText.color = Color.green;
            }
            else
            {
                _titleText.text = _quest.Title;
            }
        }

        public void AcceptQuest()
        {
            _quest.IsActive = true;
            _player.Quest = _quest;
        }
    }
}
