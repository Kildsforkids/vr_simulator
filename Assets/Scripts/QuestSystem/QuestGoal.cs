using UnityEngine;

namespace vr_simulator.QuestSystem
{
    [System.Serializable]
    public class QuestGoal
    {
        [SerializeField]
        private GoalType _goalType;
        [SerializeField]
        private int _requiredAmount;
        [SerializeField]
        private int _currentAmount;

        public GoalType GoalType => _goalType;

        public bool isReached()
        {
            return (_currentAmount >= _requiredAmount);
        }

        public void OnAttachObject()
        {
            if (_goalType == GoalType.Attach)
            {
                _currentAmount++;
            }
        }
    }

    public enum GoalType
    {
        Attach,
        Use
    }
}
