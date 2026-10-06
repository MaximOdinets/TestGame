using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Bludoku.Scripts.Events
{
    public class EventsBus : MonoBehaviour
    {
        private static EventsBus _instance;

        private readonly Dictionary<EventType, List<Action<EventType, object>>> _listeners = new ();

        public static EventsBus Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("EventBus");
                    _instance = go.AddComponent<EventsBus>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void FireEvent(EventType eventType, object data = null)
        {
            if(_listeners.TryGetValue(eventType, out var list))
                list?.ForEach(i => i?.Invoke(eventType, data));
        }

        public void Subscribe(Action<EventType, object> action, EventType eventType)
        {
            if (_listeners.TryGetValue(eventType, out var list))
                list.Add(action);
            else
                _listeners.Add(eventType, new List<Action<EventType,object>>() { action });
        }
        
        public void Unsubscribe(Action<EventType, object> action, EventType eventType)
        {
            if(_listeners.TryGetValue(eventType, out var list))
                list.Remove(action);
        }
    }
}