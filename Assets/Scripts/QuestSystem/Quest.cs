using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using vr_simulator.InteractionSystem;

namespace vr_simulator.QuestSystem
{
    [System.Serializable]
    public abstract class Quest : MonoBehaviour
    {
        [SerializeField]
        private bool _isActive;
        [SerializeField]
        private string _title;
        //[SerializeField]
        //private string _description;
        //[SerializeField]
        //private QuestGoal _goal;
        [SerializeField]
        private List<InteractableObject> _questObjects;
        //[SerializeField]
        //private QuestGiver _questGiver;

        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public string Title => _title;
        //public string Description => _description;
        //public QuestGoal Goal => _goal;
        //public GameObject QuestObject => _questObject;
        public Text text { get; set; }

        public abstract void DoUpdate(InteractableObject interactableObject);

        public virtual void Activate()
        {
            IsActive = true;
            if (text != null)
            {
                text.color = Color.green;
            }
            foreach (var o in _questObjects)
            {
                o.Quest = this;
            }
        }

        public void Complete()
        {
            IsActive = false;
            if (text != null)
            {
                text.color = Color.grey;
            }
            foreach (var o in _questObjects)
            {
                o.DenyQuest();
            }
            QuestManager.Instance.SetNextQuest(this);
        }
    }
}
