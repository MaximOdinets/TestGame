using System.Collections.Generic;
using _Bludoku.Scripts.Events;

namespace _Bludoku.Scripts.Analytics
{
    public interface IAnalyticsProvider
    {
        void Init();

        void SendEvent(EventType eventType, Dictionary<string, object> data = null);
    }
}