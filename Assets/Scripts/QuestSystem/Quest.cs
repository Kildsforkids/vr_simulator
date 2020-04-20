using UnityEngine;

namespace vr_simulator.QuestSystem
{
    [System.Serializable]
    public abstract class Quest : MonoBehaviour
    {
        [SerializeField]
        private bool _isActive;
        [SerializeField]
        private string _title;
        [SerializeField]
        private string _description;
        [SerializeField]
        private QuestGoal _goal;
        [SerializeField]
        private GameObject _questObject;
        [SerializeField]
        private QuestGiver _questGiver;

        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public string Title => _title;
        public string Description => _description;
        public QuestGoal Goal => _goal;
        public GameObject QuestObject => _questObject;

        public void Complete()
        {
            _isActive = false;
            Debug.Log($"Вы выполнили задание \"{_title}\"!");
            _questGiver.UpdateQuestWindow(true);
        }
    }
}
