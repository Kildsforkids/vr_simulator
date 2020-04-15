using UnityEngine;
using vr_simulator.InteractionSystem;

namespace QuestSystem
{
    public class QuestPlayer : MonoBehaviour
    {
        [SerializeField]
        private Quest _quest;

        public Quest Quest { get { return _quest; } set { _quest = value; } }

        private void Start()
        {
            Debug.LogError(_quest.QuestObject.GetComponent<InteractableObject>() == null);
            _quest.QuestObject.GetComponent<InteractableObject>().AttachBehaviour.AttachEvent += OnAttachEvent;
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
