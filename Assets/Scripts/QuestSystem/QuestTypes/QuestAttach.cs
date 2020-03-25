using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    [System.Serializable]
    public class QuestAttach : Quest {
        // Fields
        [SerializeField]
        public QuestTriggerController subjectTrigger, objectTrigger;

        [SerializeField]
        private Vector3 attachPosision, attachRotation;

        [Header("Для дебага")]
        [SerializeField]
        private bool notInUse;
        #region
        //public struct Trigger
        //{
        //    public QuestTriggerController subjectTrigger, objectTrigger;
        //    public Vector3 attachPosition, attachRotation;
        //}
        //public List<Trigger> triggers;
        #endregion
        // Methods
        private void Awake() {
            if (!notInUse)
            {
                // subjectTrigger
                if (subjectTrigger == null)
                {
                    Debug.LogError($"{GetType().Name} in {gameObject.name} need a subjectTrigger.");
                    enabled = false; return;
                }
                subjectTrigger.quest = this;
                #region
                //foreach (var trigger in triggers)
                //{
                //    if (trigger.subjectTrigger == null)
                //    {
                //        Debug.LogError($"{GetType().Name} in {gameObject.name} need a subjectTrigger.");
                //        enabled = false; return;
                //    }
                //    trigger.subjectTrigger.quest = this;
                //}
                // objectTrigger
                #endregion
                if (objectTrigger == null)
                {
                    Debug.LogError($"{GetType().Name} in {gameObject.name} need an objectTrigger.");
                    enabled = false; return;
                }
                objectTrigger.quest = this;
                #region
                //foreach (var trigger in triggers)
                //{
                //    if (trigger.objectTrigger == null)
                //    {
                //        Debug.LogError($"{GetType().Name} in {gameObject.name} need a objectTrigger.");
                //        enabled = false; return;
                //    }
                //    trigger.objectTrigger.quest = this;
                //}
                #endregion
            }
        }

        public override void Action() {
            var relatedGameObject = subjectTrigger.transform.parent.gameObject;
            var throwable = relatedGameObject.GetComponent<ThrowableExtend>();
            throwable.currentHand.DetachObject(relatedGameObject);
            Destroy(throwable);
            //throwable.enabled = false;
            relatedGameObject.transform.SetPositionAndRotation(attachPosision, Quaternion.Euler(attachRotation));
            relatedGameObject.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Attached!");
        }

        public override void End() {
            QuestManager.instance.quests.Remove(this);
            Destroy(subjectTrigger.gameObject);
            Destroy(objectTrigger.gameObject);
            Title.color = Color.green;
        }

        public override List<QuestTriggerController> GetRelatedTriggers()
        {
            return new List<QuestTriggerController> { subjectTrigger, objectTrigger };
        }

        public override void OnQuestTriggerEnter(Collider subjectCollider, Collider objectCollider) {
            if (subjectCollider != subjectTrigger.collider || objectCollider != objectTrigger.collider) return;
            Action();
            End();
            #region
            //foreach (var trigger in triggers)
            //{
            //    if (subjectCollider == trigger.subjectTrigger.collider && objectCollider == trigger.objectTrigger.collider)
            //    {
            //        Action(trigger.subjectTrigger);
            //        End(trigger.subjectTrigger, trigger.objectTrigger);
            //        return;
            //    }
            //}
            //return;
            #endregion
        }
    }
}