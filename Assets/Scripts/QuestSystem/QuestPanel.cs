using UnityEngine;
using UnityEngine.UI;
using vr_simulator.QuestSystem;

public class QuestPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject titlePrefab;

    public void AddQuest(Quest quest)
    {
        var titleInstance = Instantiate(titlePrefab, transform);
        titleInstance.GetComponent<Text>().text = quest.Title;
        quest.text = titleInstance.GetComponent<Text>();
    }
}
