using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using vr_simulator.QuestSystem;

public class QuestManager : GenericSingleton<QuestManager>
{
    [SerializeField]
    private QuestPanel questPanel;
    [SerializeField]
    private List<Quest> quests;

    public bool IsActive { get; set; }

    private void Start()
    {
        quests = GetComponents<Quest>().ToList();
        IsActive = false;
    }

    public void StartQuestPart()
    {
        if (!IsActive)
        {
            questPanel.SetMenu(false);
            foreach (var q in quests)
            {
                questPanel.AddQuest(q);
            }
            quests[0].Activate();
            IsActive = true;
        }
    }

    public void SetNextQuest(Quest q)
    {
        quests.Remove(q);
        if (quests.Count > 0)
        {
            quests[0].Activate();
        }
        else
        {
            questPanel.ShowWinStat();
        }
    }
}
