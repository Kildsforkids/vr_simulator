using UnityEngine;

public class Wre : Inter
{
    private void Start()
    {
        Atta = new BasicAtta();
        UpdateObserversList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attach(Atta);
            NotifyObservers();
        }
    }
}
