public class AttachGoal : Goal
{
    public int DetailID { get; set; }

    public AttachGoal(int detailID, string desctiption, bool completed, int currentAmount, int requiredAmount)
    {
        this.DetailID = detailID;
        this.Description = desctiption;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
    }

    private void DetailAttached(IDetail detail)
    {
        if (detail.ID == this.DetailID)
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
