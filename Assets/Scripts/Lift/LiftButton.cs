using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    [SerializeField]
    private List<Transform> liftingObjects;

    private bool isLifting = false;

    private void Update()
    {
        if (isLifting)
            StartCoroutine(DoLiftingCoroutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        ButtonIn();
        DoLifting();
    }

    private void OnTriggerExit(Collider other)
    {
        ButtonOut();
    }

    private void ButtonIn()
    {

    }

    private void ButtonOut()
    {

    }

    private void DoLifting()
    {
        if (!isLifting)
        {
            isLifting = true;
        }
    }

    private IEnumerator DoLiftingCoroutine()
    {
        foreach (var obj in liftingObjects)
        {
            if (obj.position.y < 0.3f)
                obj.position += Vector3.up * 0.01f;
        }
        yield return new WaitForSeconds(2);
    }
}
