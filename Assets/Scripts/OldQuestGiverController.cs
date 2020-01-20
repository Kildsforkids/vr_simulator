using UnityEngine;
using UnityEngine.UI;

public class OldQuestGiverController : MonoBehaviour
{
    public OldQuest quest;
    public PlayerController player;
    public Transform questDesk;
    public GameObject textPrefab;

    private void Start()
    {
        questDesk.GetChild(0).GetComponent<Text>().text = quest.title;
        questDesk.GetChild(1).GetComponent<Text>().text = quest.description;
        quest.isActive = true;
        //player.quest = quest;
        foreach (var goal in quest.goal)
        {
            var obj = Instantiate(textPrefab, questDesk);
            obj.GetComponent<Text>().text = goal.title;
            obj.name = goal.title;
            goal.text = obj.GetComponent<Text>();
        }
    }
}
