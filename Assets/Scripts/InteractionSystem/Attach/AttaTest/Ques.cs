using UnityEngine;

public abstract class Ques : MonoBehaviour
{
    [SerializeField]
    private string _title;
    [SerializeField]
    private string _description;
    [SerializeField]
    private int _requiredAmount;

    public string Title { get { return _title; } set { _title = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public int RequiredAmount { get { return _requiredAmount; } set { _requiredAmount = value; } }
}
