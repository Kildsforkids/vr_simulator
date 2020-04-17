using UnityEngine;

public class BasicAtta : Atta
{
    public override void Execute(Inter inter)
    {
        Debug.Log($"BasicAtta is on {inter.name}");
    }
}
