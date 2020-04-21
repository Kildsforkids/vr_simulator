using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using vr_simulator.InteractionSystem.Attach;

namespace vr_simulator.InteractionSystem
{
    public abstract class InteractableObject : TypableObject, IInteractableObject, IObservable
    {
        [SerializeField]
        private List<GameObject> relatedObservers;
        [SerializeField]
        private string hintText;

        private List<IObserver> observers = new List<IObserver>();

        public Attachable Attachable { get; set; }
        public string HintText => hintText;

        protected virtual void Start()
        {
            Attachable = new Attachment();
            UpdateObserversList();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            var trigger = other.GetComponent<TriggerController>();
            if (trigger != null)
            {
                if (trigger.ObjectType == ObjectType)
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
            Destroy(GetComponent<Throwable>());
            Destroy(GetComponent<Interactable>());
            Destroy(GetComponent<VelocityEstimator>());
        }

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
