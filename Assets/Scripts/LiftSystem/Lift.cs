using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vr_simulator.LiftSystem
{
    public class Lift : MonoBehaviour
    {
        [SerializeField]
        private Transform liftingObject;
        [SerializeField]
        private List<Transform> movingParts;
        [SerializeField]
        private Transform targetPointOnRise;
        private Vector3 targetPointOnDescent;
        [SerializeField]
        private float smoothing;

        private IEnumerator doLifting;
        private IEnumerator doDescent;
        private float offset;

        private void Start()
        {
            targetPointOnDescent = liftingObject.position;
            offset = liftingObject.position.y - movingParts[0].position.y;
        }

        public void DoLifting()
        {
            StopAllCoroutines();
            doLifting = DoLiftingCoroutine();
            StartCoroutine(doLifting);
        }

        public void DoDescent()
        {
            StopAllCoroutines();
            doDescent = DoDescentCoroutine();
            StartCoroutine(doDescent);
        }

        public void CancelLifting()
        {
            if (doLifting != null)
                StopCoroutine(doLifting);
        }

        public void CancelDescent()
        {
            if (doDescent != null)
                StopCoroutine(doDescent);
        }

        private IEnumerator DoLiftingCoroutine()
        {
            while (Mathf.Abs(liftingObject.position.y - targetPointOnRise.position.y) > 0.05f)
            {
                MoveToPoint(targetPointOnRise.position);
                yield return null;
            }
        }

        private IEnumerator DoDescentCoroutine()
        {
            while (Mathf.Abs(liftingObject.position.y - targetPointOnDescent.y) > 0.05f)
            {
                MoveToPoint(targetPointOnDescent);
                yield return null;
            }
        }

        private void MoveToPoint(Vector3 point)
        {
            liftingObject.position = new Vector3(liftingObject.position.x,
                    Mathf.Lerp(liftingObject.position.y, point.y, smoothing * Time.deltaTime),
                    liftingObject.position.z);
            foreach (var part in movingParts)
            {
                part.position = new Vector3(part.position.x, liftingObject.position.y - offset, part.position.z);
            }
        }
    }
}
