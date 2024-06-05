using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace ScriptableVariables
{
    public class EventListener : EventListenerBase
    {
        [SerializeField] private EventResponse[] _eventResponses = null;

        private Dictionary<ScriptableEvent, UnityEvent> _dictionary = new();

        protected override void ToggleRegistration(bool toggle)
        {
            for (var i = 0; i < _eventResponses.Length; i++)
            {
                if (toggle)
                {
                    _eventResponses[i].ScriptableEvent.RegisterListener(this);
                    if (!_dictionary.ContainsKey(_eventResponses[i].ScriptableEvent))
                    {
                        _dictionary.Add(_eventResponses[i].ScriptableEvent, _eventResponses[i].Response);
                    }
                }
                else
                {
                    _eventResponses[i].ScriptableEvent.UnregisterListener(this);
                    if (_dictionary.ContainsKey(_eventResponses[i].ScriptableEvent))
                    {
                        _dictionary.Remove(_eventResponses[i].ScriptableEvent);
                    }
                }
            }
        }

        public void OnEventRaised(ScriptableEvent eventRaised)
        {
            _dictionary[eventRaised].Invoke();
        }

        [System.Serializable]
        public struct EventResponse
        {
            public ScriptableEvent ScriptableEvent;
            public UnityEvent Response;
        }
    }
}
