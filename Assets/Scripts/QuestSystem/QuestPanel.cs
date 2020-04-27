using UnityEngine;
using UnityEngine.UI;
using vr_simulator.QuestSystem;
using vr_simulator.ScreenUI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField]
    private InformationBoard infoBoard;
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject titlePrefab;

    public void AddQuest(Quest quest)
    {
        var titleInstance = Instantiate(titlePrefab, transform);
        titleInstance.GetComponent<Text>().text = quest.Title;
        quest.text = titleInstance.GetComponent<Text>();
    }

    public void ShowWinStat()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        winPanel.SetActive(true);
        Invoke("SetMenuInvoke", 3f);
    }

    private void SetMenuInvoke()
    {
        SetMenu();
    }

    public void SetMenu(bool active = true)
    {
        winPanel.SetActive(false);
        infoBoard.SetState(active);
    }
}
