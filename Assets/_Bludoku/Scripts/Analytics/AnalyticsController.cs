using System.Collections.Generic;
using _Bludoku.Scripts.Analytics.Providers;
using _Bludoku.Scripts.Events;
using UnityEngine;
using EventType = _Bludoku.Scripts.Events.EventType;

namespace _Bludoku.Scripts.Analytics
{
    public class AnalyticsController : MonoBehaviour
    {
        private IAnalyticsProvider _analyticsProvider;
        private readonly List<EventType> _analyticsEvents = new()
        {
            EventType.Bonus,
            EventType.PowerUp,
            EventType.MoveFigure
        };

        private void Awake()
        {
            Init();
            _analyticsEvents.ForEach(i => EventsBus.Instance.Subscribe(OnAction, i));
        }

        private void Init()
        {
            _analyticsProvider = new MockAnalyticsProvider();
            _analyticsProvider.Init();
        }

        private void OnAction(EventType eventType, object data)
        {
            var dictionary = data is Dictionary<string, object> objects ? objects : null;
            SendEvent(eventType, dictionary);
        }

        private void SendEvent(EventType eventType, Dictionary<string, object> data = null)
        {
            if (_analyticsProvider == null)
            {
                Debug.LogWarning("[AnalyticsController] AnalyticsProvider was not initialized!");
                return;
            }

            _analyticsProvider.SendEvent(eventType, data);
        }
    }
}