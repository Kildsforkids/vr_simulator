using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public string title;
    public string objName;
    public bool isReached;
    public int countToGo = 1;
    public Text text;

    public bool CheckIfIsReached(Transform obj, Transform container)
    {
        if (obj != null)
        {
            switch (goalType)
            {
                case GoalType.Take:
                    if (objName == obj.name)
                    {
                        if (countToGo > 0)
                            countToGo--;
                        if (countToGo <= 0)
                        {
                            isReached = true;
                            text.color = Color.green;
                            return true;
                        }
                        return false;
                    }
                    break;
                case GoalType.Put:
                    if (objName == obj.name && container != null)
                    {
                        if (countToGo > 0)
                            countToGo--;
                        if (countToGo <= 0)
                        {
                            isReached = true;
                            text.color = Color.green;
                            return true;
                        }
                        return false;
                    }
                    break;
            }
        }
        return false;
    }
}

//public enum GoalType
//{
//    Take,
//    Put
//}
