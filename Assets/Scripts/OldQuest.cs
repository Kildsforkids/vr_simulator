[System.Serializable]
public class OldQuest
{
    public bool isActive;

    public string title;
    public string description;
    public int currentGoalNum;

    public OldQuestGoal[] goal;
}
