using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public abstract class InteractableObject : TypableObject, IInteractableObject, IObservable
    {
        //protected IAttachable attachBehaviour;

        [SerializeField]
        private List<GameObject> relatedObservers;

        private List<IObserver> observers = new List<IObserver>();

        public Attachable Attachable { get; set; }

        //private void Start()
        //{
        //    ObjectType = ObjectType.None;
        //    attachBehaviour = new Attachment();
        //}

        protected virtual void Start()
        {
            Attachable = new Attachment();
            UpdateObserversList();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            var otherTypableObject = other.GetComponent<TypableObject>();
            if (otherTypableObject != null)
            {
                if (otherTypableObject.ObjectType == ObjectType)
                {
                    AttachTo(Attachable, other.transform);
                    NotifyObservers();
                }
            }
        }

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

        public void DestroyInteraction()
        {
            Destroy(GetComponent<ThrowableExtend>());
            Destroy(GetComponent<Interactable>());
            Destroy(GetComponent<VelocityEstimator>());
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    var triggerController = other.GetComponent<TriggerController>();
        //    Debug.LogError($"triggerController of {other.name} is null - {triggerController == null}");
        //    if (triggerController != null)
        //    {
        //        if (triggerController.ObjectType == ObjectType)
        //        {
        //            AttachTo(triggerController.transform);
        //        }
        //    }
        //}

        //public IAttachable AttachBehaviour => attachBehaviour;


        //public virtual void AttachTo(Transform target) => attachBehaviour.AttachTo(target);

        public void AttachTo(IAttachable attachable, Transform target)
        {
            attachable.AttachTo(this, target);
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
}
