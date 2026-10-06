using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EventType = _Bludoku.Scripts.Events.EventType;

namespace _Bludoku.Scripts.Analytics.Providers
{
    public class MockAnalyticsProvider : IAnalyticsProvider
    {
        public void Init()
        {
        }

        public void SendEvent(EventType eventType, Dictionary<string, object> data = null)
        {
            var dataStr = GetDictionaryValues(data) ;
            Debug.Log($"[Analytics] event={eventType} data={dataStr}");
        }

        private string GetDictionaryValues(Dictionary<string, object> dictionary)
        {
            if (dictionary == null) return "null";

            var pairs = dictionary.Select(i => $"{i.Key}={i.Value}");
            return string.Join(";", pairs);
        }
    }
}