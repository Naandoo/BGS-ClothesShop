using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableVariables
{
    [CreateAssetMenu(fileName = "ScriptableEvent", menuName = "ScriptableObjects/ScriptableEvent")]
    public class ScriptableEvent : ScriptableObject
    {
        private readonly List<EventListener> _eventListeners = new();
        private readonly List<Object> _listenersObjects = new();
        private Action _onRaised = null;

        public event Action OnRaised
        {
            add
            {
                _onRaised += value;

                Object listener = value.Target as Object;
                if (listener != null && !_listenersObjects.Contains(listener))
                {
                    _listenersObjects.Add(listener);
                }
            }
            remove
            {
                _onRaised -= value;

                Object listener = value.Target as Object;
                if (_listenersObjects.Contains(listener))
                {
                    _listenersObjects.Remove(listener);
                }
            }
        }

        public void Raise()
        {
            if (!Application.isPlaying) return;

            for (int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(this);
            }

            _onRaised.Invoke();
        }

        public void RegisterListener(EventListener listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(EventListener listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}
