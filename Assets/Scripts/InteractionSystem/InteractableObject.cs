using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using vr_simulator.InteractionSystem.Attach;
using vr_simulator.QuestSystem;
using vr_simulator.ScreenUI;

namespace vr_simulator.InteractionSystem
{
    public abstract class InteractableObject : TypableObject, IInteractableObject, IObservable
    {
        [SerializeField]
        private List<GameObject> questObservers;
        [SerializeField]
        private List<GameObject> otherObservers;
        [SerializeField]
        private ObjectInformation objInfo;

        private List<Quest> _questObservers = new List<Quest>();
        private List<IObserver> _otherObservers = new List<IObserver>();

        public Attachable Attachable { get; set; }
        public ObjectInformation ObjectInformation => objInfo;

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
                    NotifyQuestObservers();
                }
            }
        }

        public void UpdateObserversList()
        {
            foreach (var observer in questObservers)
            {
                try
                {
                    var observerComponents = observer.GetComponents<Quest>();
                    foreach (var component in observerComponents)
                    {
                        _questObservers.Add(component);
                        //AddObserver(component);
                    }
                }
                catch (NullReferenceException e)
                {
                    Debug.LogError($"Can't update observers' list with {observer.name} Error - [{e}]");
                }
            }
            foreach (var observer in otherObservers)
            {
                try
                {
                    var observerComponents = observer.GetComponents<IObserver>();
                    foreach (var component in observerComponents)
                    {
                        _otherObservers.Add(component);
                        //AddObserver(component);
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

        //public void AddObserver(IObserver o)
        //{
        //    observers.Add(o);
        //}

        public void NotifyQuestObservers()
        {
            foreach (var observer in _questObservers)
            {
                observer.DoUpdate(this);
            }
        }

        public void NotifyOtherObservers()
        {
            foreach (var observer in _otherObservers)
            {
                observer.DoUpdate(this);
            }
        }

        public void RemoveQuestObserver(Quest o)
        {
            _questObservers.Remove(o);
        }

        public void ActivateQuest()
        {
            if (_questObservers.Count > 0)
                _questObservers[0].Activate();
        }

        //public void RemoveObserver(IObserver o)
        //{
        //    observers.Remove(o);
        //}
    }
}
