using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inter : TypableObject, IInter, IObservable
{
    [SerializeField]
    private List<GameObject> relatedObservers;

    private List<IObserver> observers = new List<IObserver>();

    public Atta Atta { get; set; }

    public void UpdateObserversList()
    {
        foreach (var observer in relatedObservers)
        {
            try
            {
                var observerComponents = observer.GetComponents<IObserver>();
                foreach (var component in observerComponents)
                {
                    AddObserver(component);
                }
            }
            catch (NullReferenceException e)
            {
                Debug.LogError($"Can't update observers' list with {observer.name} Error - [{e}]");
            }
        }
    }

    public void Attach(IAtta atta)
    {
        atta.Execute(this);
    }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.DoUpdate(this);
        }
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }
}
