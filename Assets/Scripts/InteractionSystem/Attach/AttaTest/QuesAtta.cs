using System;
using UnityEngine;

public class QuesAtta : Ques, IObserver
{
    [SerializeField]
    private Transform trigger;

    public void DoUpdate(Inter inter)
    {
        try
        {
            if (trigger.GetComponent<TypableObject>().ObjectType == inter.ObjectType)
            {
                Debug.Log($"I think it was attach event between {trigger.name} and {inter.name}");
            }
            else
            {
                Debug.Log($"{trigger.name} and {inter.name} ObjectType do not match");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError($"{trigger.name} error is [{e}]");
        }
    }
}
