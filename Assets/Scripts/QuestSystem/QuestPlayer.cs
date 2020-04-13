using UnityEngine;

namespace QuestSystem
{
    public class QuestPlayer : MonoBehaviour
    {
        [SerializeField]
        private Quest _quest;

        public Quest Quest { get { return _quest; } set { _quest = value; } }

        private void Start()
        {
            _quest.QuestObject.GetComponent<Attachable>().AttachEvent += OnAttachEvent;
        }

        private void OnAttachEvent()
        {
            if (_quest.IsActive)
            {
                _quest.Goal.OnAttachObject();
                if (_quest.Goal.isReached())
                {
                    _quest.Complete();
                }
            }
        }
    }
}
