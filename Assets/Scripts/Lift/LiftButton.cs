using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    [SerializeField]
    private float upLimit;
    [SerializeField]
    private List<Transform> liftingObjects;

    private void OnCollisionEnter(Collision collision)
    {
        DoLifting();
    }

    private void OnCollisionExit(Collision collision)
    {
        CancelLifting();
    }

    private void DoLifting()
    {
        StartCoroutine(DoLiftingCoroutine());
    }

    private void CancelLifting()
    {
        StopCoroutine(DoLiftingCoroutine());
    }

    private IEnumerator DoLiftingCoroutine()
    {
        foreach(var obj in liftingObjects)
        {
            if (obj.position.y >= upLimit) break;
            obj.position += Vector3.up * 0.01f;
        }
        yield return new WaitForSeconds(2);
    }
}
